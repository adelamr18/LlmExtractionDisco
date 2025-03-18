using LlmExtractionApi.Models;
using Microsoft.EntityFrameworkCore;

namespace LlmExtractionApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<ReceiptItem> ReceiptItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Receipt>(entity =>
            {
                entity.HasKey(r => r.ReceiptId);
                entity.Property(r => r.ReceiptId).ValueGeneratedNever();
            });

            modelBuilder.Entity<ReceiptItem>(entity =>
            {
                entity.HasKey(i => i.ItemId);

                entity
                  .HasOne(i => i.Receipt)
                  .WithMany(r => r.ReceiptItems)
                  .HasForeignKey(i => i.ReceiptId)
                  .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
