using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class testController : Controller
    {

        [HttpGet("check/{name}")]
        public string check(string name)
        {
            var names = new List<string>()
                    {
                        "monther",
                        "mallak"
                    };
            if (names.Contains(name))
                return "true";
            else return "false";

        }
        [HttpGet("check2/{name}")]
        public int check2(string name)
        { var c = 0;
            var names = new List<char>()
                    {'a', 'e','o','i'};
            foreach (var a in name)
            {
                if (names.Contains(a))
                    c++;
            }
            return c;
        }

        [HttpGet("check3/{a1}/{a2}/{a3}/{a4}")]
        public List<string> check3(string a1,string a2,string a3,string a4)

        {
            var names = new List<string>();
            names.Add(a1);
            names.Add(a2);
            names.Add(a3);
            names.Add(a4);
            return names;
        }

/*        [HttpGet("getname33")]
        public string getname33([FromBody] info Info)
        {

            var jsonString = JsonConvert.SerializeObject(Info);
            return jsonString;

        }*/
    }
}
