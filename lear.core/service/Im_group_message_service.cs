using System;
using System.Collections.Generic;
using System.Text;
using lear.core.data;

namespace lear.core.service
{
    public interface Im_group_message_service
    {
        public List<m_group_message> getall();
        public bool insertone(m_group_message group_message);
        public bool updateone(m_group_message group_message);
        public bool deleteone(int? id);
        public m_group_message getbyid(int? id);

    }
}
