using lear.core.data;
using lear.core.DTO;
using lear.core.Repoisitory;
using lear.core.service;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.infra.service
{
    public class m_message_service: Im_message_service
    {
        private readonly Im_message_repoisitory repo;

        public m_message_service(Im_message_repoisitory repo)
        {
            this.repo = repo;
        }
        public int messagecount()
        {
            return repo.messagecount();
        }

        public List<m_message> search(DateTime first,DateTime second)
        {
            return repo.search( first, second);
        }

        public List<m_message> filter(string msg)
        {
            return repo.filter(msg);
        }
        public List<msgcount> usermsgcount()
        {
            return repo.usermsgcount();
        }
        public bool deleteone(int? id)
        {
            return repo.deleteone(id);
        }

        public List<m_message> getall()
        {
            return repo.getall();
        }

        public m_message getbyid(int? id)
        {
            return repo.getbyid(id);
        }

        public bool insertone(m_message message)
        {
            return repo.insertone(message);
        }

    }
}
