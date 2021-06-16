using CleanArchitecture.Application.Interfaces;
using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace CleanArchitecture.Infrastructure.Persistence.Contexts
{
    public class ApplicationDbContextNew : DbContext, IApplicationDbContext
    {
        public ApplicationDbContextNew(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public IDbConnection Connection => Database.GetDbConnection();
    }
}
