using System.ComponentModel.DataAnnotations;

namespace ThisIsSnackis.Models
{
    public class Header
    {
        public int Id { get; set; }

        [Display(Name = "Rubriken")]
        public string? TheHeader { get; set; }
    }
}
