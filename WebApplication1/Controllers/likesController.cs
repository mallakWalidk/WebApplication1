using lear.core.data;
using lear.core.service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Final_task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class likesController : Controller
    {
        private readonly Im_likes_service ser;
        public likesController(Im_likes_service ser)
        {
            this.ser = ser;
        }

        [HttpDelete("deleteone/{id}")]
        public bool deleteone(int? id)
        {
            return ser.deleteone(id);
        }

        [HttpGet("getall")]
        public List<m_likes> getall()
        {
            return ser.getall();
        }

        [HttpGet("getbyid/{id}")]

        public m_likes getbyid(int? id)
        {
            return ser.getbyid(id);
        }

        [HttpPost("insertone")]
        public bool insertone([FromBody] m_likes likes)
        {
            return ser.insertone(likes);
        }
    }
}
