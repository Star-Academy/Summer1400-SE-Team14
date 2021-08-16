using System;
using ConsoleApp1;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("[controller]/[Action]")]
    public class SimpleController : ControllerBase
    {
        [HttpGet]
        public string Get(string input)
        {
            var result = PreProcessing.Preprocesses(input);
            var answer = "";
            foreach (var s in result)
            {
                answer += s;
                answer += "\n";
            }
            return answer;
        }
    }
}