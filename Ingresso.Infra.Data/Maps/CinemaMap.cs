using Ingresso.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ingresso.Infra.Data.Maps
{
    public class CinemaMap : IEntityTypeConfiguration<Cinema>
    {
        public void Configure(EntityTypeBuilder<Cinema> builder)
        {
            builder.ToTable("cinema");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id");

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("nome");
            
            builder.Property(x => x.Street)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("rua");
            
            builder.Property(x => x.Number)
                .IsRequired()
                .HasMaxLength(10)
                .HasColumnName("numero");
            
            builder.Property(x => x.Neighborhood)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("bairro");
            
            builder.Property(x => x.CityName)
                .IsRequired()
                .HasMaxLength(40)
                .HasColumnName("cidade");
            
            builder.Property(x => x.Phone)
                .HasMaxLength(16)
                .HasColumnName("telefone");
            
            builder.Property(x => x.Slug)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("slug");
            
            builder.Property(x => x.PublicIdLogoImage)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("id_publico_imagem_logo");
            
            builder.Property(x => x.PublicIdBannerImage)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("id_publico_imagem_banner");
            
            builder.Property(x => x.LogoImage)
                .IsRequired()
                .HasMaxLength(250)
                .HasColumnName("imagem_logo");
            
            builder.Property(x => x.BannerImage)
                .IsRequired()
                .HasMaxLength(250)
                .HasColumnName("imagem_banner");
            
            builder.Property(x => x.SellProduct)
                .HasDefaultValue(false)
                .HasColumnName("venda_produto");
            
            builder.Property(x => x.MobileTicket)
                .HasDefaultValue(true)
                .HasColumnName("ingresso_celular");
            
            builder.Property(x => x.CityId)
                .HasColumnName("cidade_id");

            builder.HasOne(x => x.City)
                .WithMany(x => x.Cinemas)
                .HasForeignKey(x => x.CityId);
        }
    }
}
