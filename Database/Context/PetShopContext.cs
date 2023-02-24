using Microsoft.EntityFrameworkCore;
using PetStore.API.Database.Entities;

namespace PetStore.API.Database.Context
{
    public class PetShopContext : DbContext
    {
        public DbSet<Pet> Pet { get; set; }

        public PetShopContext(DbContextOptions<PetShopContext> options)
            : base(options)
        {
            // this.Database.EnsureCreated();
        }
    }
}
