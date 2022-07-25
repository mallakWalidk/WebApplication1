using System;
using System.Collections.Generic;
using System.Text;
using lear.core.data;
using lear.core.DTO;

namespace lear.core.service
{
    public interface Im_purchased_services_service
    {

        public string buyservice(buy buy);
        public List<m_purchased_services> getall();
        public bool insertone(m_purchased_services purchased_services);
        public bool updateone(m_purchased_services purchased_services);
        public bool deleteone(int? id);
        public m_purchased_services getbyid(int? id);


    }
}
