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
    public class m_service_repoisitory : Im_service_repoisitory
    {
        private readonly IDBContext dbContext;
        public m_service_repoisitory(IDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public List<total_service> total_services()
        {
            IEnumerable<total_service> result = dbContext.dbConnection.Query<total_service>("m_service_package.total", commandType: CommandType.StoredProcedure);

            return result.ToList();

        }

        public bool deleteone(int? id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("serviceid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            dbContext.dbConnection.ExecuteAsync("m_service_package.deleteone", parameter, commandType: CommandType.StoredProcedure);
            return true;
        }

        public List<m_service> getall()
        {
            IEnumerable<m_service> result = dbContext.dbConnection.Query<m_service>("m_service_package.getall", commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public m_service getbyid(int? id)
        {
            var parameter = new DynamicParameters();

            parameter.Add("serviceid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);


            IEnumerable<m_service> result = dbContext.dbConnection.Query<m_service>("m_service_package.getbyid", parameter, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();

        }

        public bool insertone(m_service service)
        {
            var parameter = new DynamicParameters();

            parameter.Add("name", service.name, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("price", service.price, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("category_id", service.category_id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.dbConnection.ExecuteAsync("m_service_package.insertone", parameter, commandType: CommandType.StoredProcedure);

            return true;

        }

        public bool updateone(m_service service)
        {
            var parameter = new DynamicParameters();
            parameter.Add("serviceid", service.id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("name", service.name, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("price", service.price, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("category_id", service.category_id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.dbConnection.ExecuteAsync("m_service_package.creatone", parameter, commandType: CommandType.StoredProcedure);


            return true;

        }

    }
}
