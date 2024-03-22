using System.ComponentModel.DataAnnotations;

namespace efcoreApp.Data
{
    public class Ogretmen
    {
        [Key]
        public int OgretmenId { get; set; }
        public string? Ad { get; set; }
        public string? SoyAd { get; set; }
        public string AdSoyad { 
            get
            {
                return this.Ad + " " + this.SoyAd;
            }
            }
        public string? Eposta { get; set; }
        public string? Telefon { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}",ApplyFormatInEditMode = false)]
        public DateTime BaslamaTarihi { get; set; }
        public ICollection<Kurs> Kurslar { get; set; } = new List<Kurs>();
    }
}