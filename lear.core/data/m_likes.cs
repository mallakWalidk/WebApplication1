using System;
using System.Collections.Generic;
using System.Text;

namespace lear.core.data
{
    public class m_likes
    {
        public int id { get; set; }
        public DateTime like_date { get; set; }
        public int post_id { get; set; }
        public int user_id { get; set; }
    }
}
