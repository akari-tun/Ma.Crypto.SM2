using Org.BouncyCastle.Asn1.GM;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Math;
using System;

namespace Ma.Crypto.SM2.Utils
{
    public class SM2Crypto
    {
        public SM2Crypto(string pubkey, string privkey, Mode mode = Mode.C1C2C3, bool isPkcs8 = false)
        {
            if (pubkey != null)
                this.pubkey = pubkey;
            if (privkey != null)
                this.privkey = privkey;
            this.mode = mode;
        }

        string pubkey;
        string privkey;
        Mode mode;

        ICipherParameters _privateKeyParameters;
        ICipherParameters PrivateKeyParameters
        {
            get
            {
                try
                {
                    var r = _privateKeyParameters;
                    if (r == null) r = _privateKeyParameters =
                            new ECPrivateKeyParameters(new BigInteger(privkey, 16),
                            new ECDomainParameters(GMNamedCurves.GetByName("SM2P256V1")));
                    return r;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }

        ICipherParameters _publicKeyParameters;
        ICipherParameters PublicKeyParameters
        {
            get
            {
                try
                {
                    var r = _publicKeyParameters;
                    if (r == null)
                    {
                        //截取64字节有效的SM2公钥（如果公钥首个字节为0x04）
                        if (pubkey.Length > 128)
                        {
                            pubkey = pubkey.Substring(pubkey.Length - 128);
                        }
                        //将公钥拆分为x,y分量（各32字节）
                        String stringX = pubkey.Substring(0, 64);
                        String stringY = pubkey.Substring(stringX.Length);
                        //将公钥x、y分量转换为BigInteger类型
                        BigInteger x = new BigInteger(stringX, 16);
                        BigInteger y = new BigInteger(stringY, 16);
                        //通过公钥x、y分量创建椭圆曲线公钥规范
                        var x9ec = GMNamedCurves.GetByName("SM2P256V1");
                        r = _publicKeyParameters = new ECPublicKeyParameters(x9ec.Curve.CreatePoint(x, y),
                            new ECDomainParameters(x9ec));
                    }
                    return r;
                }
                catch (Exception ex)
                {
                    return null;
                    ;
                }
            }
        }

        public byte[] Decrypt(byte[] data)
        {
            try
            {
                if (mode == Mode.C1C3C2)
                    data = C132ToC123(data);
                var sm2 = new SM2Engine();
                sm2.Init(false, this.PrivateKeyParameters);
                return sm2.ProcessBlock(data, 0, data.Length);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public byte[] Encrypt(byte[] data)
        {
            try
            {
                //  var sm2 = new SM2Engine(new SM3Digest());
                var sm2 = new SM2Engine();
                sm2.Init(true, new ParametersWithRandom(this.PublicKeyParameters));
                data = sm2.ProcessBlock(data, 0, data.Length);
                if (mode == Mode.C1C3C2)
                    data = C123ToC132(data);
                return data;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        static byte[] C123ToC132(byte[] c1c2c3)
        {
            var gn = GMNamedCurves.GetByName("SM2P256V1");
            int c1Len = (gn.Curve.FieldSize + 7) / 8 * 2 + 1;
            int c3Len = 32;
            byte[] result = new byte[c1c2c3.Length];
            Array.Copy(c1c2c3, 0, result, 0, c1Len); //c1
            Array.Copy(c1c2c3, c1c2c3.Length - c3Len, result, c1Len, c3Len); //c3
            Array.Copy(c1c2c3, c1Len, result, c1Len + c3Len, c1c2c3.Length - c1Len - c3Len); //c2
            return result;

        }
        static byte[] C132ToC123(byte[] c1c3c2)
        {
            var gn = GMNamedCurves.GetByName("SM2P256V1");
            int c1Len = (gn.Curve.FieldSize + 7) / 8 * 2 + 1;
            int c3Len = 32;
            byte[] result = new byte[c1c3c2.Length];
            Array.Copy(c1c3c2, 0, result, 0, c1Len); //c1: 0->65
            Array.Copy(c1c3c2, c1Len + c3Len, result, c1Len, c1c3c2.Length - c1Len - c3Len); //c2
            Array.Copy(c1c3c2, c1Len, result, c1c3c2.Length - c3Len, c3Len); //c3
            return result;

        }
        public enum Mode
        {
            C1C2C3, C1C3C2
        }
    }
}
