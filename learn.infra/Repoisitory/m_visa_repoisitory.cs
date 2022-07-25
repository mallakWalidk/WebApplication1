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
    public class m_visa_repoisitory : Im_visa_repoisitory
    {

        private readonly IDBContext dbContext;
        public m_visa_repoisitory(IDBContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public bool deleteone(int? id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("visaid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            dbContext.dbConnection.ExecuteAsync("m_visa_package.deleteone", parameter, commandType: CommandType.StoredProcedure);
            return true;
        }

        public List<m_visa> getall()
        {
            IEnumerable<m_visa> result = dbContext.dbConnection.Query<m_visa>("m_visa_package.getall", commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public m_visa getbyid(int? id)
        {
            var parameter = new DynamicParameters();

            parameter.Add("visaid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);


            IEnumerable<m_visa> result = dbContext.dbConnection.Query<m_visa>("m_visa_package.getbyid", parameter, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();

        }

        public bool insertone(m_visa visa)
        {
            var parameter = new DynamicParameters();
            parameter.Add("user_id", visa.user_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("cvv", visa.cvv, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("balance", visa.balance, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("month", visa.month, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("year", visa.year, dbType: DbType.Int32, direction: ParameterDirection.Input);



            var result = dbContext.dbConnection.ExecuteAsync("m_visa_package.creatone", parameter, commandType: CommandType.StoredProcedure);

            return true;

        }

        public bool updateone(m_visa visa)
        {
            var parameter = new DynamicParameters();
            parameter.Add("visaid", visa.serial_number, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("user_id", visa.user_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("cvv", visa.cvv, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("balance", visa.balance, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("month", visa.month, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("year", visa.year, dbType: DbType.Int32, direction: ParameterDirection.Input);


            var result = dbContext.dbConnection.ExecuteAsync("m_visa_package.updateone", parameter, commandType: CommandType.StoredProcedure);

            return true;



        }

    }
}

