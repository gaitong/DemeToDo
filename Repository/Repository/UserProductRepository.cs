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
    public interface IUserProductRepository {
        List<UserProduct> GetAll();
        UserProduct FindBy(int id);
        IEnumerable<UserProduct> FindByUsertId(int UserId);
        int Add(UserProduct entity);
        int Update(UserProduct entity);
        int DeleteByUserId(int userId);
        int Delete(UserProduct entity);
    }
    public class UserProductRepository : IUserProductRepository
    {
        private IDbConnection _db = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        public List<UserProduct> GetAll()
        {
            return this._db.Query<UserProduct>("SELECT * FROM [UserProduct]").ToList();
        }

        public UserProduct FindBy(int id)
        {
            var sqlCommand = string.Format(@"SELECT * FROM[UserProduct] WHERE[Id] = @Id");
            return this._db.Query<UserProduct>(sqlCommand, new
            {
                id
            }).FirstOrDefault();
        }

        public IEnumerable<UserProduct> FindByUsertId(int UserId)
        {
            var sqlCommand = string.Format(@"SELECT * FROM[UserProduct] WHERE [UserId] = @UserId");
            return this._db.Query<UserProduct>(sqlCommand, new
            {
                UserId
            }).ToList();
        }

        public int Add(UserProduct entity)
        {
            var sqlCommand = string.Format(@"INSERT INTO [UserProduct] ([UserId],[ProductId]) VALUES (@UserId,@ProductId)");
            return this._db.Execute(sqlCommand, new
            {
                entity.UserId,
                entity.ProductId
                
            });
        }
        public int Update(UserProduct entity)
        {
            var sqlCommand = string.Format(@"UPDATE [UserProduct] SET [UserId] = @UserId , [ProductId] = @ProductId  WHERE [Id] = @Id");
            return this._db.Execute(sqlCommand, new
            {
                entity.UserId,
                entity.ProductId,
                entity.Id
            });
        }


        public int DeleteByUserId(int userId)
        {
            var sqlCommand = string.Format(@"DELETE FROM [UserProduct] WHERE [UserId] = @UserId");
            return this._db.Execute(sqlCommand, new
            {
                userId
            });
        }

        public int Delete(UserProduct entity)
        {
            var sqlCommand = string.Format(@"DELETE FROM [UserProduct] WHERE [Id] = @Id");
            return this._db.Execute(sqlCommand, new
            {
                entity.Id
            });
        }
    }
}