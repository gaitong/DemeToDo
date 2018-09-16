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
    public interface IProductRepository
    {
        List<Product> GetAll();
        Product FindBy(int id);
        int Add(Product entity);
        IEnumerable<Product> FindByMainProjectId(int mainProductId);
        int Update(Product entity);
        int Delete(Product entity);
        int DeleteByMainId(int mainProductId);
    }
    public class ProductRepository : IProductRepository
    {

        private IDbConnection _db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);


        public List<Product> GetAll()
        {
            return this._db.Query<Product>("SELECT * FROM [Product]").ToList();
        }

        public Product FindBy(int id)
        {
            var sqlCommand = string.Format(@"SELECT * FROM[Product] WHERE[Id] = @Id");
            return this._db.Query<Product>(sqlCommand, new
            {
                id
            }).FirstOrDefault();
        }

        public IEnumerable<Product> FindByMainProjectId(int mainProductId)
        {
            var sqlCommand = string.Format(@"SELECT * FROM[Product] WHERE [MainProductId] = @MainProductId");
            return this._db.Query<Product>(sqlCommand, new
            {
                mainProductId
            }).ToList();
        }

        public int Add(Product entity)
        {
            var sqlCommand = string.Format(@"INSERT INTO [Product] ([Name],[Price],[MainProductId]) VALUES (@Name,@Price,@MainProductId)");
            return this._db.Execute(sqlCommand, new
            {
                entity.Name,
                entity.Price,
                entity.MainProductId
            });
        }
        public int Update(Product entity)
        {
            var sqlCommand = string.Format(@"UPDATE [Product] SET [Name] = @Name , [Price] = @Price , [MainProduct] = @MainProduct WHERE [Id] = @Id");
            return this._db.Execute(sqlCommand, new
            {
                entity.Name,
                entity.MainProductId,
                entity.Price,
                entity.Id
            });
        }


        public int DeleteByMainId(int mainProductId)
        {
            var sqlCommand = string.Format(@"DELETE FROM [Product] WHERE [MainProductId] = @MainProductId");
            return this._db.Execute(sqlCommand, new
            {
                mainProductId
            });
        }

        public int Delete(Product entity)
        {
            var sqlCommand = string.Format(@"DELETE FROM [Product] WHERE [Id] = @Id");
            return this._db.Execute(sqlCommand, new
            {
                entity.Id
            });
        }
    }
}