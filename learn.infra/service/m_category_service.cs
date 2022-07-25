using lear.core.data;
using lear.core.Repoisitory;
using lear.core.service;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.infra.service
{
    public class m_category_service : Im_category_service
    {
        private readonly Im_category_repoisitory repo;

        public m_category_service(Im_category_repoisitory repo)
        {
            this.repo = repo;
        }
        public bool deleteone(int? id)
        {
           return repo.deleteone(id);
        }

        public List<m_category> getall()
        {
            return repo.getall();   
        }

        public m_category getbyid(int? id)
        {
            return repo.getbyid(id);
        }

        public bool insertone(m_category category)
        {
            return repo.insertone(category);
        }

        public bool updateone(m_category category)
        {
            return repo.updateone(category);
        }
    }
}
