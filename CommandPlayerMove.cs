using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Client
{
    public enum PlayerDirection { N, E, S, W }

    [XmlRoot("player_move")]
    public class CommandPlayerMove : BaseCommand
    {
        PlayerDirection direction;

        public CommandPlayerMove() : base()
        {
            ID = 10;
        }

        [XmlElement("direction")]
        public PlayerDirection Direction
        {
            get { return direction; }
            set { direction = value; }
        }
    }
}
