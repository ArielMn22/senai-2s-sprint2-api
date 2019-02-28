﻿using Microsoft.EntityFrameworkCore;
using Senai.InLock.CodeFirst.WebApi.Tarde.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.CodeFirst.WebApi.Tarde.Contexts
{
    public class InLockContext : DbContext
    {
        public DbSet<EstudioDomain> Estudios { get; set; }
        public DbSet<JogoDomain> Jogos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.\\SqlExpress;Initial Catalog=InLock_CodeFirst_Tarde; user=sa; pwd=132");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
