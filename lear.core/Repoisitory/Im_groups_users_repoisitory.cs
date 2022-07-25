using System;
using System.Collections.Generic;
using System.Text;
using lear.core.data;

namespace lear.core.Repoisitory
{
    public interface Im_groups_users_repoisitory
    {
        public string blockuser(m_block block);
        public string unblock(m_block block);

        public List<m_groups_users> getall();
        public bool insertone(m_groups_users groups_users);
        public bool updateone(m_groups_users groups_users);
        public bool deleteone(int? id);
        public m_groups_users getbyid(int? id);

    }
}
