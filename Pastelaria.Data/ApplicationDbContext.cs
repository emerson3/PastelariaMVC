using Microsoft.EntityFrameworkCore;
using Pastelaria.Core.Settings;

namespace Pastelaria.Data
{
    public class ApplicationDbContext : BaseDbContext
    {
        public ApplicationDbContext(AppSettings appSettings) : base(appSettings, "Application")
        {

        }
        
    }
}