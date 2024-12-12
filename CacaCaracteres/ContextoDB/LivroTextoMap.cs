using CacaCaracteres.Modelo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CacaCaracteres.ContextoDB;

public class LivroTextoMap : IEntityTypeConfiguration<LivroTexto>
{
    public void Configure(EntityTypeBuilder<LivroTexto> builder)
    {
        builder.Property(p => p.AutorId);

        builder.HasOne(e => e.Autor).WithMany(e => e.LivroTexto).HasForeignKey(e => e.AutorId);


    }
}
