namespace Pastelaria.Core.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Usuario> BuscarPorEmailAsync(string email);
        Task<IEnumerable<Tarefa>> BuscarPorTarefaAsync();
    }
}