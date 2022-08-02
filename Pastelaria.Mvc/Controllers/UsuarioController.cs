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

        public async Task<IActionResult> Index(UsuarioViewModel usuarioViewModel)
        {
            var usuarios = await _usuarioRepository.BuscarAsync();

            usuarioViewModel.Usuarios = usuarios;
            
            return View("Index", usuarioViewModel);
        }
    }
}