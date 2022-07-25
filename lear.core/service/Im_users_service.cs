using System;
using System.Collections.Generic;
using System.Text;
using lear.core.data;
using lear.core.DTO;

namespace lear.core.service
{
    public interface Im_users_service
    {
        public List<ResultViewModel> weather();
        public ResultViewModel weather(int id);
        public bool insert5record(List<m_users> users);
        public List<citycount> citycounts();
        public List<visacount> visa_count();
        public bool insertusers(string filename);
        public bool backup(int id);
        public List<m_users> getall();
        public bool insertone(m_users users);
        public bool updateone(m_users users);
        public bool deleteone(int? id);
        public m_users getbyid(int? id);

    }
}
