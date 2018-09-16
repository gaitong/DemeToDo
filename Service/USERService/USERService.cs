using Data.Models;
using Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Service.USERService
{
    public interface IUSERService {

        IEnumerable<USERP> GetAll();
        USERP GetBy(int id);
        bool Add(USERP uSERP);
        bool Update(USERP uSERP);
        bool Delete(USERP uSERP);
    }

    public class USERService : IUSERService
    {
        private IUSERRepository _uSERRepository;
        private IUserProductRepository _userProductRepository;


        public USERService(IUSERRepository uSERRepository, IUserProductRepository userProductRepository, bool initialization = true)
        {
            _uSERRepository = uSERRepository;
            _userProductRepository = userProductRepository;
            if (initialization)
            {
                _uSERRepository = new USERRepository();
                _userProductRepository = new UserProductRepository();

            }
        }

        public IEnumerable<USERP> GetAll()
        {
            return _uSERRepository.GetAll();
        }

        public USERP GetBy(int id)
        {

            return _uSERRepository.FindBy(id);
        }

        public bool Add(USERP uSERP)
        {
            return _uSERRepository.Add(uSERP) > 0;
        }

        public bool Update(USERP uSERP)
        {
            return _uSERRepository.Update(uSERP) > 0;
        }

        public bool Delete(USERP uSERP)
        {
            var userps = _userProductRepository.FindByUsertId(uSERP.Id);
            if (userps.Any())
            {
                foreach (var userp in userps)
                {
                    var _use = new UserProduct { Id = userp.Id };
                    _userProductRepository.Delete(_use);
                }
            }
            return _uSERRepository.Delete(uSERP) > 0;
        }
    }
}
    
