using Data.Models;
using Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Service.MainProductService
{
    public interface IMainProductService
    {
        IEnumerable<MainProduct> GetAll();
        MainProduct GetBy(int id);
        bool Add(MainProduct mainProduct);
        bool Update(MainProduct mainProduct);
        bool Delete(MainProduct mainProduct);

    }

    public class MainProductService :IMainProductService
    {
        private IMainProductRepository _mainProductRepository;
        private IProductRepository _productkRepository;

        public MainProductService(IMainProductRepository mainProductRepository, IProductRepository productkRepository, bool initialization = true)
        {
            _mainProductRepository = mainProductRepository;
            _productkRepository = productkRepository;
            if (initialization)
            {
                _mainProductRepository = new MainProductRepository();
                _productkRepository = new ProductRepository();

            }
        }

        public IEnumerable<MainProduct> GetAll()
        {
            return _mainProductRepository.GetAll();
        }

        public MainProduct GetBy(int id)
        {

            return _mainProductRepository.FindBy(id);
        }

        public bool Add(MainProduct mainProduct)
        {
            return _mainProductRepository.Add(mainProduct) > 0;
        }

        public bool Update(MainProduct mainProduct)
        {
            return _mainProductRepository.Update(mainProduct) > 0;
        }

        public bool Delete(MainProduct mainProduct)
        {
            var products = _productkRepository.FindByMainProjectId(mainProduct.Id);
            if (products.Any())
            {
                foreach (var product in products)
                {
                    var _pro = new Product { Id = product.Id };
                    _productkRepository.Delete(_pro);
                }
            }
            return _mainProductRepository.Delete(mainProduct) > 0;
        }
    }
}