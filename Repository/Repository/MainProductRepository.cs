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
    public interface IMainProductRepository {

        List<MainProduct> GetAll();
        MainProduct FindBy(int id);
        int Add(MainProduct entity);
        int Update(MainProduct entity);
        int Delete(MainProduct entity);
    }

    public class MainProductRepository : IMainProductRepository
    {
        private IDbConnection _db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        public List<MainProduct> GetAll()
        {
            return this._db.Query<MainProduct>("SELECT * FROM [MainProduct]").ToList();
        }

        public MainProduct FindBy(int id)
        {
            var sqlCommand = string.Format(@"SELECT * FROM[MainProduct] WHERE[Id] = @Id");
            return this._db.Query<MainProduct>(sqlCommand, new
            {
                id
            }).FirstOrDefault();
        }
        public int Add(MainProduct entity)
        {
            var sqlCommand = string.Format(@"INSERT INTO [MainProduct] ([Name]) VALUES (@Name)");
            return this._db.Execute(sqlCommand, new
            {
                entity.Name
            });
        }
        public int Update(MainProduct entity)
        {
            var sqlCommand = string.Format(@"UPDATE [MainProduct] SET [Name] = @Name WHERE [Id] = @Id");
            return this._db.Execute(sqlCommand, new
            {
                entity.Name,
                entity.Id
            });
        }

        public int Delete(MainProduct entity)
        {
            var sqlCommand = string.Format(@"DELETE FROM [MainProduct] WHERE [Id] = @Id");
            return this._db.Execute(sqlCommand, new
            {
                entity.Id
            });
        }
    }
}