using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Client
{
    [XmlRoot("time_left")]
    public class CommandTimeLeft : BaseCommand
    {
        //DateTime time;
        TimeSpan time;

        public CommandTimeLeft() : base()
        {
            ID = 5;
        }

        [XmlElement("time")]
        public double Time
        {
            get { return time.TotalMilliseconds; }
            set { time = TimeSpan.FromMilliseconds(value); }
        }

    }
}
