using Ingresso.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ingresso.Infra.Data.Maps
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("usuario");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .IsRequired()
                .HasColumnName("id");

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("nome");

            builder.Property(x => x.CPF)
                .IsRequired()
                .HasMaxLength(11)
                .HasColumnName("cpf");

            builder.Property(x => x.PhoneDdd)
                .IsRequired()
                .HasMaxLength(2)
                .HasColumnName("ddd_telefone");

            builder.Property(x => x.PhoneNumber)
                .IsRequired()
                .HasMaxLength(9)
                .HasColumnName("numero_telefone");

            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("email");

            builder.Property(x => x.Password)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("senha");

            builder.Property(x => x.DateOfBirth)
                .HasColumnName("data_nascimento")
                .HasColumnType("date");

            builder.Property(x => x.ReceiveNotification)
                .IsRequired()
                .HasDefaultValue(false)
                .HasColumnName("receber_notificacao");

            builder.Property(x => x.UserValid)
                .IsRequired()
                .HasDefaultValue(false)
                .HasColumnName("usuario_valido");

            builder.OwnsOne(u => u.Address, address =>
            {
                address.Property(a => a.CEP)
                    .HasMaxLength(8)
                    .HasColumnName("cep");
                address.Property(a => a.Street)
                    .HasMaxLength(50)
                    .HasColumnName("rua");
                address.Property(a => a.HouseNumber)
                    .HasMaxLength(10)
                    .HasColumnName("numero_casa");
                address.Property(a => a.Complement)
                    .HasMaxLength(100)
                    .HasColumnName("complemento");
                address.Property(a => a.Neighborhood)
                    .HasMaxLength(50)
                    .HasColumnName("bairro");
                address.Property(a => a.State)
                    .HasMaxLength(2)
                    .HasColumnName("estado");
                address.Property(a => a.City)
                    .HasMaxLength(40)
                    .HasColumnName("cidade");
            });
        }
    }
}
