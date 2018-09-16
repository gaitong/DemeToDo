using Data.Models;
using Data.Repository;
using Service.USERService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    [System.Web.Http.RoutePrefix("api/USERP")]
    public class USERPController : ApiController
    {
        private IUSERService _uSERService;
        private IUSERRepository _uSERRepository;
        private IUserProductRepository _userProductRepository;
        // GET: USERP
        public USERPController()
        {
            _uSERRepository = new USERRepository();
            _userProductRepository = new UserProductRepository();

            _uSERService = new USERService(_uSERRepository, _userProductRepository);
        }

        [HttpGet]
        public IEnumerable<USERP> GetAll()
        {
            return _uSERService.GetAll();
        }

        [HttpGet]
        [Route("{id:int}")]
        public USERP GetBy(int id)
        {
            return _uSERService.GetBy(id);
        }

        [HttpPost]
        public bool Add(string name ,string gender)
        {
            var userp = new USERP { Name = name , Gender = gender };
            return _uSERService.Add(userp);
        }

        [HttpPut]
        [Route("{id:int}")]
        public bool Update(USERP userp)
        {
            return _uSERService.Update(userp);
        }

        [HttpDelete]
        public bool Delete(int id)
        {
            var userp = new USERP { Id = id };
            return _uSERService.Delete(userp);

        }
    }
}