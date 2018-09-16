using Data.Models;
using Data.Repository;
using Service.MainProductService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    [System.Web.Http.RoutePrefix("api/mainproduct")]
    public class MainProductController : ApiController
    {
        private IMainProductService _mainProductService;
        private IMainProductRepository _mainProductRepository;
        private IProductRepository _productRepository;
        // GET: MainProduct
        public MainProductController()
        {
            _mainProductRepository = new MainProductRepository();
            _productRepository = new ProductRepository();

            _mainProductService = new MainProductService(_mainProductRepository, _productRepository);
        }

        [HttpGet]
        public IEnumerable<MainProduct> GetAll()
        {
            return _mainProductService.GetAll();
        }

        [HttpGet]
        [Route("{id:int}")]
        public MainProduct GetBy(int id)
        {
            return _mainProductService.GetBy(id);
        }

        [HttpPost]
        public bool Add(string name)
        {
            var mainProduct = new MainProduct { Name = name };
            return _mainProductService.Add(mainProduct);
        }

        [HttpPut]
        [Route("{id:int}")]
        public bool Update(MainProduct mainProduct)
        {
            return _mainProductService.Update(mainProduct);
        }

        [HttpDelete]
        public bool Delete(int id)
        {
            var mainProduct = new MainProduct { Id = id };
            return _mainProductService.Delete(mainProduct);

        }
    }
}