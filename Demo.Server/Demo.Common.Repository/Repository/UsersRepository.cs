using Dapper;
using Demo.Common.Domain.DBContext;
using Demo.Common.Domain.DBDapper;
using Demo.Common.Domain.Models;
using Demo.Common.Domain.ViewModelsEntity;
using Demo.Common.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Common.Repository.Repository
{
    public class UsersRepository : IUsersRepository
    {
        // dùng entityframwork
        private readonly DataBaseContext _dataBaseContext;
        public UsersRepository(DataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }
        public async Task<User> GetUserByName(string username)
        {
            return await _dataBaseContext.Users.Where(x => x.UserName == username).FirstOrDefaultAsync();
        }

        public bool ChangePassWord(ChangePassWord changePass)
        {
            var param = new DynamicParameters();
            param.Add("@PK_ID", changePass.PK_ID, System.Data.DbType.Int32);
            param.Add("@NewPasswordHash", changePass.NewPasswordHash, System.Data.DbType.String);
            string sql = "InsertChangePass";
            int Result = -100;
            try
            {
                var sReader = DapperManagerSQL.Instance.Conn.ExecuteReader(sql, param, commandType: CommandType.StoredProcedure);
                while (sReader.Read())
                {
                    Result = sReader["ResultSql"] == null ? 0 : int.Parse(sReader["ResultSql"].ToString());
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return Result > 0;
          
        }
    }
}
