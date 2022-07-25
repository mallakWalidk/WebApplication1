using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Dapper;
using lear.core.data;
using lear.core.domain;
using lear.core.DTO;
using lear.core.Repoisitory;

namespace learn.infra.Repoisitory
{
    public class m_likes_repoisitory : Im_likes_repoisitory
    {

        private readonly IDBContext dbContext;
        public m_likes_repoisitory(IDBContext dbContext)
        {
            this.dbContext = dbContext;
        }



        public bool deleteone(int? id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("likesid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            dbContext.dbConnection.ExecuteAsync("m_likes_package.deleteone", parameter, commandType: CommandType.StoredProcedure);
            return true;
        }

        public List<m_likes> getall()
        {
            IEnumerable<m_likes> result = dbContext.dbConnection.Query<m_likes>("m_likes_package.getall", commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public m_likes getbyid(int? id)
        {
            var parameter = new DynamicParameters();

            parameter.Add("likesid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);


            IEnumerable<m_likes> result = dbContext.dbConnection.Query<m_likes>("m_likes_package.getbyid", parameter, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();

        }

        public bool insertone(m_likes likes)
        {
            var parameter = new DynamicParameters();

            parameter.Add("like_date", likes.like_date, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            parameter.Add("post_id", likes.post_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("user_id", likes.user_id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.dbConnection.ExecuteAsync("m_likes_package.creatone", parameter, commandType: CommandType.StoredProcedure);

            return true;

        }



    }
}
