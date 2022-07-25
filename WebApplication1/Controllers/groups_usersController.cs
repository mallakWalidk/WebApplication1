using lear.core.data;
using lear.core.service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Final_task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class groups_usersController : Controller
    {
        private readonly Im_groups_users_service ser;
        public groups_usersController(Im_groups_users_service ser)
        {
            this.ser = ser;
        }

        [HttpGet("blockuser")]
        public async Task<IActionResult> blockuser([FromBody]m_block block)
        {
            return Ok(ser.blockuser(block));
        }
        [HttpGet("unblockuser")]
        public async Task<IActionResult> unblockuser([FromBody] m_block block)
        {
            return Ok(ser.unblock(block));
        }

            [HttpDelete("deleteone/{id}")]
        public bool deleteone(int? id)
        {
            return ser.deleteone(id);
        }

        [HttpGet("getall")]
        public List<m_groups_users> getall()
        {
            return ser.getall();
        }

        [HttpGet("getbyid/{id}")]

        public m_groups_users getbyid(int? id)
        {
            return ser.getbyid(id);
        }

        [HttpPost("insertone")]
        public bool insertone([FromBody] m_groups_users groups_users)
        {
            return ser.insertone(groups_users);
        }
        [HttpPost("updateone")]
        public bool updateone([FromBody] m_groups_users groups_users)
        {
            return ser.updateone(groups_users);
        }
    }
}
