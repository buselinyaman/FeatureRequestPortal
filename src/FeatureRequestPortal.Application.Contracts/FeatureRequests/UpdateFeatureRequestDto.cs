using System.ComponentModel.DataAnnotations;

namespace FeatureRequestPortal.FeatureRequests
{
    //input dto
    public class UpdateFeatureRequestDto
    {
        [Required]
        [StringLength(200, MinimumLength = 10)]
        public string Title { get; set; } = null!;
       
        [StringLength(2000)]
        public string? Description {  get; set; }
        public FeatureRequestStatus Status {  get; set; }
    }
}
