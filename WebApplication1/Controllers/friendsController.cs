using lear.core.data;
using lear.core.service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Final_task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class friendsController : Controller
    {
        private readonly Im_friends_service ser;
        public friendsController(Im_friends_service ser)
        {
            this.ser = ser;
        }

        [HttpDelete("deleteone/{id}")]
        public bool deleteone(int? id)
        {
            return ser.deleteone(id);
        }

        [HttpGet("getall")]
        public List<m_friends> getall()
        {
            return ser.getall();
        }

        [HttpGet("getbyfirstid/{id}")]

        public m_friends getbyfirstid(int? id)
        {
            return ser.getbyfirstid(id);
        }
        [HttpGet("getbysecondid/{id}")]

        public m_friends getbysecondid(int? id)
        {
            return ser.getbysecondid(id);
        }
        [HttpPost("insertone")]
        public bool insertone([FromBody] m_friends friends)
        {
            return ser.insertone(friends);
        }
    }
}
