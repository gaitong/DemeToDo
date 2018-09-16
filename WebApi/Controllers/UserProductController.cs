using Data.Models;
using Data.Repository;
using Service.MainProductService;
using Service.USERService;
using System.Collections.Generic;
using System.Web.Http;
using WebApi.Viewmodel;

namespace WebApi.Controllers
{
    [RoutePrefix("api/UserProduct")]
    public class UserProductController : ApiController
    {
        private readonly IUserProductService _userProductService;
        private readonly IUSERRepository _uSERRepository;
        private readonly IUserProductRepository _userProductRepository;

        public UserProductController()
        {
            _uSERRepository = new USERRepository();
            _userProductRepository = new UserProductRepository();

            _userProductService = new UserProductService(_uSERRepository, _userProductRepository);
        }

        [HttpGet]
        public IEnumerable<UserProduct> GetAll()
        {
            return _userProductService.GetAll();
        }

        [HttpGet]
        [Route("{id}")]
        public UserProduct GetBy(int id)
        {
            return _userProductService.GetBy(id);
        }

        [HttpGet]
        [Route("findByUsertId/{userId}")]
        public IEnumerable<UserProduct> FindByUsertId(int userId)
        {
            return _userProductService.FindByUsertId(userId);
        }

        [HttpPost]
        public bool Add(UserProductInput userProductInput)
        {
            var userProduct = new UserProduct
            {
                UserId = userProductInput.UserId,
                ProductId  = userProductInput.ProductId
            };
            return _userProductService.Add(userProduct);
        }

        [HttpPut]
        [Route("{id}")]
        public bool Update(int id, int userId, int productId)
        {
            var userProduct = new UserProduct { Id = id, UserId = userId, ProductId = productId };
            return _userProductService.Update(userProduct);
        }

        [HttpDelete]
        [Route("{id}")]
        public bool Delete(int id)
        {
            var userProduct = new UserProduct { Id = id };
            return _userProductService.Delete(userProduct);
        }

        [HttpDelete]
        [Route("deleteByUsertId/{userId}")]
        public bool DeleteByUsertId(int userId)
        {
            return _userProductService.DeleteByUsertId(userId);
        }

    }
}
