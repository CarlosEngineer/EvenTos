using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eventos.APi.Models;
using Microsoft.EntityFrameworkCore;

namespace Eventos.APi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext>options) : base(options)
        {
            
        }


        public DbSet<Evento> Eventos { get; set;}
    }
}