using lear.core.data;
using lear.core.DTO;
using lear.core.Repoisitory;
using lear.core.service;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.infra.service
{
    public class m_likes_service: Im_likes_service
    {
        private readonly Im_likes_repoisitory repo;

        public m_likes_service(Im_likes_repoisitory repo)
        {
            this.repo = repo;
        }
        public bool deleteone(int? id)
        {
            return repo.deleteone(id);
        }
        public List<m_likes> getall()
        {
            return repo.getall();
        }

        public m_likes getbyid(int? id)
        {
            return repo.getbyid(id);
        }

        public bool insertone(m_likes likes)
        {
            return repo.insertone(likes);
        }

    }
}
