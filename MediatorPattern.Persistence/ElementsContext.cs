using MediatorPattern.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MediatorPattern.Persistence
{
    internal class ElementContextFactory : IDesignTimeDbContextFactory<ElementsContext>
    {
        ElementsContext IDesignTimeDbContextFactory<ElementsContext>.CreateDbContext(string[] args)
        {
            var ctxConf = new DbContextOptionsBuilder<ElementsContext>()
                .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ElementsContextTest;Trusted_Connection=True;MultipleActiveResultSets=true")
                    .EnableSensitiveDataLogging();

            return new ElementsContext(ctxConf.Options);
        }
    }

    public class ElementsContext : DbContext
    {
        public ElementsContext(DbContextOptions<ElementsContext> options)
            : base(options)
        { }
        
        public DbSet<Element> Elements { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Element>().OwnsOne<Position>(element => element.Position);
            modelBuilder.Entity<Element>().OwnsOne<Size>(element => element.Size);
            modelBuilder.Entity<Element>().Property(x => x.Name).IsRequired();
            base.OnModelCreating(modelBuilder);
        }
    }
}
