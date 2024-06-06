using System.ComponentModel.DataAnnotations;

namespace ThisIsSnackis.Models
{
    public class Comment
    {
        public int Id { get; set; }

        [Display(Name = "Kommentar:")]
        public string? Text { get; set; }

        [Display(Name = "Skapare:")]
        public string? UserId { get; set; }

        [Display(Name = "Inläggsnummer:")]
        public int ThePostId { get; set; }
    }
}
