using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HH.Models
{
    public class DestinoContext : DbContext
    {
        public DestinoContext(DbContextOptions<DestinoContext> options) :
            base(options)
        { }

        public DbSet<Destino> Destino { get; set; }
    }
}