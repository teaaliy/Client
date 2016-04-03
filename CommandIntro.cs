using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Client
{
    [XmlRoot("player")]
    public class CommandIntro : BaseCommand
    {
        string name;

        public CommandIntro() : base()
        {
            ID = 2;
        }

        [XmlElement("name")]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

    }
}
