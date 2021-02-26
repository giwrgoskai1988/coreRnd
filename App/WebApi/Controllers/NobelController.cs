using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("nobels")]
    [ApiController]
    public class NobelController : ControllerBase
    {
        private IRepository<Nobel> _repository;

        public NobelController(IRepository<Nobel> repository)
        {
            _repository = repository;
        }


        [HttpGet]
        public IActionResult GetNobels()
        {
            return Ok(_repository.GetAll());
        }
    }
}
