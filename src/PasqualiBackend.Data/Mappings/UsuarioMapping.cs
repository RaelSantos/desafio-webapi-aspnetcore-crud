using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PasqualiBackend.Business.Models;

namespace PasqualiBackend.Data.Mappings
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(p => p.Cpf)
                   .IsRequired()
                  .HasColumnType("varchar(11)");

            builder.Property(p => p.DataNascimento)
                .IsRequired()
                .HasColumnType("date");

            builder.Property(p => p.Renda)
                .IsRequired()
                .HasColumnType("decimal(18,2)");

            builder.ToTable("Usuarios");
        }
    }
}
