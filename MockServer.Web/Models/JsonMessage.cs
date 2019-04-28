using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MockServer.Web.Models
{
    public class JsonMessage
    {

        public JsonMessage(dynamic obj)
        {
            this.Data = obj;
        }

        public JsonMessage()
        {

        }

        public string Message { get; set; } = string.Empty;

        public MsgType Type { get; set; } = MsgType.Info;

        public bool Result { get; set; } = true;

        public dynamic Data { get; set; } = default(dynamic);

        public enum MsgType
        {
            /// <summary>
            /// 操作成功
            /// </summary>
            Success,

            /// <summary>
            /// 正常信息
            /// </summary>
            Info,

            /// <summary>
            /// 警告
            /// </summary>
            Warn,

            /// <summary>
            /// 错误,异常等
            /// </summary>
            Error,

            /// <summary>
            /// 访问拒绝
            /// </summary>
            AccessDeny
        }

        public static string GetErrorMsg(ModelStateDictionary modelState)
        {
            if (!modelState.IsValid)
            {
                return modelState.Where(m => m.Value.Errors.Any()).Select(error => error.Value.Errors.First().ErrorMessage).First();
            }
            else
            {
                return string.Empty;
            }
        }
    }
}