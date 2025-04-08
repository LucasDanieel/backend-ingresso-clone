using Ingresso.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ingresso.Infra.Data.Maps
{
    public class CityMap : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.ToTable("cidade");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id");
            
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(40)
                .HasColumnName("nome");
            
            builder.Property(x => x.State)
                .IsRequired()
                .HasMaxLength(40)
                .HasColumnName("estado");
            
            builder.Property(x => x.UF)
                .IsRequired()
                .HasMaxLength(2)
                .HasColumnName("uf");
            
            builder.Property(x => x.Slug)
                .IsRequired()
                .HasMaxLength(40)
                .HasColumnName("slug");

            builder.HasMany(x => x.Cinemas)
                .WithOne(x => x.City)
                .HasForeignKey(x => x.CityId);
        }
    }
}
