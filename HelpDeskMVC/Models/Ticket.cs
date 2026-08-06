using System.ComponentModel.DataAnnotations;

namespace HelpDeskMVC.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a ticket title.")]
        [StringLength(100)]
        [Display(Name = "Ticket Title")]
        public string Title { get; set; }

        [Display(Name = "Issue Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please select a priority.")]
        public string Priority { get; set; }

        [Required(ErrorMessage = "Please select a status.")]
        public string Status { get; set; }

        [Required(ErrorMessage = "Please enter your name.")]
        [Display(Name = "Raised By")]
        public string RaisedBy { get; set; }

        [Required]
        [Display(Name = "Created On")]
        public DateTime CreatedDate { get; set; }
    }
}