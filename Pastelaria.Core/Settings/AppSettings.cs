namespace Pastelaria.Core.Settings
{
    public class AppSettings
    {
        public ConnectionString ConnectionString { get; set; }
        public CryptographySettings CriptografiaSettings { get; set; }
        public BaseUrlSettings BaseUrlSettings { get; set; }
        public TokenSettings TokenSettings { get; set; }
    }
}