using MyLearn.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MyLearn.Content
{
    public class SendPhoneCode
    {
        private readonly string strAppkey = "aee50817497a972c1f9df712d365d82e";
        private readonly string strSdkAppId = "1400018046";
        private async Task<ApiSmsResponseResult> GetRquestApiRes<T>(string targetUrl, string dc) where T : class
        {

          //  var sign = SignatureHelper.GetSignature(dc);
            var url = targetUrl + "?sdkappid=" + strSdkAppId;
            var handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip };
            var returnValue = "";
            using (var http = new HttpClient(handler))
            {
                /*
                //var content = new FormUrlEncodedContent(dc);
                var content = new StringContent(dc, System.Text.Encoding.UTF8);
                //   var response = await http.PostAsync(url, content);
                var response = http.PostAsync(url, content).Result;

                //确保HTTP成功状态值 签名失败403
                //response.EnsureSuccessStatusCode();
                //await异步读取最后的JSON
                returnValue = await response.Content.ReadAsStringAsync();*/

                var contentStr = dc;
                var content = new StringContent(contentStr, Encoding.UTF8);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json") { CharSet = "utf-8" };
                 await  content.LoadIntoBufferAsync();
                //var content = new FormUrlEncodedContent(dc);

                var response = http.PostAsync(url, content).Result;

                //await异步读取最后的JSON
                returnValue = response.Content.ReadAsStringAsync().Result;


            }
            var responseRes = JsonConvert.DeserializeObject<ApiSmsResponseResult>(returnValue);
            return responseRes;
        }


        public string GetSign(string strPhone)
        {
            //string sign = Md5Sign(strAppkey, strPhone, "utf-8");
            string sign = Md5Hex(strAppkey + strPhone);
            return sign;
        }

        public  Task<ApiSmsResponseResult> SendSmsCode(string strPhone,string msg)
        {
           // var dc = new System.Collections.Generic.List<Dictionary<string,string>>();
            ApiSmsRequest<object> reques = new ApiSmsRequest<object>();
            reques.tel.phone = strPhone;
            reques.tel.nationcode = "86";
            reques.msg = msg;
            reques.sig = GetSign(reques.tel.phone);
            reques.ext = string.Empty;
            //var dc =   JsonConvert.SerializeObject(reques);
            Models.telModel<string> a = new Models.telModel<string>();
            a.nationcode = "86";
            a.phone = strPhone;

          //  List<object> telList = new  List<object>();
           // telList.Add(a);

            var dc1 = new Dictionary<string, object>()
            {
                {"tel", a},
                {"msg",msg},
                {"sig",GetSign(reques.tel.phone)},
                {"ext","xx"}
            };
            var dc = JsonConvert.SerializeObject(dc1);
            return GetRquestApiRes<object>("https://yun.tim.qq.com/v3/tlssmssvr/sendsms", dc);

        }

        /// <summary>
        /// 签名字符串
        /// </summary>
        /// <param name="prestr">需要签名的字符串</param>
        /// <param name="key">密钥</param>
        /// <param name="_input_charset">编码格式</param>
        /// <returns>签名结果</returns>
        public static string Md5Sign(string prestr, string key, string _input_charset)
        {
            StringBuilder sb = new StringBuilder(32);

            prestr = prestr + key;

            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] t = md5.ComputeHash(Encoding.GetEncoding(_input_charset).GetBytes(prestr));
            for (int i = 0; i < t.Length; i++)
            {
                sb.Append(t[i].ToString("x").PadLeft(2, '0'));
            }

            return sb.ToString();
        }

        private static string Md5Hex(string data)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] dataHash = md5.ComputeHash(Encoding.UTF8.GetBytes(data));
            StringBuilder sb = new StringBuilder();
            foreach (byte b in dataHash)
            {
                sb.Append(b.ToString("x2").ToLower());
            }
            //Console.WriteLine(sb.ToString());
            return sb.ToString();
        }
    }
}