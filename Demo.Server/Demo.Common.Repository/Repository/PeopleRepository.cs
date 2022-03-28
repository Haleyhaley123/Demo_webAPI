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
    public class PeopleRepository : IPeopleRepository
    {
        private readonly DataBaseContext _dataBaseContext;
        public PeopleRepository(DataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }
        public async Task<List<People>> GetPeople()
        {
            return await _dataBaseContext.ListDatas.ToListAsync();
        }
        public async Task<People> GetPeopleByID(string Id)
        {
            return await _dataBaseContext.ListDatas.Where(x => x.ID == Id).FirstOrDefaultAsync();
        }

        public bool EditData(People EditId)
        {
            var paramT = new DynamicParameters();
            paramT.Add("@ID", EditId.ID, System.Data.DbType.String);
            paramT.Add("@Name", EditId.Name, System.Data.DbType.String);
            paramT.Add("@Gender", EditId.Gender, System.Data.DbType.String);
            paramT.Add("@Age", EditId.Age, System.Data.DbType.Int32);
            paramT.Add("@Department", EditId.Department, System.Data.DbType.String);
            paramT.Add("@Birthday", EditId.Birthday, System.Data.DbType.DateTime);
            paramT.Add("@NumberPhone", EditId.NumberPhone, System.Data.DbType.String);

            string sqlEdit = "EditData";
            int Result = -100;
            try
            {
                var sReader = DapperManagerSQL.Instance.Conn.ExecuteReader(sqlEdit, paramT, commandType: CommandType.StoredProcedure);
                while (sReader.Read())
                {
                    // chỉ trường được duy nhất SQL trả về Result = 1
                    Result = sReader["ResultSql"] == null ? 0 : int.Parse(sReader["ResultSql"].ToString());

                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return Result > 0;


        }
       public async Task<bool> InsertData(People insertdata)
        {

            var listData = await _dataBaseContext.ListDatas.ToListAsync();
            if (listData != null && listData.Count > 0)
            {
                if (listData.Any(e => e.ID == insertdata.ID)) 
                {
                    return false;
                }

            }
            People people = new People()
            {
                ID = insertdata.ID,
                Name = insertdata.Name,
                Gender = insertdata.Gender,
                Age = insertdata.Age,
                Department = insertdata.Department,
                Birthday = insertdata.Birthday,
                NumberPhone = insertdata.NumberPhone,
            };
            try
            {
                _dataBaseContext.ListDatas.Add(people);
                await _dataBaseContext.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }

        }

        public async Task<bool> DeleteData(int id)
        {
            try
            {
                var DbListdate = await _dataBaseContext.ListDatas.FindAsync(id);

                if (DbListdate == null)
                {
                    return false;
                }

                _dataBaseContext.ListDatas.Remove(DbListdate);
                await _dataBaseContext.SaveChangesAsync();

                return true;            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
    
}
