using System.ComponentModel.DataAnnotations;
namespace MeetingApp.Models
{
    public class UserInfo
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Ad alanı boş bırakılamaz")]
        public string? Name { get; set; }
        [Required(ErrorMessage ="Telefon alanı boş bırakılamaz")]
        public string? Phone { get; set; }
        [Required]
        [EmailAddress(ErrorMessage ="Hatalı veya eksik email")]
        public string? Email { get; set; }
        [Required(ErrorMessage ="bir durum belirtin")]
        public bool? WillAttend { get; set; }
    }
}