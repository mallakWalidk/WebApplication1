using System;
using System.Collections.Generic;
using System.Text;
using lear.core.data;

namespace lear.core.service
{
    public interface Im_friends_service
    {
        public List<m_friends> getall();
        public bool insertone(m_friends friends);
        public bool deleteone(int? id);
        public m_friends getbyfirstid(int? id);
        public m_friends getbysecondid(int? id);

    }
}
