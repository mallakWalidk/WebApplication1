using lear.core.data;
using lear.core.DTO;
using lear.core.service;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System;
using System.Collections.Generic;

namespace Final_task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class messageController : Controller
    {
        private readonly Im_message_service ser;
        public messageController(Im_message_service ser)
        {
            this.ser = ser;
        }

        [HttpDelete("deleteone/{id}")]
        public bool deleteone(int? id)
        {
            return ser.deleteone(id);
        }

        [HttpGet("getall")]
        public List<m_message> getall()
        {
            return ser.getall();
        }
        [HttpGet("msgcount")]
        public string msgcount()
        {
            return "count of messages:" + ser.messagecount();
        }

        [HttpGet("usermsgcount")]
        public List<msgcount> usermsgcount()
        {
            return ser.usermsgcount();
        }
        [HttpPost("search")]

        public List<m_message> search([FromBody] msgdate message)
        {
            return ser.search(message.first, message.second);
        }
        [HttpGet("getbyid/{id}")]

        public m_message getbyid(int? id)
        {
            return ser.getbyid(id);
        }
        [HttpGet("filter")]
        public List<m_message> filter([FromBody] string msg)
        {
            return ser.filter(msg);
        }

        [HttpPost("insertone")]
        public bool insertone([FromBody] m_message message)
        {
            return ser.insertone(message);
        }

      

    }
}
