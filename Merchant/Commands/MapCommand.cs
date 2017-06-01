using System;
using System.Collections.Generic;
using System.Text;

namespace Merchant.Commands
{
    public class MapCommand : Command
    {
        public MapCommand(string from, string to)
        {
            From = from;
            To = to;
        }
        public string From { get; set; }
        public string To { get; set; }
        public override string ToString()
        {
            return string.Format("{0} is {1}", From, To);
        }
    }
}
