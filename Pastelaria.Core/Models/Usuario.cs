namespace Pastelaria.Core.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public int IdTipoUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime DataExpiracaoSenha { get; set; }
        public int IdUsuarioCadastro { get; set; }
        
        public IEnumerable<UsuarioTarefa> UsuarioTarefas {get; set; }
    }
}