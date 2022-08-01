namespace Pastelaria.Data.Configurations.Application
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("usuario");

            builder.HasKey(property => property.Id).HasName("pk_usuario");
            
            builder.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
            builder.Property(x => x.IdTipoUsuario).HasColumnName("idTipoUsuario");
            builder.Property(x => x.Nome).HasColumnName("nome").HasMaxLength(45);
            builder.Property(x => x.Email).HasColumnName("email").HasMaxLength(100);
            builder.Property(x => x.Senha).HasColumnName("senha").HasMaxLength(30);
            builder.Property(x => x.DataExpiracaoSenha).HasColumnName("dataExpiracaoSenha");
            builder.Property(x => x.IdUsuarioCadastro).HasColumnName("idUsuarioCadastro");
        }
    }
}