using System;
using System.Collections.Generic;
using System.Text;
using lear.core.data;
using lear.core.DTO;

namespace lear.core.Repoisitory
{
    public interface Im_service_repoisitory
    {
        public List<total_service> total_services();
        public List<m_service> getall();
        public bool insertone(m_service service);
        public bool updateone(m_service service);
        public bool deleteone(int? id);
        public m_service getbyid(int? id);

    }
}
