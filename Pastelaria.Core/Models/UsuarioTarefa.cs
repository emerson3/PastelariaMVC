namespace Pastelaria.Core.Models
{
    public class UsuarioTarefa
    {
        public int IdUsuario { get; set; }
        public int IdTarefa { get; set; }

        public Usuario Usuario { get; set; }
        public Tarefa Tarefa { get; set; }
    }
}