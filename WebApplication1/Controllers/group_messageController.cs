using lear.core.data;
using lear.core.service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Final_task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class group_messageController : Controller
    {
        private readonly Im_group_message_service ser;
        public group_messageController(Im_group_message_service ser)
        {
            this.ser = ser;
        }

        [HttpDelete("deleteone/{id}")]
        public bool deleteone(int? id)
        {
            return ser.deleteone(id);
        }

        [HttpGet("getall")]
        public List<m_group_message> getall()
        {
            return ser.getall();
        }

        [HttpGet("getbyid/{id}")]

        public m_group_message getbyid(int? id)
        {
            return ser.getbyid(id);
        }

        [HttpPost("insertone")]
        public bool insertone([FromBody] m_group_message group_message)
        {
            return ser.insertone(group_message);
        }
        [HttpPost("updateone")]
        public bool updateone([FromBody] m_group_message group_message)
        {
            return ser.updateone(group_message);
        }
    }
}
