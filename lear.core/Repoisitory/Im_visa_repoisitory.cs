using System;
using System.Collections.Generic;
using System.Text;
using lear.core.data;

namespace lear.core.Repoisitory
{
    public interface Im_visa_repoisitory
    {
        public List<m_visa> getall();
        public bool insertone(m_visa visa);
        public bool updateone(m_visa visa);
        public bool deleteone(int? id);
        public m_visa getbyid(int? id);

    }
}
