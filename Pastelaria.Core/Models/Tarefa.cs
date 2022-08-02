namespace Pastelaria.Core.Models
{
    public class Tarefa
    {
        public Tarefa()
        {

        }
        
        public int Id { get; set; }
        public int IdTarefaStatus { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataConclusao { get; set; }
        public int IdUsuarioCadastro { get; set; }
        
        public IEnumerable<UsuarioTarefa> UsuarioTarefas {get; set; }
    }
}