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
    public class m_groups_repoisitory : Im_groups_repoisitory
    {
        private readonly IDBContext dbContext;
        public m_groups_repoisitory(IDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public bool deleteone(int? id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("groupsid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            dbContext.dbConnection.ExecuteAsync("m_groups_package.deleteone", parameter, commandType: CommandType.StoredProcedure);
            return true;
        }

        public List<m_groups> getall()
        {
            IEnumerable<m_groups> result = dbContext.dbConnection.Query<m_groups>("m_groups_package.getall", commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public m_groups getbyid(int? id)
        {
            var parameter = new DynamicParameters();

            parameter.Add("groupsid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);


            IEnumerable<m_groups> result = dbContext.dbConnection.Query<m_groups>("m_groups_package.getbyid", parameter, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();

        }

        public bool insertone(m_groups groups)
        {
            var parameter = new DynamicParameters();

            parameter.Add("groupname", groups.groupname, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = dbContext.dbConnection.ExecuteAsync("m_groups_package.creatone", parameter, commandType: CommandType.StoredProcedure);

            return true;

        }

        public bool updateone(m_groups groups)
        {
            var parameter = new DynamicParameters();
            parameter.Add("groupsid", groups.id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("name", groups.groupname, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = dbContext.dbConnection.ExecuteAsync("m_groups_package.creatone", parameter, commandType: CommandType.StoredProcedure);


            return true;

        }


    }
}
