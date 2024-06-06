using System.ComponentModel.DataAnnotations;

namespace ThisIsSnackis.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Display(Name = "Kategori")]
        public string? Name { get; set; }

        [Display(Name = "Beskrivning")]
        public string? Description { get; set; }
        public ICollection<Post>? Posts { get; set; }
    }
}
