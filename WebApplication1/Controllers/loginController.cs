using lear.core.data;
using lear.core.service;
using Microsoft.AspNetCore.Mvc;

namespace Final_task.Controllers
{
    public class loginController : Controller
    {
        private readonly Ilogin_api_service ser;
        public loginController(Ilogin_api_service ser)
        {
            this.ser = ser;
        }
        [HttpPost]
        public IActionResult authen([FromBody] login_api login)
        {
            var RESULT = ser.auth(login);

            if (RESULT == null)
            {
                return Unauthorized(); //401
            }
            else
            {
                return Ok(RESULT); //200
            }

        }
    }
    }
