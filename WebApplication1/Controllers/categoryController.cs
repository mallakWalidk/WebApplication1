using lear.core.data;
using lear.core.service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class categoryController : Controller
    {
        private readonly Im_category_service ser;
        public categoryController(Im_category_service ser)
        {
            this.ser = ser;
        }

        [HttpDelete("deleteone/{id}")]
        public bool deleteone(int? id)
        {
            return ser.deleteone(id);
        }

        [HttpGet("getall")]
        public List<m_category> getall()
        {
            return ser.getall();
        }

        [HttpGet("getbyid/{id}")]

        public m_category getbyid(int? id)
        {
            return ser.getbyid(id);
        }

        [HttpPost("insertone")]
        public bool insertone([FromBody]m_category category)
        {
            return ser.insertone(category);
        }
        [HttpPost("updateone")]
        public bool updateone([FromBody]m_category category)
        {
            return ser.updateone(category);
        }

    }
}
