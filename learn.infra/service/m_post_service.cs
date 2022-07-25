using lear.core.data;
using lear.core.DTO;
using lear.core.Repoisitory;
using lear.core.service;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.infra.service
{
    public class m_post_service: Im_post_service
    {
        private readonly Im_post_repoisitory repo;

        public m_post_service(Im_post_repoisitory repo)
        {
            this.repo = repo;
        }
        public List<likes> count_likes()
        {
            return repo.count_likes();
        }

        public bool deleteone(int? id)
        {
            return repo.deleteone(id);
        }

        public List<m_post> getall()
        {
            return repo.getall();
        }

        public m_post getbyid(int? id)
        {
            return repo.getbyid(id);
        }

        public bool insertone(m_post post)
        {
            return repo.insertone(post);
        }

        public bool updateone(m_post post)
        {
            return repo.updateone(post);
        }
    }
}
