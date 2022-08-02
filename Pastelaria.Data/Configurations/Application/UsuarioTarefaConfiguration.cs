namespace Pastelaria.Data.Configurations.Application
{
    public class UsuarioTarefaConfiguration : IEntityTypeConfiguration<UsuarioTarefa>
    {
        public void Configure(EntityTypeBuilder<UsuarioTarefa> builder)
        {
            builder.ToTable("usuarioTarefa");

            builder.HasKey(property => property.IdUsuario).HasName("fk_usuariotarefa_usuariotarefa");
            builder.HasKey(property => property.IdTarefa).HasName("fk_usuariotarefa_tarefa");

            builder.Property(x => x.IdUsuario).HasColumnName("idUsuario");
            builder.Property(x => x.IdTarefa).HasColumnName("idTarefa");

            builder.HasOne(x => x.Usuario).WithMany(x => x.UsuarioTarefas).HasForeignKey(x => x.IdUsuario);
            builder.HasOne(x => x.Tarefa).WithMany(x => x.UsuarioTarefas).HasForeignKey(x => x.IdTarefa);
        }
    }
}