using System.ComponentModel.DataAnnotations;

namespace ThisIsSnackis.Models
{
    public class Report
    {
        public int Id { get; set; }

        [Display(Name = "Anmälan:")]
        public string? Description { get; set; }

        [Display(Name = "Anmälare:")]
        public string? UserId { get; set; }

        [Display(Name = "Anmälan inkom:")]
        public DateTime CreatedAt { get; set; }

        [Display(Name = "Inlägg nummer:")]
        public int PostId { get; set; }
    }
}
