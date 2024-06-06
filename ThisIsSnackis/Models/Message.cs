using System.ComponentModel.DataAnnotations;

namespace ThisIsSnackis.Models
{
    public class Message
    {
        public int Id { get; set; }

        [Display(Name = "Rubrik:")]
        public string? Title { get; set; }

        [Display(Name = "Meddelande:")]
        public string? Text { get; set; }

        [Display(Name = "Avsändare:")]
        public string? SenderId { get; set; }

        [Display(Name = "Mottagare:")]
        public string? ReciverId { get; set; }
    }
}
