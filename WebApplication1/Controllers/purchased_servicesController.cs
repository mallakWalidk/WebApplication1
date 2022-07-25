using lear.core.data;
using lear.core.DTO;
using lear.core.service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Final_task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class purchased_servicesController : Controller
    {
        private readonly Im_purchased_services_service ser;
        public purchased_servicesController(Im_purchased_services_service ser)
        {
            this.ser = ser;
        }

        [HttpGet("buyservice")]
        public async Task<IActionResult> buyservice([FromBody] buy buy)
        {
           return Ok(ser.buyservice(buy));
        }

        [HttpDelete("deleteone/{id}")]
        public bool deleteone(int? id)
        {
            return ser.deleteone(id);
        }

        [HttpGet("getall")]
        public List<m_purchased_services> getall()
        {
            return ser.getall();
        }

        [HttpGet("getbyid/{id}")]

        public m_purchased_services getbyid(int? id)
        {
            return ser.getbyid(id);
        }

        [HttpPost("insertone")]
        public bool insertone([FromBody] m_purchased_services purchased_services)
        {
            return ser.insertone(purchased_services);
        }
        [HttpPost("updateone")]
        public bool updateone([FromBody] m_purchased_services purchased_services)
        {
            return ser.updateone(purchased_services);
        }
    }
}
