using lear.core.data;
using lear.core.Repoisitory;
using lear.core.service;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.infra.service
{
    public class m_groups_service: Im_groups_service
    {
        private readonly Im_groups_repoisitory repo;

        public m_groups_service(Im_groups_repoisitory repo)
        {
            this.repo = repo;
        }
        public bool deleteone(int? id)
        {
            return repo.deleteone(id);
        }

        public List<m_groups> getall()
        {
            return repo.getall();
        }

        public m_groups getbyid(int? id)
        {
            return repo.getbyid(id);
        }

        public bool insertone(m_groups groups)
        {
            return repo.insertone(groups);
        }

        public bool updateone(m_groups groups)
        {
            return repo.updateone(groups);
        }
    }
}
