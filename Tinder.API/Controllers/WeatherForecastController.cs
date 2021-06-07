using System;
using System.Collections.Generic;
using System.Linq;
using Tinder.API.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Tinder.API.Data;
using Microsoft.EntityFrameworkCore;

namespace Tinder.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly DataContext _context;
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, DataContext context)
        {
            _logger = logger;
            _context=context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var forecasts= await _context.WeatherForecasts.ToListAsync();
            return Ok(forecasts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetForcast(int id){
            var forecast= await _context.WeatherForecasts.FirstOrDefaultAsync<WeatherForecast>(x=> x.ForecastID==id);
            return Ok(forecast);
        }
    }
}
