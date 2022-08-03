namespace Pastelaria.Core.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Usuario> BuscarPorEmailAsync(string email);
        Task <IEnumerable<Usuario>> BuscarAsync();
        Task<IEnumerable<Tarefa>> BuscarTarefasAsync(int id);

        Task CadastrarTarefaAsync(Tarefa tarefa);
        Task CadastrarUsuarioAsync(Usuario usuario);
        Task<IEnumerable<Tarefa>> TodasTarefasAsync();
        Task<IEnumerable<Tarefa>> FiltrarTarefasAsync(int id);

        Task EditarTarefaAsync(int id, object camposEditados);
    }
}