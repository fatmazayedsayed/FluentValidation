using Fluent.Users.Models;
using Fluent.Utality;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fluent.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {

        private readonly List<userModel> userList = new List<userModel>
        {
            new userModel
            {
                Id=1,
                Name="fz",
                passWord="123",
                Email="fz@fz.com",
            },
              new userModel
            {
                Id=2,
                Name="sh",
                passWord="4444",
                Email="sh@sh.com",
            }

        };
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public ResponseData ckeckUser(useValid dto)
        {
            if (ModelState.IsValid)
            {
                var data= userList.Where(u => u.passWord == dto.passWord && u.Email == dto.Email).FirstOrDefault();
                string message = "success";
                if (data ==null)
                {
                    message = "Not Found";
                }
                return   new ResponseData
                {
                    result = data,
                    message = message
                };
            }
            else
            {
                return new ResponseData
                {
                    result = null,
                    message = ResponseData.GetModelErrros(ModelState)
                };
            }
        }
    }
}
