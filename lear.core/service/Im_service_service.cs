using System;
using System.Collections.Generic;
using System.Text;
using lear.core.data;
using lear.core.DTO;

namespace lear.core.service
{
    public interface Im_service_service
    {
        public List<total_service> total_services();
        public List<m_service> getall();
        public bool insertone(m_service service);
        public bool updateone(m_service service);
        public bool deleteone(int? id);
        public m_service getbyid(int? id);

    }
}
