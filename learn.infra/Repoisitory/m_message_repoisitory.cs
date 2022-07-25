using Dapper;
using lear.core.data;
using lear.core.domain;
using lear.core.DTO;
using lear.core.Repoisitory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace learn.infra.Repoisitory
{
    public class m_message_repoisitory : Im_message_repoisitory
    {

        private readonly IDBContext dbContext;
        public m_message_repoisitory(IDBContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public List<msgcount> usermsgcount()
        {
            IEnumerable<msgcount> result = dbContext.dbConnection.Query<msgcount>("m_message_package.countmsg", commandType: CommandType.StoredProcedure);

            return result.ToList();

        }

        public List<m_message> search(DateTime first, DateTime second)
        {
            IEnumerable<m_message> result = getall();
            result = result.Where(g => g.msg_date.Date >= first.Date && g.msg_date.Date <= second.Date);
            return result.ToList();
        }

        public List<m_message> filter(string msg)
        {
            IEnumerable<m_message> result = getall();
            result = result.Where(g => g.message.Contains(msg));
            return result.ToList();

        }


        public bool deleteone(int? id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("messageid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            dbContext.dbConnection.ExecuteAsync("m_message_package.deleteone", parameter, commandType: CommandType.StoredProcedure);
            return true;
        }

        public List<m_message> getall()
        {
            IEnumerable<m_message> result = dbContext.dbConnection.Query<m_message>("m_message_package.getall", commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public m_message getbyid(int? id)
        {
            var parameter = new DynamicParameters();

            parameter.Add("messageid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);


            IEnumerable<m_message> result = dbContext.dbConnection.Query<m_message>("m_message_package.getbyid", parameter, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();

        }

        public bool insertone(m_message message)
        {
            var parameter = new DynamicParameters();

            parameter.Add("msg_date", message.msg_date, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            parameter.Add("sender", message.sender, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("receiver", message.receiver, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("message", message.message, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = dbContext.dbConnection.ExecuteAsync("m_message_package.creatone", parameter, commandType: CommandType.StoredProcedure);

            return true;

        }
        public int messagecount()
        {
            var messages = getall();
            return messages.Count();
        }


    }
}
