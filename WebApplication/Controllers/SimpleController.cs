using System;
using ConsoleApp1;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class SimpleController : ControllerBase
    {
        [HttpGet]
        public string Get(string input)
        {
            Console.WriteLine(input);
            return PreProcessing.Preprocesses(input);
        }
    }
}