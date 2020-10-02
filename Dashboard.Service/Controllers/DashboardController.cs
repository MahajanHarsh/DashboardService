using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace Dashboard.Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DashboardController : ControllerBase
    {     
        private readonly ILogger<DashboardController> _logger;
        private readonly IDataManager _dataManager;
        public DashboardController(IDataManager dataManager, ILogger<DashboardController> logger)
        {
            _dataManager = dataManager;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            var response = _dataManager.GetUsers();
            return response;
        }

        [HttpPost]
        [Route("/Dashboard/AddUser")]
        public bool Post(User user)
        {
            var response = _dataManager.AddUser(user);
            return response;
        }

    }
}
