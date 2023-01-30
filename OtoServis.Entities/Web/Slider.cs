using System.ComponentModel.DataAnnotations;

namespace OtoServis.Entities.Web
{
    public class Slider
    {
        [Key]
        public int SliderId { get; set; }
        [MaxLength(100)]
        public string Baslik { get; set; }
        [MaxLength(500)]
        public string Tanımlama { get; set; }
        [MaxLength(500)]
        public string Resim { get; set; }


    }
}
