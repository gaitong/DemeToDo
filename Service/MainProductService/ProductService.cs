using Data.Models;
using Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Service.MainProductService
{
    public interface IProductService {
        IEnumerable<Product> GetAll();
        Product GetBy(int id);
        IEnumerable<Product> GetByMainProductId(int mainProductId);
        bool Add(Product product);
        bool Update(Product product);
        bool Delete(Product product);
        bool DeleteByMainId(int mainProductId);
    }
    public class ProductService : IProductService
    {
        private IMainProductRepository _mainProductRepository;
        private IProductRepository _productRepository;

        public ProductService(IMainProductRepository mainProductRepository, IProductRepository productRepository, bool initialization = true)
        {
            _mainProductRepository = mainProductRepository;
            _productRepository = productRepository;
            if (initialization)
            {
                _mainProductRepository = new MainProductRepository();
                _productRepository = new ProductRepository();
            }
        }

        public IEnumerable<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public Product GetBy(int id)
        {
            return _productRepository.FindBy(id);
        }

        public IEnumerable<Product> GetByMainProductId(int mainProductId)
        {
            return _productRepository.FindByMainProjectId(mainProductId);
        }

        public bool Add(Product product)
        {
            var mainProductId = _mainProductRepository.FindBy(product.MainProductId);
            if (mainProductId == null)
            {
                return false;
            }
            return _productRepository.Add(product) > 0;
        }

        public bool Update(Product product)
        {
            return _productRepository.Update(product) > 0;
        }

        public bool Delete(Product product)
        {
            return _productRepository.Delete(product) > 0;
        }

        public bool DeleteByMainId(int mainProductId)
        {
            return _productRepository.DeleteByMainId(mainProductId) > 0;
        }

    }
}