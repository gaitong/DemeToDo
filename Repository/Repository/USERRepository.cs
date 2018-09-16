using Dapper;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Data.Repository
{
    public interface IUSERRepository
    {

        USERP FindBy(int id);
        List<USERP> GetAll();
        int Add(USERP entity);
        int Update(USERP entity);
        int Delete(USERP entity);
    }

    public class USERRepository : IUSERRepository
    {
       

        private IDbConnection _db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        public List<USERP> GetAll()
        {
            return this._db.Query<USERP>("SELECT * FROM [USER]").ToList();
        }

        public USERP FindBy(int id)
        {
            var sqlCommand = string.Format(@"SELECT * FROM[USER] WHERE[Id] = @Id");
            return this._db.Query<USERP>(sqlCommand, new
            {
                id
            }).FirstOrDefault();
        }
        public int Add(USERP entity)
        {
            var sqlCommand = string.Format(@"INSERT INTO [USER] ([Name],[Gender]) VALUES (@Name, @Gender)");
            return this._db.Execute(sqlCommand, new
            {
                entity.Name,
                entity.Gender
            });
        }
        public int Update(USERP entity)
        {
            var sqlCommand = string.Format(@"UPDATE [USER] SET [Name] = @Name ,[Gender] = @Gender WHERE [Id] = @Id");
            return this._db.Execute(sqlCommand, new
            {
                entity.Name,
                entity.Gender,
                entity.Id
            });
        }

        public int Delete(USERP entity)
        {
            var sqlCommand = string.Format(@"DELETE FROM [USER] WHERE [Id] = @Id");
            return this._db.Execute(sqlCommand, new
            {
                entity.Id
            });
        }
    }
}