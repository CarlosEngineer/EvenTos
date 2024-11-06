using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Eventos.APi.Data;
using Eventos.APi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Eventos.APi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventoController : ControllerBase
    {
         private readonly DataContext _context;
        
        public EventoController(DataContext context)
        {
              _context = context;
        }

       [HttpGet]
        public ActionResult<List<Evento>> Get()
        {
            var eventos = _context.Eventos.ToList();
            return Ok(eventos);
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Evento>> GetById(int id)
        {
           var evento = _context.Eventos.FirstOrDefault(c => c.Id == id);

            if (evento == null)
            {
                return NotFound();
            }

            return Ok(evento);
        }  


        [HttpPost]
        public IActionResult Inserir( Evento evento)
        {
             _context.Add(evento); 
             _context.SaveChanges();
              return CreatedAtAction(nameof(GetById), new { id = evento.Id }, evento);
                  
        }   


        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
          var evento = _context.Eventos.FirstOrDefault(c => c.Id == id);

            if (evento == null)
            {
                return NotFound();
            }

            _context.Eventos.Remove(evento);
            _context.SaveChanges();

            return NoContent();
          
        }
    }
}
