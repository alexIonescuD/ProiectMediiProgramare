using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proiect_ASP_NET.Models;

namespace Proiect_ASP_NET.Data
{
    public class Proiect_ASP_NETContext : DbContext
    {
        public Proiect_ASP_NETContext (DbContextOptions<Proiect_ASP_NETContext> options)
            : base(options)
        {
        }

        public DbSet<Proiect_ASP_NET.Models.Car> Car { get; set; } = default!;

        public DbSet<Proiect_ASP_NET.Models.Dealer> Dealer { get; set; }

        public DbSet<Proiect_ASP_NET.Models.Brand> Brand { get; set; }

        public DbSet<Proiect_ASP_NET.Models.Category> Category { get; set; }

        public DbSet<Proiect_ASP_NET.Models.Client> Client { get; set; }

        public DbSet<Proiect_ASP_NET.Models.Contract> Contract { get; set; }
    }
}
