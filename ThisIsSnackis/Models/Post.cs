using System.ComponentModel.DataAnnotations;

namespace ThisIsSnackis.Models
{
    public class Post
    {
        public int Id { get; set; }

        [Display(Name = "Rubrik:")]
        public string? Title { get; set; }

        [Display(Name = "Inlägg:")]
        public string? ThePost { get; set; }

        [Display(Name = "Skapare:")]
        public string? AuthorId { get; set; }

        [Display(Name = "Skapat den:")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Du måste välja en kategori")]

        [Display(Name = "Kategori:")]
        public int TheCategoryId { get; set; }
        public Category? TheCategory { get; set; }

        public string? ProfilePicture { get; set; }

    }
}
