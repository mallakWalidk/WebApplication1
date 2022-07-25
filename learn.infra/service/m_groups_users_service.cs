using lear.core.data;
using lear.core.Repoisitory;
using lear.core.service;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.infra.service
{
    public class m_groups_users_service: Im_groups_users_service
    {
        private readonly Im_groups_users_repoisitory repo;

        public m_groups_users_service(Im_groups_users_repoisitory repo)
        {
            this.repo = repo;
        }
        public string blockuser(m_block block)
        {
         return  repo.blockuser(block);
        }
        public string unblock(m_block block)
        {
            return repo.unblock(block);
        }

        public bool deleteone(int? id)
        {
            return repo.deleteone(id);
        }

        public List<m_groups_users> getall()
        {
            return repo.getall();
        }

        public m_groups_users getbyid(int? id)
        {
            return repo.getbyid(id);
        }

        public bool insertone(m_groups_users groups_users)
        {
            return repo.insertone(groups_users);
        }

        public bool updateone(m_groups_users groups_users)
        {
            return repo.updateone(groups_users);
        }
    }
}
