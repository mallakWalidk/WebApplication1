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
    public class m_category_repoisitory : Im_category_repoisitory
    {
        private readonly IDBContext dbContext;
        public m_category_repoisitory(IDBContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public bool deleteone(int? id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("categoryid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            dbContext.dbConnection.ExecuteAsync("m_category_package.deleteone", parameter, commandType: CommandType.StoredProcedure);
            return true;
        }

        public List<m_category> getall()
        {
            IEnumerable<m_category> result = dbContext.dbConnection.Query<m_category>("m_category_package.getall", commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public m_category getbyid(int? id)
        {
            var parameter = new DynamicParameters();

            parameter.Add("categoryid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);


            IEnumerable<m_category> result = dbContext.dbConnection.Query<m_category>("m_category_package.getbyid", parameter, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();

        }

        public bool insertone(m_category category)
        {
            var parameter = new DynamicParameters();

            parameter.Add("name", category.name, dbType: DbType.String, direction: ParameterDirection.Input);


            var result = dbContext.dbConnection.ExecuteAsync("m_category_package.creatone", parameter, commandType: CommandType.StoredProcedure);

            return true;

        }

        public bool updateone(m_category category)
        {
            var parameter = new DynamicParameters();
            parameter.Add("categoryid", category.id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("cname", category.name, dbType: DbType.String, direction: ParameterDirection.Input);


            var result = dbContext.dbConnection.ExecuteAsync("m_category_package.updateone", parameter, commandType: CommandType.StoredProcedure);

            return true;

        }
    }
}
