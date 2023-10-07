using Ma.Crypto.SM2.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Ma.Crypto.SM2.Test
{
    class Program
    {
        //ASN.1解码后的公钥
        static string key = "0488076214BDB95BBC1CBBE03952FDB619CB9673E71E39D337CE6EB7DBF265C07599D147D9C674F28613E8E9BF6A47E6A602CC614E50571592CEDF4A46318B38FA";

        static void Main(string[] args)
        {
            SM2Crypto sm2 = new SM2Crypto(key, string.Empty, SM2Crypto.Mode.C1C3C2, true);

            string str = "{\"idcard\":\"8888\",\"phone\":\"13812345678\",\"deviceId\":\"001\"}";

            Console.WriteLine($"Original -> {str}");
            var bytes = Encoding.UTF8.GetBytes(str);
            var data = sm2.Encrypt(bytes);
           
            Request request = new Request()
            {
                data = Convert.ToBase64String(data),
                appid = "vC5rNcpegZmYBG41"
            };

            string content = Newtonsoft.Json.JsonConvert.SerializeObject(request);
            Console.WriteLine($"Request -> {content}");

            HttpResponseMessage response = HttpUtility.HttpPostResponse(
                @"http://101.34.4.203/test/checkin/userinfo",
                content,
                90000,
                Encoding.UTF8,
                "application/json");

            Task.Run(async () =>
            {
                string result = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Response -> {result}");
            });

            Console.ReadLine();
        }
    }
}
