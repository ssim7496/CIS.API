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
    [Route("api/reports")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly string _dbConn;
        private ReportService _reportService;

        public ReportController(IConfiguration configuration)
        {
            _configuration = configuration;
            _dbConn = _configuration.GetConnectionString("CISAppCon");
            _reportService = new ReportService(_dbConn);
        }

        [Route("")]
        [HttpGet]
        public JsonResult GetClientInformation()
        {
            return new JsonResult(_reportService.GetClientInformation());
        }
    }
}
