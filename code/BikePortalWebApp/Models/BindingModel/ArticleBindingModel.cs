using System.ComponentModel.DataAnnotations;

namespace BikePortalWebApp.Models.BindingModel
{
    public class ArticleBindingModel
    {
        [Required]
        [StringLength(100, ErrorMessage = 
            "The {0} must be at least {2} characters long and must not be longer than {1} characters", 
            MinimumLength = 5)]
        public string Name { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = 
            "The {0} must be at least {2} characters long and must not be longer than {1} characters", 
            MinimumLength = 5)]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}