using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.Windows.Forms;

namespace Client
{
    [XmlRoot("response")]
    public class CommandResponse : BaseCommand
    {
        string result;
        string text;

        public CommandResponse() : base()
        {
            ID = 1;
        }

        [XmlElement("text")]
        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        [XmlAttribute("result")]
        public string Result
        {
            get { return result; }
            set { result = value; }
        }
    }
}
