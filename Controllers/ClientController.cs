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
    [Route("api/clients")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly string _dbConn;
        private ClientService _clientService;

        public ClientController(IConfiguration configuration)
        {
            _configuration = configuration;
            _dbConn = _configuration.GetConnectionString("CISAppCon");
            _clientService = new ClientService(_dbConn);
        }

        [Route("")]
        [HttpGet]
        public JsonResult GetClients()
        {
            return new JsonResult(_clientService.GetClients());
        }

        [Route("{ID:int}")]
        [HttpGet]
        public JsonResult GetClient(int ID)
        {
            return new JsonResult(_clientService.GetClient(ID));
        }

        [HttpPost]
        public JsonResult AddClient(Client client)
        {
            int cmd = -1;

            cmd = _clientService.AddClient(client);

            string result = (cmd > 0 ) ? "Added" : "Add Failed";

            return new JsonResult(result);
        }

        [HttpPut]
        public JsonResult UpdateClient(Client client)
        {
            int cmd = -1;

            cmd = _clientService.UpdateClient(client);

            string result = (cmd > 0) ? "Updated" : "Update Failed";

            return new JsonResult(result);
        }

        [Route("{ID:int}")]
        [HttpDelete]
        public JsonResult DeletClient(int ID)
        {
            int cmd = -1;

            cmd = _clientService.DeleteClient(ID);

            string result = (cmd > 0) ? "Deleted" : "Delete Failed";

            return new JsonResult(result);
        }
    }
}
