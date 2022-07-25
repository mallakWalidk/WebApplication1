using lear.core.data;
using System;
using System.Collections.Generic;
using System.Text;

namespace lear.core.Repoisitory
{
    public interface Im_category_repoisitory
    {
        public List<m_category> getall();
        public bool insertone(m_category category);
        public bool updateone(m_category category);
        public bool deleteone(int? id);
        public m_category getbyid(int? id);

    }
}
