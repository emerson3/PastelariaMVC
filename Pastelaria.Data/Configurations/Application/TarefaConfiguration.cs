namespace Pastelaria.Data.Configurations.Application
{
    public class TarefaConfiguration : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            builder.ToTable("tarefa");

            builder.HasKey(property => property.Id).HasName("pk_tarefa");
            
            builder.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
            builder.Property(x => x.IdTarefaStatus).HasColumnName("idTarefaStatus");
            builder.Property(x => x.Titulo).HasColumnName("titulo").HasMaxLength(45);
            builder.Property(x => x.Descricao).HasColumnName("descricao").HasMaxLength(100);
            builder.Property(x => x.DataCriacao).HasColumnName("dataCriacao").HasMaxLength(30);
            builder.Property(x => x.DataConclusao).HasColumnName("dataConclusao");
            builder.Property(x => x.IdUsuarioCadastro).HasColumnName("idUsuarioCadastro");
        }
    }
}