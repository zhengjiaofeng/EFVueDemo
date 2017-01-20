using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyLearn.Models
{
    public class ApiSmsResponseResult
    {
        [JsonProperty("result")]
        //public List<>
        /// <summary>
        /// 非0表示失败
        /// </summary>
        public string result { get; set; }

        [JsonProperty("errmsg")]
        /// <summary>
        /// result非0时的具体错误信息
        /// </summary>
        public string errmsg { get; set; }

        [JsonProperty("ext")]
        /// <summary>
        /// 用户的session内容，腾讯server回包中会原样返回
        /// </summary>
        public string ext { get; set; }

        [JsonProperty("sid")]
        /// <summary>
        /// 标识本次发送id
        /// </summary>
        public string sid { get; set; }

        [JsonProperty("fee")]
        /// <summary>
        /// 短信计费的条数
        /// </summary>
        public int fee { get; set; } 
    }

    public class ApiSmsRequest<T> where T : class
    {
        private telModel<T> _tel = new telModel<T>();
        public telModel<T> tel
        {
            get
            {
                return _tel;
            }
            set
            {
                value = _tel;
            }
        }
        [JsonProperty("type")]
        /// <summary>
        /// 0:普通短信;1:营销短信
        /// </summary>
        public string type { get; set; }

        [JsonProperty("msg")]
        /// <summary>
        /// 验证码,utf8编码
        /// </summary>
        public string msg { get; set; }

        [JsonProperty("sig")]
        /// <summary>
        /// app凭证
        /// </summary>
        public string sig { get; set; }

        [JsonProperty("extend")]
        /// <summary>
        /// 可选字段，默认没有开通(需要填空)。通道扩展码，在短信回复场景中，腾讯server会原样返回，开发者可依此区分是哪种类型的回复
        /// </summary>
        public string extend { get; set; }

        [JsonProperty("ext")]
        /// <summary>
        /// 可选字段，用户的session内容,腾讯server回包中会原样返回
        /// </summary>
        public string ext { get; set; }

    }

    public class telModel<T> where T : class
    {
        [JsonProperty("nationcode")]
        /// <summary>
        /// 国家码
        /// </summary>
        public string nationcode { get; set; }

        [JsonProperty("phone")]
        /// <summary>
        /// 手机号码
        /// </summary>
        public string phone { get; set; }
    }
}