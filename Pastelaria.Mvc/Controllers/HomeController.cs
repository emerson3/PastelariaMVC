namespace Pastelaria.Mvc.Controllers
{
    public class HomeController : AuthenticatedController
    {
        private readonly AppSettings _appSettings;
        private readonly IUsuarioRepository _usuarioRepository;

        public HomeController(IUsuarioRepository usuarioRepository, AppSettings appSettings)
        {
            _usuarioRepository = usuarioRepository;
            _appSettings = appSettings;
        }
        public async Task<IActionResult> Index(TarefaViewModel tarefaViewModel)
        {
            if(tarefaViewModel == null)
                return BadRequest("Nenhuma tarefa encontrada!");
            
            var InformacoesUsuario = HttpContext.Session.Get<Usuario>("Usuario");
            var usuario = await _usuarioRepository.BuscarPorEmailAsync(InformacoesUsuario.Email);

            Console.WriteLine(usuario.IdTipoUsuario);

            if (usuario.IdTipoUsuario == 2)
            {
                var TarefasBuscadas = await _usuarioRepository.BuscarTarefasAsync(usuario.Id);

                tarefaViewModel.Tarefas = TarefasBuscadas;
            } else {
                var Tarefas = await _usuarioRepository.TodasTarefasAsync();
                tarefaViewModel.Tarefas = Tarefas;
            }
            
            return View(tarefaViewModel);
            
        }
    }
}