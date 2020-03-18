using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioConcrete.Repository;
using DesafioConcrete.Model;
using Microsoft.AspNetCore.Mvc;

namespace DesafioConcrete.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AutenticationRespository _repo;
        public AuthController()
        {
            AutenticationRespository Data_Autentication = new AutenticationRespository();
            _repo = Data_Autentication;
        }
        // GET Auth/
        [HttpGet]
        public CreateLogin GetAll()
        {
            return _repo.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
    }
}
