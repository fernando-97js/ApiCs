using ApiCs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngsApi.Models {
    public class ApplicationDbContext : DbContext {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) {
        }

        public DbSet<Ong> Ongs { get; set; }
        public DbSet<VoluntariosFlorescer> VoluntariosFlorescer { get; set; } // Adicionado aqui
        public DbSet<VoluntariosPac> VoluntariosPac { get; set; } // Adicionado aqui
        public DbSet<VoluntariosArouche> VoluntariosArouche { get; set; } // Adicionado aqui


    }
}