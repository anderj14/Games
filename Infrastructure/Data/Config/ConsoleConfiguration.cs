
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class ConsoleConfiguration : IEntityTypeConfiguration<GameConsole>
    {
        public void Configure(EntityTypeBuilder<GameConsole> builder)
        {
            builder.Property(gm => gm.Id).IsRequired();
            builder.Property(gm => gm.ConsoleName).IsRequired().HasMaxLength(150);
            builder.Property(gm => gm.Manufacturer).IsRequired();
            builder.Property(gm => gm.ReleaseDate).IsRequired();
            builder.Property(gm => gm.Price).HasColumnType("decimal(18,2)");
            builder.Property(gm => gm.PictureUrl).IsRequired();

            builder.HasOne(gm => gm.TechnicalSpecification).WithMany()
                .HasForeignKey(gm => gm.TechnicalSpecificationId);
            builder.HasOne(gm => gm.Brand).WithMany()
                .HasForeignKey(gm => gm.BrandId);
            builder.HasOne(gm => gm.Company).WithMany()
                .HasForeignKey(gm => gm.CompanyId);
            // builder.HasMany(gm => gm.Games).WithOne(g => g.GameConsole)
            //     .HasForeignKey(g => g.GameConsoleId);
        }
    }
}