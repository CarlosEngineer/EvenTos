using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Eventos.APi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Eventos.APi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
         private readonly List<Evento>_evento;
        
        public EventoController()
        {
             _evento = new List<Evento>{
                new Evento
            {
                Id = 1,
                Local = "Sao Paulo",
                Tema = "Csharp",
                Lote = 1,
                QtdPessoas = 10,
                ImagemUrl = "foto.png"
            },
            new Evento
            {
                Id = 2,
                Local = "Rio de Janeiro",
                Tema = "Angular",
                Lote = 2,
                QtdPessoas = 5,
                ImagemUrl = "foto2.png"
            }

        };

        }

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return _evento;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var evento = _evento.FirstOrDefault(c => c.Id == id);

            if (evento == null)
            {
                return NotFound();
            }

            return Ok(evento);
        }


        [HttpPost]
        public IActionResult Inserir( Evento evento)
        {
            if (evento == null){
                return BadRequest();
            }   
            if (_evento.Any(c => c.Id == evento.Id)){
                return BadRequest($"O Id {evento} Ja existe. ");
            }

            _evento.Add(evento);
            return Ok(evento);

        
        }   


        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            var evento = _evento.FirstOrDefault(c => c.Id == id);

            if (evento == null){
                 return NotFound("Evento não encontrado.");
            }

            _evento.Remove(evento);

            return NoContent();
        }
    }
}
