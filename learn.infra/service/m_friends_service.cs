using lear.core.data;
using lear.core.Repoisitory;
using lear.core.service;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.infra.service
{
    public class m_friends_service: Im_friends_service
    {
        private readonly Im_friends_repoisitory repo;

        public m_friends_service(Im_friends_repoisitory repo)
        {
            this.repo = repo;
        }
        public bool deleteone(int? id)
        {
            return repo.deleteone(id);
        }

        public List<m_friends> getall()
        {
            return repo.getall();
        }

        public m_friends getbyfirstid(int? id)
        {
            return repo.getbyfirstid(id);
        }



        public m_friends getbysecondid(int? id)
        {
            return repo.getbysecondid(id);
        }

        public bool insertone(m_friends friends)
        {
            return repo.insertone(friends);
        }

    }
}
