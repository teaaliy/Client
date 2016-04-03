using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Client
{
     [XmlRoot("ping")]
    class CommandPing : BaseCommand
    {
         public CommandPing() : base()
        {
            ID = 13;
        }
    }
}
