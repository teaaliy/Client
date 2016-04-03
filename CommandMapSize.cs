using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;

namespace Client
{
    [XmlRoot("map_size")]
    public class CommandMapSize : BaseCommand
    {
        int width;
        int height;

        public CommandMapSize() : base()
        {
            ID = 7;
        }
        [XmlElement("width")]
        public int Width
        {
            get { return width; }
            set { width = value; }
        }

        [XmlElement("height")]
        public int Height
        {
            get { return height; }
            set { height = value; }
        }
    }
}
