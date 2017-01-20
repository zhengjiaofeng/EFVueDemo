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
    public class SendCode
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
                await content.LoadIntoBufferAsync();
                //var content = new FormUrlEncodedContent(dc);

                var response = http.PostAsync(url, content).Result;

                ////await异步读取最后的JSON
                returnValue = response.Content.ReadAsStringAsync().Result;


            }
            var responseRes = JsonConvert.DeserializeObject<ApiSmsResponseResult>(returnValue);
            return responseRes;
        }

        public Task<ApiSmsResponseResult> SendSmsCode(string strPhone, string msg)
        {
            // var dc = new System.Collections.Generic.List<Dictionary<string,string>>();
            ApiSmsRequest<object> reques = new ApiSmsRequest<object>();
            reques.tel.phone = strPhone;
            reques.tel.nationcode = "86";
            reques.type = "0";
            reques.msg = msg;
            reques.sig = stringMD5(strAppkey + strPhone);
            reques.extend = "";
            reques.ext = string.Empty;
            
            //var dc =   JsonConvert.SerializeObject(reques);
            Models.telModel<string> a = new Models.telModel<string>();
            a.nationcode = "86";
            a.phone = strPhone;

            //  List<object> telList = new  List<object>();
            // telList.Add(a);

            //var dc1 = new Dictionary<string, object>()
            //{
            //    {"tel", a},
            //    {"msg",msg},
            //    {"sig",stringMD5(reques.tel.phone)},
            //    {"ext","xx"}
            //};
            var dc = JsonConvert.SerializeObject(reques);
            return GetRquestApiRes<object>("https://yun.tim.qq.com/v3/tlssmssvr/sendsms", dc);

        }

        private static string stringMD5(string input)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] targetData = md5.ComputeHash(System.Text.Encoding.UTF8.GetBytes(input));
            return byteToHexStr(targetData);
        }

        // 将二进制的数值转换为 16 进制字符串，如 "abc" => "616263"
        private static string byteToHexStr(byte[] input)
        {
            string returnStr = "";
            if (input != null)
            {
                for (int i = 0; i < input.Length; i++)
                {
                    returnStr += input[i].ToString("x2");
                }
            }
            return returnStr;
        }

    }


}