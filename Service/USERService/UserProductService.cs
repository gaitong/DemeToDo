using Data.Models;
using Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Service.USERService
{
    public interface IUserProductService
    {
        IEnumerable<UserProduct> GetAll();
        UserProduct GetBy(int id);
        IEnumerable<UserProduct> FindByUsertId(int userProduct);
        bool Add(UserProduct userProduct);
        bool Update(UserProduct userProduct);
        bool Delete(UserProduct userProduct);
        bool DeleteByUsertId(int UsertId);

    }
    public class UserProductService : IUserProductService
    {
        private IUSERRepository _uSERRepository;
        private IUserProductRepository _userProductRepository;

        public UserProductService(IUSERRepository uSERRepository, IUserProductRepository userProductRepository, bool initialization = true)
        {
            _uSERRepository = uSERRepository;
            _userProductRepository = userProductRepository;
            if (initialization)
            {
                _uSERRepository = new USERRepository();
                _userProductRepository = new UserProductRepository();
            }
        }

        public IEnumerable<UserProduct> GetAll()
        {
            return _userProductRepository.GetAll();
        }

        public UserProduct GetBy(int id)
        {
            return _userProductRepository.FindBy(id);
        }

        public IEnumerable<UserProduct> FindByUsertId(int userProduct)
        {
            return _userProductRepository.FindByUsertId(userProduct);
        }

        public bool Add(UserProduct userProduct)
        {
            var userId = _uSERRepository.FindBy(userProduct.UserId);
            if (userProduct == null)
            {
                return false;
            }
            return _userProductRepository.Add(userProduct) > 0;
        }

        public bool Update(UserProduct userProduct)
        {
            return _userProductRepository.Update(userProduct) > 0;
        }

        public bool Delete(UserProduct userProduct)
        {
            return _userProductRepository.Delete(userProduct) > 0;
        }

        public bool DeleteByUsertId(int UsertId)
        {
            return _userProductRepository.DeleteByUserId(UsertId) > 0;
        }

    }
}

