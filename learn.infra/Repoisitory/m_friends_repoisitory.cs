using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Dapper;
using lear.core.data;
using lear.core.domain;
using lear.core.Repoisitory;

namespace learn.infra.Repoisitory
{
    public class m_friends_repoisitory : Im_friends_repoisitory
    {
        private readonly IDBContext dbContext;
        public m_friends_repoisitory(IDBContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public bool deleteone(int? id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("friendsid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            dbContext.dbConnection.ExecuteAsync("m_friends_package.deleteone", parameter, commandType: CommandType.StoredProcedure);
            return true;
        }

        public List<m_friends> getall()
        {
            IEnumerable<m_friends> result = dbContext.dbConnection.Query<m_friends>("m_friends_package.getall", commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public m_friends getbyfirstid(int? id)
        {
            var parameter = new DynamicParameters();

            parameter.Add("friendsid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);


            IEnumerable<m_friends> result = dbContext.dbConnection.Query<m_friends>("m_friends_package.getbyfirstid", parameter, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();

        }
        public m_friends getbysecondid(int? id)
        {
            var parameter = new DynamicParameters();

            parameter.Add("friendsid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);


            IEnumerable<m_friends> result = dbContext.dbConnection.Query<m_friends>("m_friends_package.getbysecondid", parameter, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();

        }


        public bool insertone(m_friends friends)
        {
            var parameter = new DynamicParameters();

            parameter.Add("firstuser", friends.firstuser, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("seconduser", friends.seconduser, dbType: DbType.Int32, direction: ParameterDirection.Input);


            var result = dbContext.dbConnection.ExecuteAsync("m_friends_package.creatone", parameter, commandType: CommandType.StoredProcedure);

            return true;

        }

       
    }
}

