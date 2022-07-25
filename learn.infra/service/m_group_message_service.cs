using lear.core.data;
using lear.core.Repoisitory;
using lear.core.service;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.infra.service
{
    public class m_group_message_service: Im_group_message_service
    {
        private readonly Im_group_message_repoisitory repo;

        public m_group_message_service(Im_group_message_repoisitory repo)
        {
            this.repo = repo;
        }
        public bool deleteone(int? id)
        {
            return repo.deleteone(id);
        }

        public List<m_group_message> getall()
        {
            return repo.getall();
        }

        public m_group_message getbyid(int? id)
        {
            return repo.getbyid(id);
        }

        public bool insertone(m_group_message group_message)
        {
            return repo.insertone(group_message);
        }

        public bool updateone(m_group_message group_message)
        {
            return repo.updateone(group_message);
        }
    }
}
