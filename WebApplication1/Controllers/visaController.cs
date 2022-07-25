using lear.core.data;
using lear.core.service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Final_task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class visaController : Controller
    {
        private readonly Im_visa_service ser;
        public visaController(Im_visa_service ser)
        {
            this.ser = ser;
        }

        [HttpDelete("deleteone/{id}")]
        public bool deleteone(int? id)
        {
            return ser.deleteone(id);
        }

        [HttpGet("getall")]
        public List<m_visa> getall()
        {
            return ser.getall();
        }

        [HttpGet("getbyid/{id}")]

        public m_visa getbyid(int? id)
        {
            return ser.getbyid(id);
        }

        [HttpPost("insertone")]
        public bool insertone([FromBody] m_visa visa)
        {
            return ser.insertone(visa);
        }
        [HttpPost("updateone")]
        public bool updateone([FromBody] m_visa visa)
        {
            return ser.updateone(visa);
        }
    }
}
