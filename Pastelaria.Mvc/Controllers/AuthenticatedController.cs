namespace Pastelaria.Mvc.Controllers
{
    public class AuthenticatedController : Controller
    {
        public Session UsuarioLogado { get; set; }
        public Session UsuarioSession { get; set; }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            
            UsuarioSession = HttpContext.GetSession();
            if (UsuarioSession != null)
            {
                TempData["Nome"] = UsuarioSession.Nome;
                TempData["Email"] = UsuarioSession.Email;
            }
            
            var user = context.HttpContext.Session.Get<Usuario>("Usuario");
            if (user == null || user.Id == default)
                context.Result = new RedirectResult("/login");
        }
    }
}