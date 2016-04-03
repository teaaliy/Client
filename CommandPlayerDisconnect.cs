using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Client
{
    [XmlRoot("player_disconnect")]
    class CommandPlayerDisconnect : BaseCommand
    {
        public CommandPlayerDisconnect() : base()
        {
            ID = 12;
        }
    }
}
