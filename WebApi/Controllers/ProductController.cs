using Data.Models;
using Data.Repository;
using Service.MainProductService;
using Service.MainTaskService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Viewmodel;

namespace WebApi.Controllers
{
    [RoutePrefix("api/product")]
    public class ProductController : ApiController
    {
        private readonly IProductService _productService;
        private readonly IMainProductRepository _mainProductRepository;
        private readonly IProductRepository _productRepository;

        public ProductController()
        {
            _mainProductRepository = new MainProductRepository();
            _productRepository = new ProductRepository();

            _productService = new ProductService(_mainProductRepository, _productRepository);
        }

        [HttpGet]
        public IEnumerable<Product> GetAll()
        {
            return _productService.GetAll();
        }

        [HttpGet]
        [Route("{id}")]
        public Product GetBy(int id)
        {
            return _productService.GetBy(id);
        }

        [HttpGet]
        [Route("getByMainProductId/{mainProductId}")]
        public IEnumerable<Product> GetByMainProductId(int mainProductId)
        {
            return _productService.GetByMainProductId(mainProductId);
        }

        [HttpPost]
        public bool Add(ProductInput productInput)
        {
            var product = new Product
            {
                Name = productInput.Name,
                MainProductId = productInput.MainProductId,
                Price = productInput.Price

            };
            return _productService.Add(product);
        }

        [HttpPut]
        [Route("{id}")]
        public bool Update(int id, int mainProductId, string name)
        {
            var product = new Product { Id = id, MainProductId = mainProductId, Name = name };
            return _productService.Update(product);
        }

        [HttpDelete]
        [Route("{id}")]
        public bool Delete(int id)
        {
            var product = new Product { Id = id };
            return _productService.Delete(product);
        }

        [HttpDelete]
        [Route("deleteByMaintId/{mainProductId}")]
        public bool DeleteByMainId(int mainProductId)
        {
            return _productService.DeleteByMainId(mainProductId);
        }
        
    }
}
