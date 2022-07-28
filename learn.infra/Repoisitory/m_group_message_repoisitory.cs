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
    public class m_group_message_repoisitory : Im_group_message_repoisitory
    {
        private readonly IDBContext dbContext;
        public m_group_message_repoisitory(IDBContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public bool deleteone(int? id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("group_messageid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            dbContext.dbConnection.ExecuteAsync("m_group_message_package.deleteone", parameter, commandType: CommandType.StoredProcedure);
            return true;
        }

        public List<m_group_message> getall()
        {
            IEnumerable<m_group_message> result = dbContext.dbConnection.Query<m_group_message>("m_group_message_package.getall", commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public m_group_message getbyid(int? id)
        {
            var parameter = new DynamicParameters();

            parameter.Add("group_messageid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);


            IEnumerable<m_group_message> result = dbContext.dbConnection.Query<m_group_message>("m_group_message_package.getbyid", parameter, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();

        }

        public bool insertone(m_group_message group_message)
        {
            var parameter = new DynamicParameters();

            parameter.Add("group_id", group_message.group_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("message", group_message.message, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("msg_date", group_message.msg_date, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            parameter.Add("user_id", group_message.user_id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.dbConnection.ExecuteAsync("m_group_message_package.creatone", parameter, commandType: CommandType.StoredProcedure);

            return true;

        }

        public bool updateone(m_group_message group_message)
        {
            var parameter = new DynamicParameters();
            parameter.Add("group_idd", group_message.group_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("user_idd", group_message.user_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("messagee", group_message.message, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("msg_datee", group_message.msg_date, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            parameter.Add("group_messageid", group_message.id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.dbConnection.ExecuteAsync("m_group_message_package.updateone", parameter, commandType: CommandType.StoredProcedure);


            return true;

        }

    }
}
