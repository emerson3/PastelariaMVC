namespace Pastelaria.Mvc.Controllers
{
    [Route("Login")]
    public class LoginController : Controller
    {
        private readonly ApplicationDbContext _applicationDbcontext;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly Notification _notification;
        private readonly AppSettings _appSettings;
        private readonly string _baseUrlMvc;

         public LoginController(
            ApplicationDbContext applicationDbContext,
            IUsuarioRepository usuarioRepository,
            Notification notification,
            AppSettings appSettings
        )

        {
            _applicationDbcontext = applicationDbContext;
            _usuarioRepository = usuarioRepository;
            _notification = notification;
            _appSettings = appSettings;
            _baseUrlMvc = appSettings.BaseUrlSettings.LinkRedirectMvc;
        }

        public IActionResult Index()
        {
            var session = HttpContext.Session.Get<Usuario>("Usuario");
            if (session != null)
                return RedirectToAction("Index", "Home");

            return View();
        }
        
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            var usuario = await _usuarioRepository.BuscarPorEmailAsync(loginViewModel.Email);
            
            if (usuario == null || loginViewModel.Senha != usuario.Senha)
                return BadRequest("Email ou senha incorretos!");

            if(DateTime.Now >= usuario.DataExpiracaoSenha )
                return BadRequest("Senha Expirada!");

            HttpContext.Session.Set<Usuario>("Usuario", usuario);

            return View("Index", "Home");
        }
    }
}
