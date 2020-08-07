using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProAgil.WebAPI.Data;
using ProAgil.WebAPI.Model;

namespace ProAgil.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        public readonly DataContext _context;
        public WeatherForecastController(DataContext context)
        {
            _context = context;
        }
        private static readonly string[] Summaries = new[]
        {
            "Freezing1", "Bracing1", "Chilly1", "Cool1", "Mild1", "Warm1", "Balmy1", "Hot1", "Sweltering1", "Scorching1"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        /*public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }*/

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var results = await _context.Eventos.ToListAsync();
                return Ok(results);
            }
            catch(System.Exception)
            {
                return this.StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }            
        }
        /*public ActionResult<IEnumerable<Evento>> Get()
        {
            return new Evento[] {
                new Evento() {
                    EventoID = 1,
                    Tema = "Angular e .NET Core",
                    Local = "Belo Horizonte",
                    Lote = "1º Lote",
                    QtdPessoas = 250,
                    DataEvento = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy")
                },
                new Evento() {
                    EventoID = 2,
                    Tema = "Angular e Suas Novidades",
                    Local = "São Paulo",
                    Lote = "2º Lote",
                    QtdPessoas = 350,
                    DataEvento = DateTime.Now.AddDays(3).ToString("dd/MM/yyyy")
                }
            };
            //return _context.Eventos.ToList();
        }*/

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var result = await _context.Eventos.FirstOrDefaultAsync(x => x.EventoID == id);
                return Ok(result);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Falha no banco de dados");
            }
        }
        /*public ActionResult<Evento> Get(int id)
        {
            return new Evento[] {
                new Evento() {
                    EventoID = 1,
                    Tema = "Angular e .NET Core",
                    Local = "Belo Horizonte",
                    Lote = "1º Lote",
                    QtdPessoas = 250,
                    DataEvento = DateTime.Now.AddDays(2).ToString("dd/MM/yyyy")
                },
                new Evento() {
                    EventoID = 2,
                    Tema = "Angular e Suas Novidades",
                    Local = "São Paulo",
                    Lote = "2º Lote",
                    QtdPessoas = 350,
                    DataEvento = DateTime.Now.AddDays(3).ToString("dd/MM/yyyy")
                }
            }.FirstOrDefault(x => x.EventoID == id);
            //return _context.Eventos.FirstOrDefault(x => x.EventoID == id);
        }*/
    }
}
