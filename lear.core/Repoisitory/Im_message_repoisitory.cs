using System;
using System.Collections.Generic;
using System.Text;
using lear.core.data;
using lear.core.DTO;

namespace lear.core.Repoisitory
{
    public interface Im_message_repoisitory
    {
        public List<m_message> getall();
        public bool insertone(m_message message);
        public bool deleteone(int? id);
        public int messagecount();
        public List<msgcount> usermsgcount();
        public List<m_message> search(DateTime first, DateTime second);
        public List<m_message> filter(string msg);

        public m_message getbyid(int? id);

    }
}
