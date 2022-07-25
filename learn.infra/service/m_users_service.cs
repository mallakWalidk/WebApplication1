using lear.core.data;
using lear.core.DTO;
using lear.core.Repoisitory;
using lear.core.service;
using System;
using System.Collections.Generic;
using System.Text;

namespace learn.infra.service
{
    public class m_users_service : Im_users_service
    {
        private readonly Im_users_repoisitory repo;
        public m_users_service(Im_users_repoisitory repo)
        {
            this.repo = repo;
        }
        public List<ResultViewModel> weather()
        {
            return repo.weather();
        }

        public ResultViewModel weather(int id)
        {
            return repo.weather(id);
        }
        public bool insert5record(List<m_users> users)
        {
            return repo.insert5record(users);
        }
        public List<citycount> citycounts()
        {
            return repo.citycounts();
        }
        public List<visacount> visa_count()
        {
            return repo.visa_count();
        }
        public bool insertusers(string filename)
        {
            return repo.insertusers(filename);
        }
        public bool backup(int id)
        {
            return repo.backup(id);
                }
        public bool deleteone(int? id)
        {
            return repo.deleteone(id);
        }

        public List<m_users> getall()
        {
            return repo.getall();
        }

        public m_users getbyid(int? id)
        {
            return repo.getbyid(id);
        }

        public bool insertone(m_users users)
        {
            return repo.insertone(users);
        }

        public bool updateone(m_users users)
        {
            return repo.updateone(users);
        }
    }
}
