using Clients_Explorer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clients_Explorer.DB
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }

        public DbSet<Founder> Founders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=127.0.0.1;Port=5432;Database=Clients_Explorer;Username=postgres;Password=*****");
        }
    }
}
