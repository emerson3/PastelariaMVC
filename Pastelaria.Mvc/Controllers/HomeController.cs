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
            var Tarefas = await _usuarioRepository.BuscarPorTarefaAsync();
            
            tarefaViewModel.Tarefas = Tarefas;

            return View(tarefaViewModel);
            
        }
    }
}