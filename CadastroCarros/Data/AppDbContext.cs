using CadastroCarros.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastroCarros.Data
{
    public class AppDbContext :  DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        { }

        public DbSet<Carro> Carro { get; set; }
    }
}
