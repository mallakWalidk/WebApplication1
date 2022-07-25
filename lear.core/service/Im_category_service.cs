using System;
using System.Collections.Generic;
using System.Text;
using lear.core.data;

namespace lear.core.service
{
    public interface Im_category_service
    {
        public List<m_category> getall();
        public bool insertone(m_category category);
        public bool updateone(m_category category);
        public bool deleteone(int? id);
        public m_category getbyid(int? id);


    }
}
