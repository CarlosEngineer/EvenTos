using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eventos.APi.Models
{
    public class Evento
    {
        public int Id { get; set; }
        public string Local { get; set; }
        public string DataEvento { get; set; } = DateTime.Now.AddDays(2).ToString();
        public string Tema { get; set; }
        public int  QtdPessoas { get; set; }
        public int Lote { get; set; }
        public string ImagemUrl { get; set; }

    }
}