using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace FormApp
{
    //  [Bind("Name","Price")]
    
    public class Product
    {
       
        [Display(Name="Ürün Id")]
        // [BindNever]
        public int ProductId { get; set; }

        [Required(ErrorMessage ="Ad alanını doldurunuz!")]
        [Display(Name="Ürün Adı")]
        public string Name { get; set; } = null!;

        [Required]
        [Display(Name="Fiyat")]
        [Range(0,100000)]
        public decimal? Price { get; set; }

        [Display(Name="Resim")]
        public string? Image { get; set; } = string.Empty;
        public bool IsActive { get; set; } 

        [Required]
        [Display(Name="Category")]    
        public int? CategoryId { get; set; }
       
    }
}