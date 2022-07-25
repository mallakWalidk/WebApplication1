using lear.core.data;
using lear.core.service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class postController : Controller
    {
        private readonly Im_post_service ser;
        public postController(Im_post_service ser)
        {
            this.ser = ser;
        }
        

        [HttpGet("count_likes")]
        public async Task<IActionResult> count_likes()
        {
            return Ok(ser.count_likes());
        }


        [HttpDelete("deleteone/{id}")]
        public bool deleteone(int? id)
        {
            return ser.deleteone(id);
        }

        [HttpGet("getall")]
        public List<m_post> getall()
        {
            return ser.getall();
        }

        [HttpGet("getbyid/{id}")]

        public m_post getbyid(int? id)
        {
            return ser.getbyid(id);
        }

        [HttpPost("insertone")]
        public bool insertone([FromBody] m_post post)
        {
            return ser.insertone(post);
        }
        [HttpPost("updateone")]
        public bool updateone([FromBody] m_post post)
        {
            return ser.updateone(post);
        }
    }
}
