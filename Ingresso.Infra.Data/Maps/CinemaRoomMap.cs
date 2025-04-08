using Ingresso.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ingresso.Infra.Data.Maps
{
    public class CinemaRoomMap : IEntityTypeConfiguration<CinemaRoom>
    {
        public void Configure(EntityTypeBuilder<CinemaRoom> builder)
        {
            builder.ToTable("sala_cinema");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .IsRequired()
                .HasColumnName("id");
            
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnName("nome");
            
            builder.Property(x => x.CinemaId)
                .IsRequired()
                .HasColumnName("cinema_id");

            builder.HasOne(x => x.Cinema)
                .WithMany(x => x.CinemaRooms)
                .HasForeignKey(x => x.CinemaId);
        }
    }
}
