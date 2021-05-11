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
    [Route("api/contactInformation")]
    [ApiController]
    public class ContactInformationController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly string _dbConn;
        private ContactInformationService _contactInfoService;

        public ContactInformationController(IConfiguration configuration)
        {
            _configuration = configuration;
            _dbConn = _configuration.GetConnectionString("CISAppCon");
            _contactInfoService = new ContactInformationService(_dbConn);
        }

        [HttpPost]
        public JsonResult AddContactInformation(ContactInformation contactInfo)
        {
            int cmd = -1;

            cmd = _contactInfoService.AddContactInformation(contactInfo);

            string result = (cmd > 0) ? "Added" : "Add Failed";

            return new JsonResult(result);
        }
    }
}
