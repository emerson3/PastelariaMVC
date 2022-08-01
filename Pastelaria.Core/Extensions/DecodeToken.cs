namespace Pastelaria.Core.Extensions
{
    public static class DecodeToken
    {
        public enum PropertyTokenEnum 
        {
            Nome = 1,
            Email = 2
        }
        
        public static JwtSecurityToken handler(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var readToken = handler.ReadToken(token) as JwtSecurityToken;
            return readToken;
        }

        public static int getId(string token)
        {
            var readToken = handler(token);
            var idUsuario = readToken.Claims.ToList()[0].Value;

            if (int.TryParse(idUsuario, out int num))
                return num;
            
            return default;
        }

        public static string GetProperty(string token, PropertyTokenEnum propertyTokenEnum)
        {
            var readToken = handler(token);
            return readToken.Claims.ToList()[(int)propertyTokenEnum].Value;
        }
    }
}
