namespace Pastelaria.Mvc.Controllers
{
    [Route("Usuario")]
    public class UsuarioController : AuthenticatedController
    {
        private readonly AppSettings _appSettings;
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository, AppSettings appSettings)
        {
            _usuarioRepository = usuarioRepository;
            _appSettings = appSettings;
        }

        public async Task<IActionResult> IndexTarefa(UsuarioViewModel usuarioViewModel)
        {
            var usuario = await _usuarioRepository.BuscarAsync();

            return View("_CadastrarTarefa", usuario);
        }
        [HttpGet("cadastrar")]
        public async Task<IActionResult> IndexUsuario()
        {
            return View("_CadastrarUsuario");
        }

        [HttpPost("cadastrar-tarefa")]
        public async Task<IActionResult> CadastrarTarefa(CadastrarViewModel cadastrarViewModel)
        {
            if (cadastrarViewModel == null)
                return BadRequest("Nenhum parâmetro foi enviado");

            await _usuarioRepository.CadastrarTarefaAsync(new Tarefa
            {
                Titulo = cadastrarViewModel.Titulo,
                Descricao = cadastrarViewModel.Descricao,
                IdTarefaStatus = 1,
                DataCriacao = DateTime.Now,
                IdUsuarioCadastro = cadastrarViewModel.IdUsuarioCadastro
            });

            return Ok();
        }

        [HttpPost("cadastrar-usuario")]
        public async Task<IActionResult> CadastrarUsuario(CadastrarUsuarioViewModel cadastrarUsuarioViewModel)
        {
            if (cadastrarUsuarioViewModel == null)
                return BadRequest("Nenhum parâmetro foi enviado");

            var usuario = await _usuarioRepository.BuscarPorEmailAsync(cadastrarUsuarioViewModel.Email);

            if (usuario != null)
                return BadRequest("Usuário já cadastrado!");

            await _usuarioRepository.CadastrarUsuarioAsync(new Usuario
            {
                Nome = cadastrarUsuarioViewModel.Nome,
                Email = cadastrarUsuarioViewModel.Email,
                Senha = "111111",
                DataExpiracaoSenha = DateTime.Now.AddMonths(6),
                IdTipoUsuario = cadastrarUsuarioViewModel.IdTipoUsuario
            });

            return Ok();
        }

        [HttpGet("tarefa")]
        public async Task<IActionResult> VisualizarTarefa(int Id)
        {
            var tarefa = await _usuarioRepository.FiltrarTarefasAsync(Id);

            return View("_MostrarTarefa", tarefa);
        }

        [HttpPost("editar")]
        public async Task<IActionResult> EditarTarefa(TarefaViewModel tarefaViewModel)
        {

            if (tarefaViewModel == null)
                return BadRequest("Nenhum dado enviado.");

            await _usuarioRepository.EditarTarefaAsync(tarefaViewModel.Id, new
            {
                Titulo = tarefaViewModel.Titulo,
                Descricao = tarefaViewModel.Descricao,
                IdTarefaStatus = tarefaViewModel.IdTarefaStatus
            });

            return RedirectToAction("Index", "Home");
        }
    }
}