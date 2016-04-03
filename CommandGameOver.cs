using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Client
{
    [XmlRoot("game_over")]
    public class CommandGameOver : BaseCommand
    {
        int result;

        public CommandGameOver() : base()
        {
            ID = 11;
        }

        [XmlElement("result")]
        public int Result
        {
            get { return result; }
            set { result = value; }
        }

    }
}
