using lear.core.data;
using lear.core.DTO;
using lear.core.service;
using Microsoft.AspNetCore.Mvc;
using Nancy.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Final_task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class usersController : Controller
    {
        private readonly Im_users_service ser;
        public usersController(Im_users_service ser)
        {
            this.ser = ser;
        }

        [HttpGet("allweather")]

        public async Task<IActionResult> weather()
        {
            return Ok(ser.weather());
        }

        [HttpGet("weather/{id}")]
        public async Task<IActionResult> weather(int id)
        {
            return Ok(ser.weather(id));
        }


        [HttpGet("backup/{id}")]
        public async Task<IActionResult> backup(int id)
        {

            return Ok(ser.backup(id));
        }
        [HttpPost("insert5")]
        public async Task<IActionResult> insert5record([FromBody]List<m_users> users)
        {
            return Ok(ser.insert5record(users));
        }
        [HttpGet("insertusers/{filename}")]
        public async Task<IActionResult> insertusers(string filename)
        {
            return Ok(ser.insertusers(filename));
        }
        [HttpGet("citycounts")]
        public async Task<IActionResult> citycounts()
        {
            return Ok(ser.citycounts());
        }
        [HttpGet("visacount")]
        public async Task<IActionResult> visa_count()
        {
            return Ok(ser.visa_count());
        }


        [HttpDelete("deleteone/{id}")]
        public bool deleteone(int? id)
        {
            return ser.deleteone(id);
        }

        [HttpGet("getall")]
        public List<m_users> getall()
        {
            return ser.getall();
        }

        [HttpGet("getbyid/{id}")]

        public m_users getbyid(int? id)
        {
            return ser.getbyid(id);
        }

        [HttpPost("insertone")]
        public bool insertone([FromBody] m_users users)
        {
            return ser.insertone(users);
        }
        [HttpPost("updateone")]
        public bool updateone([FromBody] m_users users)
        {
            return ser.updateone(users);
        }
    }
}
