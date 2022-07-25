using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Dapper;
using lear.core.data;
using lear.core.domain;
using lear.core.Repoisitory;
using MimeKit;

namespace learn.infra.Repoisitory
{
    public class m_groups_users_repoisitory : Im_groups_users_repoisitory
    {
        private readonly IDBContext dbContext;
        private readonly Im_users_repoisitory repo;
        public m_groups_users_repoisitory(IDBContext dbContext, Im_users_repoisitory repo)
        {
            this.dbContext = dbContext;
            this.repo=repo;
        }

        public string blockuser(m_block block)
        {
            var parameter = new DynamicParameters();
            parameter.Add("user_id", block.user_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("blocked_user", block.blocked_user, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("group_id", block.group_id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            dbContext.dbConnection.ExecuteAsync("m_block_package.creatone", parameter, commandType: CommandType.StoredProcedure);

            deleteone(block.blocked_user);

            var result=repo.getbyid(block.blocked_user);
            var result2 = repo.getbyid(block.user_id);

            MimeMessage message = new MimeMessage();
            BodyBuilder builder = new BodyBuilder();
            MailboxAddress from = new MailboxAddress("System", "test6555t@outlook.com");

            MailboxAddress to = new MailboxAddress("user",result.email);
            builder.HtmlBody = result2.firstname + " has blocked you, sorry for that :(";

            message.Body = builder.ToMessageBody();
            message.From.Add(from);
            message.To.Add(to);
            message.Subject = "You have been blocked";
            using (var item = new MailKit.Net.Smtp.SmtpClient())
            {
                item.Connect("smtp.office365.com", 587, false);
                item.Authenticate("test6555t@outlook.com", "11223344Te");
                item.Send(message);
                item.Disconnect(true);

            }

            return "User has been blocked";
        }

        public string unblock(m_block block)
        {
            var parameter = new DynamicParameters();
            parameter.Add("bid", block.blocked_user, dbType: DbType.Int32, direction: ParameterDirection.Input);

            dbContext.dbConnection.ExecuteAsync("m_block_package.deleteone", parameter, commandType: CommandType.StoredProcedure);

            m_groups_users newuser = new m_groups_users();
            newuser.user_id = block.blocked_user;
            newuser.group_id = block.group_id;
            insertone(newuser);


            var result = repo.getbyid(block.blocked_user);
            var result2 = repo.getbyid(block.user_id);

            MimeMessage message = new MimeMessage();
            BodyBuilder builder = new BodyBuilder();
            MailboxAddress from = new MailboxAddress("System", "test6555t@outlook.com");

            MailboxAddress to = new MailboxAddress("user", result.email);
            builder.HtmlBody = result2.firstname + " has Unblocked you, Congrats!";

            message.Body = builder.ToMessageBody();
            message.From.Add(from);
            message.To.Add(to);
            message.Subject = "You have been Unblocked";
            using (var item = new MailKit.Net.Smtp.SmtpClient())
            {
                item.Connect("smtp.office365.com", 587, false);
                item.Authenticate("test6555t@outlook.com", "11223344Te");
                item.Send(message);
                item.Disconnect(true);

            }

            return "User has been unblocked";
        }


        public bool deleteone(int? id)
        {
            var parameter = new DynamicParameters();
            parameter.Add("userid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            dbContext.dbConnection.ExecuteAsync("m_groups_users_package.deleteone", parameter, commandType: CommandType.StoredProcedure);
            return true;
        }

        public List<m_groups_users> getall()
        {
            IEnumerable<m_groups_users> result = dbContext.dbConnection.Query<m_groups_users>("m_groups_users_package.getall", commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public m_groups_users getbyid(int? id)
        {
            var parameter = new DynamicParameters();

            parameter.Add("groups_usersid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);


            IEnumerable<m_groups_users> result = dbContext.dbConnection.Query<m_groups_users>("m_groups_users_package.getbyuserid", parameter, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();

        }

        public bool insertone(m_groups_users groups)
        {
            var parameter = new DynamicParameters();

            parameter.Add("group_id", groups.group_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("user_id", groups.user_id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.dbConnection.ExecuteAsync("m_groups_users_package.creatone", parameter, commandType: CommandType.StoredProcedure);

            return true;

        }

        public bool updateone(m_groups_users groups)
        {
            var parameter = new DynamicParameters();
            parameter.Add("groups_usersid", groups.id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("group_id", groups.group_id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameter.Add("user_id", groups.user_id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.dbConnection.ExecuteAsync("m_groups_users_package.updateone", parameter, commandType: CommandType.StoredProcedure);


            return true;

        }



    }
}
