using lear.core.data;
using lear.core.DTO;
using lear.core.Repoisitory;
using lear.core.service;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.infra.service
{
    public class m_purchased_services_service: Im_purchased_services_service
    {
        private readonly Im_purchased_services_repoisitory repo;

        public m_purchased_services_service(Im_purchased_services_repoisitory repo)
        {
            this.repo = repo;
        }
        public string buyservice(buy buy)
        {
            return repo.buyservice(buy);
        }

        public bool deleteone(int? id)
        {
            return repo.deleteone(id);
        }

        public List<m_purchased_services> getall()
        {
            return repo.getall();
        }


        public m_purchased_services getbyid(int? id)
        {
            return repo.getbyid(id);
        }

        public bool insertone(m_purchased_services purchased_services)
        {
            return repo.insertone(purchased_services);
        }

        public bool updateone(m_purchased_services purchased_services)
        {
            return repo.updateone(purchased_services);
        }
    }
}
