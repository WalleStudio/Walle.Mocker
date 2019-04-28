using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace MockServer.Common.External
{
    /// <summary>
    ///  Newtonsoft.Json;
    /// </summary>
    public static class JsonExtHelper
    {
        static JsonExtHelper()
        {

        }

        /// <summary>
        /// 将指定的对象序列化成 JSON 数据。
        /// </summary>
        /// <param name="obj">要序列化的对象。</param>
        /// <returns></returns>
        public static string ToJson(this object obj)
        {
            try
            {
                if (null == obj)
                    return null;
                return JsonConvert.SerializeObject(obj);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static string ToJson(this NameValueCollection source)
        {
            if (source != null && source.HasKeys())
            {
                var result = source?.ToDictionary();
                return result?.ToJson();
            }
            else
            {
                return string.Empty;
            }
        }

        public static string ToJson(this HttpCookieCollection source)
        {
            if (source != null && source.AllKeys != null && source.AllKeys.Any())
            {
                var result = source.AllKeys?.ToDictionary(k => k, k => source[k]?.Values?.ToDictionary());
                return result?.ToJson();
            }
            else
            {
                return string.Empty;
            }
        }

        public static string ObjectToJSON<T>(T t)
        {
            return JsonConvert.SerializeObject(t);
        }

        public static T JSONToObject<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        public static object JSONToObject(string json, Type type)
        {
            return JsonConvert.DeserializeObject(json, type);
        }

        /// <summary>
        /// 反序列化为对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="json">json</param>
        /// <returns></returns>
        public static T ToObject<T>(this string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        /// <summary>
        /// 将JSON转换为DataTable
        /// </summary>
        /// <param name="JsonString"></param>
        /// <returns></returns>
        public static DataTable JsonToDataTable(string strJson)
        {

            DataTable tb = null;

            //获取数据
            Regex rg = new Regex(@"(?<={)[^}]+(?=})");
            MatchCollection mc = rg.Matches(strJson);
            for (int i = 0; i < mc.Count; i++)
            {
                string strRow = mc[i].Value;
                string[] strRows = strRow.Split(',');

                //创建表
                if (tb == null)
                {
                    tb = new DataTable();
                    //tb.TableName = strName;
                    foreach (string str in strRows)
                    {
                        DataColumn dc = new DataColumn();
                        string[] strCell = str.Split(':');
                        dc.ColumnName = strCell[0].ToString();
                        tb.Columns.Add(dc);
                    }
                    tb.AcceptChanges();
                }

                //增加内容
                DataRow dr = tb.NewRow();
                for (int r = 0; r < strRows.Length; r++)
                {
                    dr[r] = strRows[r].Split(':')[1].Trim().Replace("，", ",").Replace("：", ":").Replace("/", "").Replace("\"", "");
                }
                tb.Rows.Add(dr);
                tb.AcceptChanges();
            }

            return tb;
        }

    }
}
