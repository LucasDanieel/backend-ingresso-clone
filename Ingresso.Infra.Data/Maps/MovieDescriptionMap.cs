using Ingresso.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ingresso.Infra.Data.Maps
{
    public class MovieDescriptionMap : IEntityTypeConfiguration<MovieDescription>
    {
        public void Configure(EntityTypeBuilder<MovieDescription> builder)
        {
            builder.ToTable("descricao_filme");

            builder.HasKey(x => x.MovieId);

            builder.Property(x => x.MovieId)
                .IsRequired()
                .HasColumnName("filme_id");

            builder.Property(x => x.Description)
                .IsRequired()
                .HasColumnName("descricao");
            
            builder.Property(x => x.OriginalName)
                .IsRequired()
                .HasMaxLength(150)
                .HasColumnName("nome_original");
            
            builder.Property(x => x.Direction)
                .HasMaxLength(100)
                .HasColumnName("direcao");
            
            builder.Property(x => x.Distributor)
                .HasMaxLength(100)
                .HasColumnName("distribuidor");
            
            builder.Property(x => x.Country)
                .HasMaxLength(20)
                .HasColumnName("pais");

            builder.HasOne(x => x.Movie)
                .WithOne(x => x.MovieDescription)
                .HasForeignKey<MovieDescription>(x => x.MovieId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
