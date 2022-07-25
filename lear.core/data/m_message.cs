using System;
using System.Collections.Generic;
using System.Text;

namespace lear.core.data
{
    public class m_message
    {
        public int id { get; set; }
        public int sender { get; set; }
        public int receiver { get; set; }
        public string message { get; set; }
        public DateTime msg_date { get; set; }
    }
}
