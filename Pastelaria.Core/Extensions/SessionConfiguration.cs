using Newtonsoft.Json;

namespace Pastelaria.Core.Extensions
{
    public static class SessionConfigurations
    {
        public static Session GetSession(this HttpContext context)
        {
            var usuario = context.Session.Get<Usuario>("Usuario");

            if (usuario == null)
                return null;

            var session = new Session()
            {
                IdUsuario = usuario.Id,
                Email = usuario.Email,
                Nome = usuario.Nome
            };
            return session;
        }

        public static async Task<T> DeserializeObject<T>(this HttpResponseMessage response)
        {
            string json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
