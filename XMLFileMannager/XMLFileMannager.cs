using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace XMLFileMannager
{
    public class XMLFileMannager
    {
        public string FileName {get; set;}

        public XMLFileMannager(string FileName="")
        {
            this.FileName = FileName;
        }

        //XML Module
        public string getConfigDataXML(string parent, string child)
        {
            try
            {
                XDocument opciones_xml = XDocument.Load(FileName);

                var tc = (from x in opciones_xml.Descendants(parent) select x.Element(child)).SingleOrDefault();

                if (tc != null)
                {
                    return tc.Value.ToString();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return string.Empty;
        }

        public void setConfigDataXML(string parent, string child, string value)
        {
            try
            {
                XDocument opciones_xml = XDocument.Load(FileName);
                var mv = from x in opciones_xml.Descendants(parent) select x;
                foreach (XElement x in mv)
                {
                    x.SetElementValue(child, value);
                }
                opciones_xml.Save(FileName);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
