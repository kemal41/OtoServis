using OtoServis.Entities.Web;
using System.Data.Entity;

namespace OtoServis.DAL
{
    public class DataContext : DbContext
    {
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Kampanya> Kampanyalar { get; set; }
    }
}
