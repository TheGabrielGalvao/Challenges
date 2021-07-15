using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositorio.Config
{
    public class SolicitacaoConfiguration : IEntityTypeConfiguration<Solicitacao>
    {
        public void Configure(EntityTypeBuilder<Solicitacao> builder)
        {
            builder.HasKey(s => s.Id);

            builder
                .Property(s => s.Numero)
                .IsRequired()
                .HasMaxLength(10);

            builder
                .Property(s => s.Descricao)
                .IsRequired()
                .HasMaxLength(500)
                .HasColumnType("Text");

            builder
                .Property(s => s.Responsavel)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .Property(s => s.Status)
                .IsRequired();

        }
    }
}
