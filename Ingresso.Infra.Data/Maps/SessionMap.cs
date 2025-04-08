using System.Security.Cryptography.X509Certificates;
using Ingresso.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ingresso.Infra.Data.Maps
{
    public class SessionMap : IEntityTypeConfiguration<Session>
    {
        public void Configure(EntityTypeBuilder<Session> builder)
        {
            builder.ToTable("sessao");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .IsRequired()
                .HasColumnName("id");

            builder.Property(x => x.Date)
                .IsRequired()
                .HasColumnType("timestamptz")
                .HasColumnName("data");

            builder.Property(x => x.Type)
                .IsRequired()
                .HasColumnName("tipo")
                .HasColumnType("varchar(20)[]");

            builder.Property(x => x.CinemaId)
                .IsRequired()
                .HasColumnName("cinema_id");

            builder.Property(x => x.MovieId)
                .IsRequired()
                .HasColumnName("filme_id");

            builder.Property(x => x.CinemaRoomId)
                .IsRequired()
                .HasColumnName("sala_cinema_id");

            builder.HasOne(x => x.Cinema)
                .WithMany(x => x.Sessions)
                .HasForeignKey(x => x.CinemaId);

            builder.HasOne(x => x.Movie)
                .WithMany()
                .HasForeignKey(x => x.MovieId);

            builder.HasOne(x => x.CinemaRoom)
                .WithMany(x => x.Sessions)
                .HasForeignKey(x => x.CinemaRoomId);

        }
    }
}
