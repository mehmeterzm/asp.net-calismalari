using System.ComponentModel.DataAnnotations;

namespace efcoreApp.Data
{
    public class Ogrenci
    {
        // idd =>> primary key
        [Key]
        public int OgrenciId { get; set; } //Id kullanırsan burayı kendi anlar yazmazsan key diye ekle gocuuuuum
        public string? OgrenciAd { get; set; }
        public string? OgrenciSoyad { get; set; }
        public string AdSoyad { get{
            return this.OgrenciAd + " " + this.OgrenciSoyad;
        } }
        public string? Eposta { get; set; }
        public string? Telefon { get; set; }
        
        public ICollection<KursKayit> KursKayitlari { get; set;} = new List<KursKayit>();

    }
}
