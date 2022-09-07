using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.Internal;

namespace InventorySystem.Models
{
    public class InventoryDb : DbContext
    {
        public InventoryDb(DbContextOptions<InventoryDb> options)
            : base(options)
        {
        }

        public virtual DbSet<Products> Products { get; set; }

        public virtual DbSet<Bags> Bags { get; set; }

    }
}
