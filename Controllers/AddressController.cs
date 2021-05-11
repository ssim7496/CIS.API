using CIS.Core.Models;
using CIS.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CIS.API.Controllers
{
    [Route("api/addresses")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly string _dbConn;
        private AddressService _addressService;

        public AddressController(IConfiguration configuration)
        {
            _configuration = configuration;
            _dbConn = _configuration.GetConnectionString("CISAppCon");
            _addressService = new AddressService(_dbConn);
        }

        [HttpPost]
        public JsonResult AddAddress(Address address)
        {
            int cmd = -1;

            cmd = _addressService.AddAddress(address);

            string result = (cmd > 0) ? "Added" : "Add Failed";

            return new JsonResult(result);
        }
    }
}
