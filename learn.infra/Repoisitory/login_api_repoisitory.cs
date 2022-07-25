using Dapper;
using lear.core.data;
using lear.core.domain;
using lear.core.Repoisitory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace learn.infra.Repoisitory
{
    public class login_api_repoisitory : Ilogin_api_repoisitory
    {
        private readonly IDBContext dbContext;
        public login_api_repoisitory(IDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public login_api auth(login_api login)
        {
            var parameter = new DynamicParameters();
            parameter.Add("username1", login.username, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("password1", login.password, dbType: DbType.String, direction: ParameterDirection.Input);

            IEnumerable<login_api> result = dbContext.dbConnection.Query<login_api>("login_package.Auth", parameter, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }
    }
}
