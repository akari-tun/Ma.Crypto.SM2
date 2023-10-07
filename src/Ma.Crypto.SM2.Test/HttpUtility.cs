using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Ma.Crypto.SM2.Test
{
    public static class HttpUtility
    {
        #region GET

        #region 同步方法
        /// <summary>
        /// 使用Get方法获取字符串结果（没有加入Cookie）
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string HttpGet(string url, int timeOut, Encoding encoding = null, Dictionary<string, string> headers = null)
        {
            string result = string.Empty;

            using (HttpClient httpClient = new HttpClient()
            {
                MaxResponseContentBufferSize = 512000,
                Timeout = new TimeSpan(0, 0, 0, 0, timeOut)
            })
            {
                httpClient.DefaultRequestHeaders.Add("user-agent", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/36.0.1985.143 Safari/537.36");

                if (headers != null)
                {
                    foreach (var item in headers)
                    {
                        httpClient.DefaultRequestHeaders.Add(item.Key, item.Value);
                    }
                }

                HttpResponseMessage response = httpClient.GetAsync(new Uri(url)).Result;
                result = response.Content.ReadAsStringAsync().Result;
            }

            return result;
        }

        /// <summary>
        /// 使用Get方法获取字符串结果（没有加入Cookie）
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static HttpResponseMessage HttpGetResponse(string url, int timeOut, Encoding encoding = null, Dictionary<string, string> headers = null)
        {
            HttpResponseMessage result = null;

            using (HttpClient httpClient = new HttpClient()
            {
                MaxResponseContentBufferSize = 512000,
                Timeout = new TimeSpan(0, 0, 0, 0, timeOut)
            })
            {

                httpClient.DefaultRequestHeaders.Add("user-agent", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/36.0.1985.143 Safari/537.36");

                if (headers != null)
                {
                    foreach (var item in headers)
                    {
                        httpClient.DefaultRequestHeaders.Add(item.Key, item.Value);
                    }
                }

                result = httpClient.GetAsync(new Uri(url)).Result;
            }

            return result;
        }
        #endregion

        #region 异步方法
        /// <summary>
        /// 使用Get方法获取字符串结果（没有加入Cookie）
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static async Task<string> HttpGetAsync(string url, int timeOut, Encoding encoding = null, Dictionary<string, string> headers = null)
        {
            string result = string.Empty;

            using (HttpClient httpClient = new HttpClient()
            {
                MaxResponseContentBufferSize = 512000,
                Timeout = new TimeSpan(0, 0, 0, 0, timeOut)
            })
            {
                httpClient.DefaultRequestHeaders.Add("user-agent", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/36.0.1985.143 Safari/537.36");

                if (headers != null)
                {
                    foreach (var item in headers)
                    {
                        httpClient.DefaultRequestHeaders.Add(item.Key, item.Value);
                    }
                }

                HttpResponseMessage response = await httpClient.GetAsync(new Uri(url));
                result = await response.Content.ReadAsStringAsync();
            }
            return result;
        }

        /// <summary>
        /// 使用Get方法获取字符串结果（没有加入Cookie）
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static async Task<HttpResponseMessage> HttpGetResponseAsync(string url, int timeOut, Encoding encoding = null, Dictionary<string, string> headers = null)
        {
            HttpResponseMessage response = null;

            using (HttpClient httpClient = new HttpClient()
            {
                MaxResponseContentBufferSize = 512000,
                Timeout = new TimeSpan(0, 0, 0, 0, timeOut)
            })
            {
                httpClient.DefaultRequestHeaders.Add("user-agent", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/36.0.1985.143 Safari/537.36");

                if (headers != null)
                {
                    foreach (var item in headers)
                    {
                        httpClient.DefaultRequestHeaders.Add(item.Key, item.Value);
                    }
                }

                response = await httpClient.GetAsync(new Uri(url));
            }

            return response;
        }
        #endregion

        #endregion

        #region POST

        #region 同步方法
        /// <summary>
        /// 使用Post方法获取字符串结果（没有加入Cookie）
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="content">内容</param>
        /// <param name="timeOut">超时时间</param>
        /// <param name="encoding">编码（默认UTF-8）</param>
        /// <returns></returns>
        public static string HttpPost(string url, Dictionary<string, string> content, int timeOut, Encoding encoding = null)
        {
            string result = string.Empty;

            using (HttpClient httpClient = new HttpClient()
            {
                MaxResponseContentBufferSize = 512000,
                Timeout = new TimeSpan(0, 0, 0, 0, timeOut)
            })
            {
                httpClient.DefaultRequestHeaders.Add("user-agent", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/36.0.1985.143 Safari/537.36");

                HttpResponseMessage response = httpClient.PostAsync(new Uri(url), new FormUrlEncodedContent(content)).Result;
                result = response.Content.ReadAsStringAsync().Result;
            }
            return result;
        }

        /// <summary>
        /// 使用Post方法获取字符串结果（没有加入Cookie）
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="content">内容</param>
        /// <param name="timeOut">超时时间</param>
        /// <param name="encoding">编码（默认UTF-8）</param>
        /// <returns></returns>
        public static string HttpPost(string url, Stream content, int timeOut, Encoding encoding = null)
        {
            string result = string.Empty;

            using (HttpClient httpClient = new HttpClient()
            {
                MaxResponseContentBufferSize = 512000,
                Timeout = new TimeSpan(0, 0, 0, 0, timeOut)
            })
            {
                httpClient.DefaultRequestHeaders.Add("user-agent", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/36.0.1985.143 Safari/537.36");

                HttpResponseMessage response = httpClient.PostAsync(new Uri(url), new StreamContent(content)).Result;
                result = response.Content.ReadAsStringAsync().Result;
            }

            return result;
        }

        /// <summary>
        /// 使用Post方法获取字符串结果（没有加入Cookie）
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="content">内容</param>
        /// <param name="timeOut">超时时间</param>
        /// <param name="encoding">编码（默认UTF-8）</param>
        /// <returns></returns>
        public static string HttpPost(string url, string content, int timeOut, Encoding encoding = null)
        {
            string result = string.Empty;

            using (HttpClient httpClient = new HttpClient()
            {
                MaxResponseContentBufferSize = 512000,
                Timeout = new TimeSpan(0, 0, 0, 0, timeOut)
            })
            {
                httpClient.DefaultRequestHeaders.Add("user-agent", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/36.0.1985.143 Safari/537.36");

                HttpResponseMessage response = httpClient.PostAsync(new Uri(url),
                    new StringContent(content, encoding ?? Encoding.UTF8))
                    .Result;
                result = response.Content.ReadAsStringAsync().Result;
            }

            return result;
        }

        /// <summary>
        /// 使用Post方法获取字符串结果（没有加入Cookie）
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="content">内容</param>
        /// <param name="timeOut">超时时间</param>
        /// <param name="encoding">编码（默认UTF-8）</param>
        /// <returns></returns>
        public static HttpResponseMessage HttpPostResponse(string url, Dictionary<string, string> content, int timeOut, Encoding encoding = null)
        {
            HttpResponseMessage respone = null;

            using (HttpClient httpClient = new HttpClient()
            {
                MaxResponseContentBufferSize = 512000,
                Timeout = new TimeSpan(0, 0, 0, 0, timeOut)
            })
            {
                httpClient.DefaultRequestHeaders.Add("user-agent", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/36.0.1985.143 Safari/537.36");

                respone = httpClient.PostAsync(new Uri(url), new FormUrlEncodedContent(content)).Result;
            }

            return respone;
        }

        /// <summary>
        /// 使用Post方法获取字符串结果（没有加入Cookie）
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="content">内容</param>
        /// <param name="timeOut">超时时间</param>
        /// <param name="encoding">编码（默认UTF-8）</param>
        /// <returns></returns>
        public static HttpResponseMessage HttpPostResponse(string url, string content, int timeOut, 
            Encoding encoding = null,
            string contentType = "text/plain",
            Dictionary<string, string> headers = null)
        {
            HttpResponseMessage respone = null;

            using (HttpClient httpClient = new HttpClient()
            {
                MaxResponseContentBufferSize = 512000,
                Timeout = new TimeSpan(0, 0, 0, 0, timeOut)
            })
            {
                httpClient.DefaultRequestHeaders.Add("user-agent", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/36.0.1985.143 Safari/537.36");

                if (headers != null)
                {
                    foreach (var item in headers)
                    {
                        httpClient.DefaultRequestHeaders.Add(item.Key, item.Value);
                    }
                }

                respone =  httpClient.PostAsync(new Uri(url),
                    new StringContent(content, encoding ?? Encoding.UTF8, contentType)).Result;
            }

            return respone;
        }

        /// <summary>
        /// 使用Post方法获取字符串结果
        /// </summary>
        /// <param name="url"></param>
        /// /// <param name="timeOut"></param>
        /// <param name="cookieContainer"></param>
        /// <param name="postStream"></param>
        /// <param name="fileDictionary">需要上传的文件，Key：对应要上传的Name，Value：本地文件名</param>
        /// <param name="encoding"></param>
        /// <param name="cer">证书，如果不需要则保留null</param>
        /// <param name="checkValidationResult">验证服务器证书回调自动验证</param>
        /// <param name="refererUrl"></param>
        /// <returns></returns>
        public static string HttpPost(string url,
            int timeOut,
            Stream postStream = null,
            CookieContainer cookieContainer = null,
            Dictionary<string, string> fileDictionary = null,
            string refererUrl = null,
            Encoding encoding = null,
            X509Certificate2 cer = null,
            bool checkValidationResult = false)
        {
            throw new NotImplementedException("暂时未实现！");
        }
        #endregion

        #region 异步方法
        /// <summary>
        /// 使用Post方法获取字符串结果（没有加入Cookie）
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="content">内容</param>
        /// <param name="timeOut">超时时间</param>
        /// <param name="encoding">编码（默认UTF-8）</param>
        /// <returns></returns>
        public static async Task<string> HttpPostAsync(string url, Dictionary<string, string> content, int timeOut, Encoding encoding = null)
        {
            string result = string.Empty;

            using (HttpClient httpClient = new HttpClient()
            {
                MaxResponseContentBufferSize = 512000,
                Timeout = new TimeSpan(0, 0, 0, 0, timeOut)
            })
            {
                httpClient.DefaultRequestHeaders.Add("user-agent", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/36.0.1985.143 Safari/537.36");

                HttpResponseMessage response = await httpClient.PostAsync(new Uri(url), new FormUrlEncodedContent(content));
                result = await response.Content.ReadAsStringAsync();
            }

            return result;
        }

        /// <summary>
        /// 使用Post方法获取字符串结果（没有加入Cookie）
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="content">内容</param>
        /// <param name="timeOut">超时时间</param>
        /// <param name="encoding">编码（默认UTF-8）</param>
        /// <returns></returns>
        public static async Task<string> HttpPostAsync(string url, Stream content, int timeOut, Encoding encoding = null)
        {
            string result = string.Empty;

            using (HttpClient httpClient = new HttpClient()
            {
                MaxResponseContentBufferSize = 512000,
                Timeout = new TimeSpan(0, 0, 0, 0, timeOut)
            })
            {
                httpClient.DefaultRequestHeaders.Add("user-agent", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/36.0.1985.143 Safari/537.36");

                HttpResponseMessage response = await httpClient.PostAsync(new Uri(url), new StreamContent(content));
                result = await response.Content.ReadAsStringAsync();
            }
            return result;
        }

        /// <summary>
        /// 使用Post方法获取字符串结果（没有加入Cookie）
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="content">内容</param>
        /// <param name="timeOut">超时时间</param>
        /// <param name="encoding">编码（默认UTF-8）</param>
        /// <returns></returns>
        public static async Task<string> HttpPostAsync(string url, string content, int timeOut, Encoding encoding = null)
        {
            string result = string.Empty;

            using (HttpClient httpClient = new HttpClient()
            {
                MaxResponseContentBufferSize = 512000,
                Timeout = new TimeSpan(0, 0, 0, 0, timeOut)
            })
            {
                httpClient.DefaultRequestHeaders.Add("user-agent", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/36.0.1985.143 Safari/537.36");

                HttpResponseMessage response = await httpClient.PostAsync(new Uri(url), new StringContent(content, encoding ?? Encoding.UTF8));
                result = await response.Content.ReadAsStringAsync();
            }

            return result;
        }

        /// <summary>
        /// 使用Post方法获取字符串结果（没有加入Cookie）
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="content">内容</param>
        /// <param name="timeOut">超时时间</param>
        /// <param name="encoding">编码（默认UTF-8）</param>
        /// <returns></returns>
        public static async Task<HttpResponseMessage> HttpPostResponseAsync(string url, 
            Dictionary<string, string> content, 
            int timeOut, 
            Encoding encoding = null,
            Dictionary<string, string> headers = null)
        {
            HttpResponseMessage respone = null;

            using (HttpClient httpClient = new HttpClient()
            {
                MaxResponseContentBufferSize = 512000,
                Timeout = new TimeSpan(0, 0, 0, 0, timeOut)
            })
            {
                httpClient.DefaultRequestHeaders.Add("user-agent", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/36.0.1985.143 Safari/537.36");

                if (headers != null)
                {
                    foreach (var item in headers)
                    {
                        httpClient.DefaultRequestHeaders.Add(item.Key, item.Value);
                    }
                }

                respone = await httpClient.PostAsync(new Uri(url), new FormUrlEncodedContent(content));
            }

            return respone;
        }

        /// <summary>
        /// 使用Post方法获取字符串结果（没有加入Cookie）
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="content">内容</param>
        /// <param name="timeOut">超时时间</param>
        /// <param name="encoding">编码（默认UTF-8）</param>
        /// <returns></returns>
        public static async Task<HttpResponseMessage> HttpPostResponseAsync(string url, string content, int timeOut, 
            Encoding encoding = null, 
            string contentType = "text/plain",
            Dictionary<string, string> headers = null)
        {
            HttpResponseMessage respone = null;

            using (HttpClient httpClient = new HttpClient()
            {
                MaxResponseContentBufferSize = 512000,
                Timeout = new TimeSpan(0, 0, 0, 0, timeOut)
            })
            {
                httpClient.DefaultRequestHeaders.Add("user-agent", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/36.0.1985.143 Safari/537.36");

                if (headers != null)
                {
                    foreach (var item in headers)
                    {
                        httpClient.DefaultRequestHeaders.Add(item.Key, item.Value);
                    }
                }

                respone = await httpClient.PostAsync(new Uri(url), new StringContent(content, encoding ?? Encoding.UTF8, contentType));
            }

            return respone;
        }

        /// <summary>
        /// 使用Post方法获取字符串结果
        /// </summary>
        /// <param name="url"></param>
        /// /// <param name="timeOut"></param>
        /// <param name="cookieContainer"></param>
        /// <param name="postStream"></param>
        /// <param name="fileDictionary">需要上传的文件，Key：对应要上传的Name，Value：本地文件名</param>
        /// <param name="encoding"></param>
        /// <param name="cer">证书，如果不需要则保留null</param>
        /// <param name="checkValidationResult">验证服务器证书回调自动验证</param>
        /// <param name="refererUrl"></param>
        /// <returns></returns>
        public static async Task<string> HttpPostAsync(string url,
            int timeOut,
            Stream postStream = null,
            CookieContainer cookieContainer = null,
            Dictionary<string, string> fileDictionary = null,
            string refererUrl = null,
            Encoding encoding = null,
            X509Certificate2 cer = null,
            bool checkValidationResult = false)
        {
            string str = string.Empty;

            await Task<string>.Factory.StartNew(() => str = "暂时未实现！");

            throw new NotImplementedException("暂时未实现！");
        }
        #endregion

        #endregion

        #region PUT

        #region 同步方法
        /// <summary>
        /// 使用Put方法获取字符串结果（没有加入Cookie）
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="content">内容</param>
        /// <param name="timeOut">超时时间</param>
        /// <param name="encoding">编码（默认UTF-8）</param>
        /// <returns></returns>
        public static string HttpPut(string url, Dictionary<string, string> content, int timeOut, Encoding encoding = null)
        {
            string result = string.Empty;

            using (HttpClient httpClient = new HttpClient()
            {
                MaxResponseContentBufferSize = 512000,
                Timeout = new TimeSpan(0, 0, 0, 0, timeOut)
            })
            {
                httpClient.DefaultRequestHeaders.Add("user-agent", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/36.0.1985.143 Safari/537.36");

                HttpResponseMessage response = httpClient.PutAsync(new Uri(url), new FormUrlEncodedContent(content)).Result;
                result = response.Content.ReadAsStringAsync().Result;
            }

            return result;
        }

        /// <summary>
        /// 使用Put方法获取字符串结果（没有加入Cookie）
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="content">内容</param>
        /// <param name="timeOut">超时时间</param>
        /// <param name="encoding">编码（默认UTF-8）</param>
        /// <returns></returns>
        public static string HttpPut(string url, Stream content, int timeOut, Encoding encoding = null)
        {
            string result = string.Empty;

            using (HttpClient httpClient = new HttpClient()
            {
                MaxResponseContentBufferSize = 512000,
                Timeout = new TimeSpan(0, 0, 0, 0, timeOut)
            })
            {
                httpClient.DefaultRequestHeaders.Add("user-agent", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/36.0.1985.143 Safari/537.36");

                HttpResponseMessage response = httpClient.PutAsync(new Uri(url), new StreamContent(content)).Result;
                result = response.Content.ReadAsStringAsync().Result;
            }

            return result;
        }

        /// <summary>
        /// 使用Put方法获取字符串结果（没有加入Cookie）
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="content">内容</param>
        /// <param name="timeOut">超时时间</param>
        /// <param name="encoding">编码（默认UTF-8）</param>
        /// <returns></returns>
        public static string HttpPut(string url, string content, int timeOut, Encoding encoding = null)
        {
            string result = string.Empty;

            using (HttpClient httpClient = new HttpClient()
            {
                MaxResponseContentBufferSize = 512000,
                Timeout = new TimeSpan(0, 0, 0, 0, timeOut)
            })
            {
                httpClient.DefaultRequestHeaders.Add("user-agent", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/36.0.1985.143 Safari/537.36");

                HttpResponseMessage response = httpClient.PutAsync(new Uri(url),
                    new StringContent(content, encoding ?? Encoding.UTF8))
                    .Result;
                result = response.Content.ReadAsStringAsync().Result;
            }

            return result;
        }

        /// <summary>
        /// 使用Put方法获取字符串结果（没有加入Cookie）
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="content">内容</param>
        /// <param name="timeOut">超时时间</param>
        /// <param name="encoding">编码（默认UTF-8）</param>
        /// <returns></returns>
        public static HttpResponseMessage HttpPutResponse(string url, 
            string content, 
            int timeOut, 
            Encoding encoding = null, 
            string contentType = "text/plain", 
            Dictionary<string, string> headers = null)
        {
            HttpResponseMessage respone = null;

            using (HttpClient httpClient = new HttpClient()
            {
                MaxResponseContentBufferSize = 512000,
                Timeout = new TimeSpan(0, 0, 0, 0, timeOut)
            })
            {
                httpClient.DefaultRequestHeaders.Add("user-agent", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/36.0.1985.143 Safari/537.36");

                if (headers != null && headers.Count > 0)
                {
                    foreach (var item in headers)
                    {
                        httpClient.DefaultRequestHeaders.Add(item.Key, item.Value);
                    }
                }

                respone =  httpClient.PutAsync(new Uri(url),
                    new StringContent(content, encoding ?? Encoding.UTF8, contentType))
                    .Result;
            }

            return respone;
        }

        /// <summary>
        /// 使用Put方法获取字符串结果
        /// </summary>
        /// <param name="url"></param>
        /// /// <param name="timeOut"></param>
        /// <param name="cookieContainer"></param>
        /// <param name="postStream"></param>
        /// <param name="fileDictionary">需要上传的文件，Key：对应要上传的Name，Value：本地文件名</param>
        /// <param name="encoding"></param>
        /// <param name="cer">证书，如果不需要则保留null</param>
        /// <param name="checkValidationResult">验证服务器证书回调自动验证</param>
        /// <param name="refererUrl"></param>
        /// <returns></returns>
        public static string HttpPut(string url,
            int timeOut,
            Stream postStream = null,
            CookieContainer cookieContainer = null,
            Dictionary<string, string> fileDictionary = null,
            string refererUrl = null,
            Encoding encoding = null,
            X509Certificate2 cer = null,
            bool checkValidationResult = false)
        {
            throw new NotImplementedException("暂时未实现！");
        }
        #endregion

        #region 异步方法
        /// <summary>
        /// 使用Put方法获取字符串结果（没有加入Cookie）
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="content">内容</param>
        /// <param name="timeOut">超时时间</param>
        /// <param name="encoding">编码（默认UTF-8）</param>
        /// <returns></returns>
        public static async Task<string> HttpPutAsync(string url, Dictionary<string, string> content, int timeOut, Encoding encoding = null)
        {
            string result = string.Empty;

            using (HttpClient httpClient = new HttpClient()
            {
                MaxResponseContentBufferSize = 512000,
                Timeout = new TimeSpan(0, 0, 0, 0, timeOut)
            })
            {
                httpClient.DefaultRequestHeaders.Add("user-agent", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/36.0.1985.143 Safari/537.36");

                HttpResponseMessage response = await httpClient.PutAsync(new Uri(url), new FormUrlEncodedContent(content));
                result = await response.Content.ReadAsStringAsync();
            }

            return result;
        }

        /// <summary>
        /// 使用Put方法获取字符串结果（没有加入Cookie）
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="content">内容</param>
        /// <param name="timeOut">超时时间</param>
        /// <param name="encoding">编码（默认UTF-8）</param>
        /// <returns></returns>
        public static async Task<string> HttpPutAsync(string url, Stream content, int timeOut, Encoding encoding = null)
        {
            string result = string.Empty;

            using (HttpClient httpClient = new HttpClient()
            {
                MaxResponseContentBufferSize = 512000,
                Timeout = new TimeSpan(0, 0, 0, 0, timeOut)
            })
            {
                httpClient.DefaultRequestHeaders.Add("user-agent", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/36.0.1985.143 Safari/537.36");

                HttpResponseMessage response = await httpClient.PutAsync(new Uri(url), new StreamContent(content));
                result = await response.Content.ReadAsStringAsync();
            }

            return result;
        }

        /// <summary>
        /// 使用Put方法获取字符串结果（没有加入Cookie）
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="content">内容</param>
        /// <param name="timeOut">超时时间</param>
        /// <param name="encoding">编码（默认UTF-8）</param>
        /// <returns></returns>
        public static async Task<string> HttpPutAsync(string url, string content, int timeOut, Encoding encoding = null)
        {
            string result = string.Empty;

            using (HttpClient httpClient = new HttpClient()
            {
                MaxResponseContentBufferSize = 512000,
                Timeout = new TimeSpan(0, 0, 0, 0, timeOut)
            })
            {
                httpClient.DefaultRequestHeaders.Add("user-agent", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/36.0.1985.143 Safari/537.36");

                HttpResponseMessage response = await httpClient.PutAsync(new Uri(url), new StringContent(content, encoding ?? Encoding.UTF8));
                result = await response.Content.ReadAsStringAsync();
            }

            return result;
        }

        /// <summary>
        /// 使用Put方法获取字符串结果（没有加入Cookie）
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="content">内容</param>
        /// <param name="timeOut">超时时间</param>
        /// <param name="encoding">编码（默认UTF-8）</param>
        /// <returns></returns>
        public static async Task<HttpResponseMessage> HttpPutResponseAsync(string url, string content, int timeOut, Encoding encoding = null, string contentType = "text/plain",
            Dictionary<string, string> headers = null)
        {
            HttpResponseMessage respone = null;

            using (HttpClient httpClient = new HttpClient()
            {
                MaxResponseContentBufferSize = 512000,
                Timeout = new TimeSpan(0, 0, 0, 0, timeOut)
            })
            {
                httpClient.DefaultRequestHeaders.Add("user-agent", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/36.0.1985.143 Safari/537.36");

                if (headers != null)
                {
                    foreach (var item in headers)
                    {
                        httpClient.DefaultRequestHeaders.Add(item.Key, item.Value);
                    }
                }

                respone = await httpClient.PutAsync(new Uri(url), new StringContent(content, encoding ?? Encoding.UTF8, contentType));
            }

            return respone;
        }

        /// <summary>
        /// 使用Put方法获取字符串结果
        /// </summary>
        /// <param name="url"></param>
        /// /// <param name="timeOut"></param>
        /// <param name="cookieContainer"></param>
        /// <param name="postStream"></param>
        /// <param name="fileDictionary">需要上传的文件，Key：对应要上传的Name，Value：本地文件名</param>
        /// <param name="encoding"></param>
        /// <param name="cer">证书，如果不需要则保留null</param>
        /// <param name="checkValidationResult">验证服务器证书回调自动验证</param>
        /// <param name="refererUrl"></param>
        /// <returns></returns>
        public static async Task<string> HttpPutAsync(string url,
            int timeOut,
            Stream postStream = null,
            CookieContainer cookieContainer = null,
            Dictionary<string, string> fileDictionary = null,
            string refererUrl = null,
            Encoding encoding = null,
            X509Certificate2 cer = null,
            bool checkValidationResult = false)
        {
            string str = string.Empty;

            await Task<string>.Factory.StartNew(() => str = "暂时未实现！");

            throw new NotImplementedException("暂时未实现！");
        }
        #endregion

        #endregion
    }
}
