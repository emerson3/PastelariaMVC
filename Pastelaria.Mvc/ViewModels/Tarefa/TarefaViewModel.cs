namespace Pastelaria.Mvc.ViewModels.Tarefa
{
    public class TarefaViewModel

    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public IEnumerable<Core.Models.Tarefa> Tarefas { get; set; }
    }
}