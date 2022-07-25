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
    public class m_purchased_services_repoisitory : Im_purchased_services_repoisitory
    {

        private readonly IDBContext dbContext;
        public m_purchased_services_repoisitory(IDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public string buyservice(buy buy)
        {
            var parameter = new DynamicParameters();

            parameter.Add("visaid", buy.serial_number, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("cvv", buy.cvv, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("month", buy.month, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("year", buy.year, dbType: DbType.Int32, direction: ParameterDirection.Input);


            IEnumerable<m_visa> result = dbContext.dbConnection.Query<m_visa>("m_visa_package.checkvisa", parameter, commandType: CommandType.StoredProcedure);
            if (result.Any())
            {
                //get the visa info
                var result2 = result.FirstOrDefault();

                var parameter1 = new DynamicParameters();
                parameter1.Add("servicename", buy.servicename, dbType: DbType.String, direction: ParameterDirection.Input);
                //get the service
                var sresult = dbContext.dbConnection.Query<m_service>("m_service_package.getbyname", parameter1, commandType: CommandType.StoredProcedure).FirstOrDefault();

                if (result2.balance >= sresult.price)
                {
                    m_purchased_services news = new m_purchased_services();
                    news.user_id = buy.user_id;
                    news.service_id = sresult.id;
                    news.buydate = DateTime.Now;
                    insertone(news);
                    return "purchased is done";
                }
                else
                    return "balance is not enough";

            }
            else
                return "visa information is not correct";
        }


        public bool deleteone(int? id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("purchased_servicesid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            dbContext.dbConnection.ExecuteAsync("m_purchased_services_package.deleteone", parameter, commandType: CommandType.StoredProcedure);
            return true;
        }

        public List<m_purchased_services> getall()
        {
            IEnumerable<m_purchased_services> result = dbContext.dbConnection.Query<m_purchased_services>("m_purchased_services_package.getall", commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public m_purchased_services getbyid(int? id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("purchased_servicesid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<m_purchased_services> result = dbContext.dbConnection.Query<m_purchased_services>("m_purchased_services_package.getbyid", parameter, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();

        }

        public bool insertone(m_purchased_services purchased_services)
        {
            var parameter = new DynamicParameters();

            parameter.Add("user_id", purchased_services.user_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("service_id", purchased_services.service_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("buydate", purchased_services.buydate, dbType: DbType.DateTime, direction: ParameterDirection.Input);

            var result = dbContext.dbConnection.Execute("m_purchased_services_package.creatone", parameter, commandType: CommandType.StoredProcedure);

            return true;

        }

        public bool updateone(m_purchased_services purchased_services)
        {
            var parameter = new DynamicParameters();


            parameter.Add("purchased_servicesid", purchased_services.id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("user_id", purchased_services.user_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("service_id", purchased_services.service_id, dbType: DbType.Int32, direction: ParameterDirection.Input);


            var result = dbContext.dbConnection.ExecuteAsync("m_purchased_services_package.creatone", parameter, commandType: CommandType.StoredProcedure);

            return true;

        }

    }
}
