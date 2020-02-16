using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Random;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("weather")]
    public class WeatherController : ControllerBase
    {
        private IService _service;
        private readonly ILogger<WeatherController> _logger;
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        public WeatherController(ILogger<WeatherController> logger, IService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = _service.RandomNumber(-20, 55),
                    Summary = Summaries[_service.RandomNumber(0, Summaries.Length)]
                })
                .ToArray();
        }
        
        public int RandomNumber(int value1=0, int value2=100)
        {
            System.Random random = new System.Random();  
            return random.Next(value1, value2);
        }
    }
}