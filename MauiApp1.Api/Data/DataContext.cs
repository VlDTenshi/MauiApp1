using MauiApp1.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace MauiApp1.Api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<MedicineOption> MedicineOptions { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MedicineOption>()
                        .HasKey(uo => new { uo.MedicineId, uo.Type });

            AddSeedData(modelBuilder);
        }

        private static void AddSeedData(ModelBuilder modelBuilder)
        {
            Medicine[] medicines = [
                new Medicine{Id=1, Name="", Image="", Price=1.1}


                ];
            MedicineOption[] medicineOptions = [
                new MedicineOption {MedicineId=1, Type="Solid" }

                ];

            modelBuilder.Entity<Medicine>()
                    .HasData(medicines);

            modelBuilder.Entity<MedicineOption>()
                    .HasData(medicineOptions);
        }
        //Add-Migration Initial -o Data/Migrations
    }
}
