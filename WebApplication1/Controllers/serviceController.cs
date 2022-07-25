using lear.core.data;
using lear.core.DTO;
using lear.core.service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Final_task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class serviceController : Controller
    {
        private readonly Im_service_service ser;
        public serviceController(Im_service_service ser)
        {
            this.ser = ser;
        }
        [HttpGet("total")]
        public List<total_service> total_services()
        {
            return ser.total_services();
        }

        [HttpDelete("deleteone/{id}")]
        public bool deleteone(int? id)
        {
            return ser.deleteone(id);
        }

        [HttpGet("getall")]
        public List<m_service> getall()
        {
            return ser.getall();
        }

        [HttpGet("getbyid/{id}")]

        public m_service getbyid(int? id)
        {
            return ser.getbyid(id);
        }

        [HttpPost("insertone")]
        public bool insertone([FromBody] m_service service)
        {
            return ser.insertone(service);
        }
        [HttpPost("updateone")]
        public bool updateone([FromBody] m_service service)
        {
            return ser.updateone(service);
        }
    }
}
