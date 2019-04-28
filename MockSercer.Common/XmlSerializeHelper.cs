using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace MockServer.Common 
{
    public class XmlSerializeHelper
    {
        public static string ObjectToXML(object o)
        {
            XmlSerializer ser = new XmlSerializer(o.GetType());
            MemoryStream mem = new MemoryStream();
            XmlTextWriter writer = new XmlTextWriter(mem, Encoding.UTF8);
            ser.Serialize(writer, o);
            writer.Close();
            return Encoding.UTF8.GetString(mem.ToArray());
        }

        public static object XMLToObject(string s, Type t)
        {
            XmlSerializer mySerializer = new XmlSerializer(t);
            StreamReader mem2 = new StreamReader(new MemoryStream(System.Text.Encoding.Default.GetBytes(s)), System.Text.Encoding.UTF8);
            return mySerializer.Deserialize(mem2);
        }

        /// <summary>
        /// 将object对象序列化成XML
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static string ObjectToXML<T>(T t)
        {
            return ClearSpecialCharForXml(ObjectToXML<T>(t, Encoding.UTF8));
        }

        /// <summary>
        /// 将object对象序列化成XML
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static string ObjectToXML<T>(T t, Encoding encoding)
        {
            XmlSerializer ser = new XmlSerializer(t.GetType());
            using (MemoryStream mem = new MemoryStream())
            {
                using (XmlTextWriter writer = new XmlTextWriter(mem, encoding))
                {
                    XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                    ns.Add("", "");
                    ser.Serialize(writer, t, ns);
                    return ClearSpecialCharForXml(encoding.GetString(mem.ToArray()));
                }
            }
        }

        /// <summary>
        /// 将XML反序列化成对象
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static T XMLToObject<T>(string source)
        {
            return XMLToObject<T>(source, Encoding.UTF8);
        }

        /// <summary>
        /// 将XML反序列化成对象
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static T XMLToObject<T>(string source, Encoding encoding)
        {
            XmlSerializer mySerializer = new XmlSerializer(typeof(T));
            using (MemoryStream stream = new MemoryStream(encoding.GetBytes(source)))
            {
                return (T)mySerializer.Deserialize(stream);
            }
        }

        /// <summary>
        /// 清理XML字符串左尖括号前面的多余字符
        /// </summary>
        /// <param name="xml">待处理的XML字符串</param>
        /// <returns></returns>
        /// <remarks> add by grs at 2012-10-16 </remarks>
        private static string ClearSpecialCharForXml(string xml)
        {
            if (string.IsNullOrEmpty(xml))
            {
                return string.Empty;
            }

            return System.Text.RegularExpressions.Regex.Replace(xml, "^[^<]*", "");
        }

    }
}
