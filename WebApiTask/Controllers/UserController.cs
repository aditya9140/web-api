using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WebApiTask.Context;
using WebApiTask.Interface;
using WebApiTask.Model.Dto;
using WebApiTask.Model.Entity;

namespace WebApiTask.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserRepo _userRepo;

        public UserController(ILogger<UserController> logger, IUserRepo userRepo)
        {
            _logger = logger;
            _userRepo = userRepo;
        }

        [HttpGet]
        public List<User> GetAllUserFromUrl()
        {
            var userDetails = _userRepo.GetAllUserFromUrl();
            return userDetails;
        }

        [HttpGet]
        [Route("Users")]
        public IEnumerable<User> GetAllUser()
        {
            var userDetails = _userRepo.GetAllUser();
            return userDetails;
        }

        [HttpPost]
        public bool InsertUser([FromBody] User user)
        {
            _userRepo.StoreUser(user);
            return true;
        }

        [HttpPut]
        public bool UpdateUser(int id, [FromBody] UserDto user)
        {
            _userRepo.UpdateUser(id, user);
            return true;
        }
    }
}
