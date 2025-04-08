using Ingresso.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ingresso.Infra.Data.Maps
{
    public class MovieMap : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.ToTable("filme");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .IsRequired()
                .HasColumnName("id");

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(150)
                .HasColumnName("nome");
            
            builder.Property(x => x.Classification)
                .HasColumnName("classificacao");
            
            builder.Property(x => x.Gender)
                .IsRequired()
                .HasMaxLength(150)
                .HasColumnName("genero");
            
            builder.Property(x => x.Duration)
                .HasMaxLength(4)
                .HasColumnName("duracao");
            
            builder.Property(x => x.PremiereDate)
                .IsRequired()
                .HasColumnName("data_estreia");
            
            builder.Property(x => x.Trending)
                .IsRequired()
                .HasDefaultValue(false)
                .HasColumnName("em_alta");
            
            builder.Property(x => x.PreSale)
                .IsRequired()
                .HasDefaultValue(false)
                .HasColumnName("pre_venda");
            
            builder.Property(x => x.Slug)
                .IsRequired()
                .HasMaxLength(150)
                .HasColumnName("slug");
            
            builder.Property(x => x.PublicIdPosterImage)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("id_publico_imagem_cartaz");
            
            builder.Property(x => x.PublicIdBannerImage)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("id_publico_imagem_banner");

            builder.Property(x => x.PosterImage)
                .IsRequired()
                .HasMaxLength(250)
                .HasColumnName("imagem_cartaz");
            
            builder.Property(x => x.BannerImage)
                .IsRequired()
                .HasMaxLength(250)
                .HasColumnName("imagem_banner");

            builder.HasOne(x => x.MovieDescription)
                .WithOne(x => x.Movie)
                .HasForeignKey<MovieDescription>(x => x.MovieId);
        }
    }
}
