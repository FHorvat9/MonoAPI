

using Microsoft.EntityFrameworkCore;
using Mono.DAL.Entities;



namespace DAL
{
    public class VehicleMakeDBContext : DbContext
    {
        public VehicleMakeDBContext(DbContextOptions<VehicleMakeDBContext> options):base(options)
        {
            
        }

        public DbSet<VehicleMakeEntity> VehicleMakes { get; set;}

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<VehicleMakeEntity>().ToTable("Vehicle makes");
        }

       
    }

}
