using System.ComponentModel.DataAnnotations;

namespace ThisIsSnackis.Models
{
    public class UserPicture
    {
        public int Id { get; set; }

        [Display(Name = "Bild:")]
        public string? Image { get; set; }

        [Display(Name = "Användare:")]
        public string? UserId { get; set; }

    }
}
