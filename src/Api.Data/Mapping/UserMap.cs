using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class UserMap : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            // Define nome da tabela
            builder.ToTable("User");
            // Define chave primária
            builder.HasKey(x => x.Id);
            // Define o index (retorna um objeto que pode ser configurado) e que e-mail não pode se repetir
            builder.HasIndex(x => x.Email).IsUnique();
            // Define que nome é requerido e tamanho máximo 60
            builder.Property(x => x.Name).IsRequired().HasMaxLength(60);
            builder.Property(x => x.Email).HasMaxLength(100);


        }
    }
}
