using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DependencyInjector.API.Infraestructure.Service.Interfaces;
using DependencyInjector.API.Infraestructure.Service.ServiceClient;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjector.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IService _service;
        private readonly SecondService _secondService;

        public ValuesController(IService service, SecondService secondService)
        {
            _service = service;
            _secondService = secondService;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { _service.GetGuid().ToString(), _secondService.GetGuid().ToString() };
        }
    }
}
