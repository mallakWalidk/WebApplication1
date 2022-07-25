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
    public class m_post_repoisitory : Im_post_repoisitory
    {
        private readonly IDBContext dbContext;
        public m_post_repoisitory(IDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<likes> count_likes()
        {
            IEnumerable<likes> result = dbContext.dbConnection.Query<likes>("m_post_package.likescount", commandType: CommandType.StoredProcedure);

            return result.ToList();

        }
        public bool deleteone(int? id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("postid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            dbContext.dbConnection.ExecuteAsync("m_post_package.deleteone", parameter, commandType: CommandType.StoredProcedure);
            return true;
        }

        public List<m_post> getall()
        {
            IEnumerable<m_post> result = dbContext.dbConnection.Query<m_post>("m_post_package.getall", commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public m_post getbyid(int? id)
        {
            var parameter = new DynamicParameters();

            parameter.Add("postid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);


            IEnumerable<m_post> result = dbContext.dbConnection.Query<m_post>("m_post_package.getbyid", parameter, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();

        }

        public bool insertone(m_post post)
        {
            var parameter = new DynamicParameters();

            parameter.Add("user_id", post.user_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("post_date", post.post_date, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            parameter.Add("post", post.post, dbType: DbType.String, direction: ParameterDirection.Input);


            var result = dbContext.dbConnection.ExecuteAsync("m_post_package.creatone", parameter, commandType: CommandType.StoredProcedure);

            return true;

        }

        public bool updateone(m_post post)
        {
            var parameter = new DynamicParameters();


            parameter.Add("postid", post.id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("user_id", post.user_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("post_date", post.post_date, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            parameter.Add("post", post.post, dbType: DbType.String, direction: ParameterDirection.Input);


            var result = dbContext.dbConnection.ExecuteAsync("m_post_package.updateone", parameter, commandType: CommandType.StoredProcedure);

            return true;

        }

    }
}
