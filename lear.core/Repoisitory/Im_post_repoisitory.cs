using System;
using System.Collections.Generic;
using System.Text;
using lear.core.data;
using lear.core.DTO;

namespace lear.core.Repoisitory
{
    public interface Im_post_repoisitory
    {
        public List<likes> count_likes();
        public List<m_post> getall();
        public bool insertone(m_post post);
        public bool updateone(m_post post);
        public bool deleteone(int? id);
        public m_post getbyid(int? id);

    }
}
