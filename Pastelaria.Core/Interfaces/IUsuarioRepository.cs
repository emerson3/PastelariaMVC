namespace Pastelaria.Core.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Usuario> BuscarPorEmailAsync(string email);
        Task<Usuario> BuscarAsync();
        Task<IEnumerable<Tarefa>> BuscarTarefasAsync(int id);

        Task<IEnumerable<Tarefa>> TodasTarefasAsync();
        
    }
}