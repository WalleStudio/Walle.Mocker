using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace MockServer.Common.External
{
    public static class XmlSerializeExtHelper
    {

        public static string ToXml(this object o)
        {
            XmlSerializer ser = new XmlSerializer(o.GetType());
            MemoryStream mem = new MemoryStream();
            XmlTextWriter writer = new XmlTextWriter(mem, Encoding.UTF8);
            ser.Serialize(writer, o);
            writer.Close();
            return Encoding.UTF8.GetString(mem.ToArray());
        }

    }
}
