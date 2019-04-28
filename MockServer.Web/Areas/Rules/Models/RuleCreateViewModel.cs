using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MockServer.Web.Areas.Rules.Models
{
    public class RuleCreateViewModel
    {
        public RuleCreateViewModel()
        {

        }
        #region private
        private string desc = string.Empty;
        private string requestContentType = string.Empty;
        private string responseContentType = string.Empty;
        private string requestBody = string.Empty;
        private string responseBody = string.Empty;
        private string matchPattern = string.Empty;
        #endregion

        /// <summary>
        /// 项目Id
        /// </summary>
        [Range(1, int.MaxValue, ErrorMessage = "缺少项目信息")]
        public long ProjectId { get; set; }

        /// <summary>
        /// 规则名称
        /// </summary>
        [Required(ErrorMessage = "请正确填写规则名称")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// 描述
        /// </summary>
        [MinLength(50,ErrorMessage ="不可以少于50字的描述")]
        public string Desc
        {
            get
            {
                return desc;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    desc = value;
                }
            }
        }

        /// <summary>
        /// 匹配模式 
        /// </summary>
        public string MatchPattern
        {
            get
            {
                return matchPattern;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    matchPattern = value;
                }
            }
        }

        [HttpUrls(ErrorMessage = "请正确填写Url")]
        public List<string> Urls { get; set; } = new List<string>();
        public string RequestMethod { get; set; } = string.Empty;
        public string RequestBody
        {
            get
            {
                return requestBody;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    requestBody = value;
                }
            }
        }
        public string RequestContentType
        {
            get
            {
                return requestContentType;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    requestContentType = value;
                }
            }
        }
        [HttpHeaders(ErrorMessage = "请正确填写请求header键值对")]
        public List<Header> RequestHeaders { get; set; } = new List<Header>();
        public string ResponseBody
        {
            get
            {
                return responseBody;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    responseBody = value;
                }
            }
        }
        public string ResponseContentType
        {
            get
            {
                return responseContentType;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    responseContentType = value;
                }
            }
        }

        [Range(200, int.MaxValue)]
        public int ResponseStatusCode { get; set; } = 0;

        [HttpHeaders(ErrorMessage = "请正确填写请求header键值对")]
        public List<Header> ResponseHeaders { get; set; } = new List<Header>();



        public class Header
        {
            public string Key { get; set; } = string.Empty;
            public string Value { get; set; } = string.Empty;
        }
        public sealed class HttpHeadersAttribute : ValidationAttribute
        {
            public HttpHeadersAttribute()
            {

            }
            public override bool IsValid(object value)
            {
                var target = value as List<Header>;
                if (target == null)
                {
                    return false;
                }
                else if (target.Any())
                {
                    foreach (var item in target)
                    {
                        if (string.IsNullOrEmpty(item.Key) || string.IsNullOrEmpty(item.Value))
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
        }
        public sealed class HttpUrlsAttribute : ValidationAttribute
        {
            UrlAttribute urlCheck = new UrlAttribute();
            public override bool IsValid(object value)
            {
                var target = value as List<string>;
                if (target == null)
                {
                    return false;
                }
                else if (target.Any())
                {
                    foreach (var item in target)
                    {
                        if (!urlCheck.IsValid(item))
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
        }
    }
}