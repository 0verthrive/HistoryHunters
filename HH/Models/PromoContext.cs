using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HH.Models
{

    public class PromoContext : DbContext
    {
        public PromoContext(DbContextOptions<PromoContext> options) :
            base(options)
        { }

        public DbSet<Promo> Promo { get; set; }
    }
}
