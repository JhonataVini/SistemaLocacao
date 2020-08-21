using CrudSistema.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudSistema.Data
{
    public class ClienteContext : DbContext
    {
       
        public ClienteContext(DbContextOptions options) : base(options)
        {
             
        }

        public DbSet<Cliente> clientes { get; set; }
        public DbSet<Locacao> Locacoes { get; set; }
        public DbSet<Filme> Filmes { get; set; }
    


    }
}
