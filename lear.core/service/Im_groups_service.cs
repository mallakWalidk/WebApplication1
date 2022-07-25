using System;
using System.Collections.Generic;
using System.Text;
using lear.core.data;

namespace lear.core.service
{
    public interface Im_groups_service
    {

        public List<m_groups> getall();
        public bool insertone(m_groups groups);
        public bool updateone(m_groups groups);
        public bool deleteone(int? id);
        public m_groups getbyid(int? id);

    }
}
