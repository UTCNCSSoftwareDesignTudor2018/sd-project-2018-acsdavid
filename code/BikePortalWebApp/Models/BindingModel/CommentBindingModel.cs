using System.ComponentModel.DataAnnotations;

namespace BikePortalWebApp.Models.BindingModel
{
    public class CommentBindingModel
    {
        [Required]
        [StringLength(1000, ErrorMessage = 
            "The {0} must be at least {2} characters long and must not be longer than {1} characters", 
            MinimumLength = 5)]
        [Display(Name = "Comment text")]
        public string CommentText { get; set; }
    }
}