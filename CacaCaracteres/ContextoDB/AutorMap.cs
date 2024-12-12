using CacaCaracteres.Modelo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CacaCaracteres.ContextoDB;

public class AutorMap : IEntityTypeConfiguration<Autor>
{
    public void Configure(EntityTypeBuilder<Autor> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Codigo).IsRequired();
        builder.Property(x => x.Nome).HasMaxLength(20).IsRequired();
    }
}
