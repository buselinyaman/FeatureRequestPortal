using System.ComponentModel.DataAnnotations;

namespace FeatureRequestPortal.FeatureRequests
{
    //input dto
    public class AddCommentDto
    {
        [Required]
        [StringLength(2000,MinimumLength =100)]
        public string Text { get; set; } = null!;
    }
}
