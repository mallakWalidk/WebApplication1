using System;
using System.Collections.Generic;
using System.Text;

namespace lear.core.data
{
    public class m_group_message
    {
        public int id { get; set; }
        public int group_id { get; set; }
        public int user_id { get; set; }
        public string message { get; set; }
        public DateTime msg_date { get; set; }
    }
}
