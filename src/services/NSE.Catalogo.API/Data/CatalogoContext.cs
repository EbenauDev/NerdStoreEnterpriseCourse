using Microsoft.EntityFrameworkCore;
using NSE.Catalogo.API.Models;
using NSE.Core.Data;
using NSE.Core.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NSE.Catalogo.API.Data
{
    public class CatalogoContext : DbContext, IUnitOfWork
    {
        public CatalogoContext(DbContextOptions<CatalogoContext> options)
            : base(options)
        {

        }


        public DbSet<Produto> Produtos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Event>();
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CatalogoContext).Assembly);
        }

        public async Task<bool> CommitAsync()
        {
            return await base.SaveChangesAsync() > 0;
        }
    }
}
