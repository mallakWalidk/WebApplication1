using lear.core.data;
using lear.core.service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Final_task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class groupsController : Controller
    {
        private readonly Im_groups_service ser;
        public groupsController(Im_groups_service ser)
        {
            this.ser = ser;
        }

        [HttpDelete("deleteone/{id}")]
        public bool deleteone(int? id)
        {
            return ser.deleteone(id);
        }

        [HttpGet("getall")]
        public List<m_groups> getall()
        {
            return ser.getall();
        }

        [HttpGet("getbyid/{id}")]

        public m_groups getbyid(int? id)
        {
            return ser.getbyid(id);
        }

        [HttpPost("insertone")]
        public bool insertone([FromBody] m_groups groups)
        {
            return ser.insertone(groups);
        }
        [HttpPost("updateone")]
        public bool updateone([FromBody] m_groups groups)
        {
            return ser.updateone(groups);
        }
    }
}
