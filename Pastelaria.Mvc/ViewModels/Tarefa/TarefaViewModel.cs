namespace Pastelaria.Mvc.ViewModels.Tarefa
{
    public class TarefaViewModel

    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public int IdTarefaStatus { get; set; }
        public IEnumerable<Core.Models.Tarefa> Tarefas { get; set; }
        public IEnumerable<Core.Models.UsuarioTarefa> UsuarioTarefas { get; set; }
    }
}