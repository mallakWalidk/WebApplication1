using lear.core.data;
using lear.core.Repoisitory;
using lear.core.service;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.infra.service
{
    public class m_visa_service: Im_visa_service
    {
        private readonly Im_visa_repoisitory repo;

        public m_visa_service(Im_visa_repoisitory repo)
        {
            this.repo = repo;
        }
        public bool deleteone(int? id)
        {
            return repo.deleteone(id);
        }

        public List<m_visa> getall()
        {
            return repo.getall();
        }

        public m_visa getbyid(int? id)
        {
            return repo.getbyid(id);
        }

        public bool insertone(m_visa visa)
        {
            return repo.insertone(visa);
        }

        public bool updateone(m_visa visa)
        {
            return repo.updateone(visa);
        }
    }
}
