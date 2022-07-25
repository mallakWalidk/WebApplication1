using lear.core.data;
using lear.core.DTO;
using lear.core.Repoisitory;
using lear.core.service;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.infra.service
{
    public class m_service_service : Im_service_service
    {
        private readonly Im_service_repoisitory repo;

        public m_service_service(Im_service_repoisitory repo)
        {
            this.repo = repo;
        }
        public List<total_service> total_services()
        {
            return repo.total_services();
        }
        public bool deleteone(int? id)
        {
            return repo.deleteone(id);
        }

        public List<m_service> getall()
        {
            return repo.getall();
        }

        public m_service getbyid(int? id)
        {
            return repo.getbyid(id);
        }

        public bool insertone(m_service service)
        {
            return repo.insertone(service);
        }

        public bool updateone(m_service service)
        {
            return repo.updateone(service);
        }
    }

}
