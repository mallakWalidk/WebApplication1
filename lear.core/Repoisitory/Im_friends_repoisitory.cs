using System;
using System.Collections.Generic;
using System.Text;
using lear.core.data;

namespace lear.core.Repoisitory
{
    public interface Im_friends_repoisitory
    {
        public List<m_friends> getall();
        public bool insertone(m_friends friends);
        public bool deleteone(int? id);
        public m_friends getbysecondid(int? id);
        public m_friends getbyfirstid(int? id);


    }
}
