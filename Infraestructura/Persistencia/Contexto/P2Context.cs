using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Dominio.Entidades;

namespace Infraestructura.Persistencia.Contexto
{
    public class P2Context : DbContext
    {
        public P2Context(DbContextOptions<P2Context> op) : base(op) { }

        public DbSet<Usuario> Usuario { get; set; }
        //public DbSet<> x { get; set; }
    }
    
}   
