﻿using System;
using System.Collections.Generic;
using System.Text;
using lear.core.data;
using lear.core.DTO;

namespace lear.core.Repoisitory
{
    public interface Im_likes_repoisitory
    {
        public List<m_likes> getall();
        public bool insertone(m_likes likes);
        public bool deleteone(int? id);
        public m_likes getbyid(int? id);

    }
}
