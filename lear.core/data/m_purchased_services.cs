using System;
using System.Collections.Generic;
using System.Text;

namespace lear.core.data
{
    public class m_purchased_services
    {
        public int id { get; set; }
        public int service_id { get; set; }
        public int user_id { get; set; }
        public DateTime buydate { get; set; }
    }
}
