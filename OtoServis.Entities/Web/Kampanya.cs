using System.ComponentModel.DataAnnotations;

namespace OtoServis.Entities.Web
{
    public class Kampanya
    {
        [Key]
        public int KampanyaId { get; set; }

        public string Icerik { get; set; }
    }
}
