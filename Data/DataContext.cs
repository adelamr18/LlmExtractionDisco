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
        public DbSet<ReceiptHeaderMetadata> ReceiptHeaderMetadatas { get; set; }
        public DbSet<ReceiptFinancialMetadata> ReceiptFinancialMetadatas { get; set; }
        public DbSet<ReceiptDeliveryMetadata> ReceiptDeliveryMetadatas { get; set; }
        public DbSet<ReceiptMerchantContactsMetadata> ReceiptMerchantContactsMetadatas { get; set; }

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

                entity.Property(e => e.DiscountValue)
                .HasColumnType("decimal(18,2)");
                entity.Property(e => e.ItemPrice)
                      .HasColumnType("decimal(18,2)");
                entity.Property(e => e.ItemTotalPrice)
                      .HasColumnType("decimal(18,2)");
            });

            modelBuilder.Entity<ReceiptHeaderMetadata>(entity =>
           {
               entity.HasKey(x => x.HeaderMetadataId);
               entity.HasOne(x => x.Receipt)
                     .WithOne(x => x.ReceiptHeaderMetadata)
                     .HasForeignKey<ReceiptHeaderMetadata>(x => x.ReceiptId)
                     .OnDelete(DeleteBehavior.Cascade);
           });


            modelBuilder.Entity<ReceiptFinancialMetadata>(entity =>
            {
                entity.HasKey(x => x.FinancialMetadataId);
                entity.HasOne(x => x.Receipt)
                      .WithOne(x => x.ReceiptFinancialMetadata)
                      .HasForeignKey<ReceiptFinancialMetadata>(x => x.ReceiptId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<ReceiptDeliveryMetadata>(entity =>
           {
               entity.HasKey(x => x.DeliveryMetadataId);
               entity.HasOne(x => x.Receipt)
                     .WithOne(x => x.ReceiptDeliveryMetadata)
                     .HasForeignKey<ReceiptDeliveryMetadata>(x => x.ReceiptId)
                     .OnDelete(DeleteBehavior.Cascade);
           });

            modelBuilder.Entity<ReceiptMerchantContactsMetadata>(entity =>
           {
               entity.HasKey(x => x.MerchantContactsMetadataId);
               entity.HasOne(x => x.Receipt)
                     .WithOne(x => x.ReceiptMerchantContactsMetadata)
                     .HasForeignKey<ReceiptMerchantContactsMetadata>(x => x.ReceiptId)
                     .OnDelete(DeleteBehavior.Cascade);
           });
        }
    }
}
