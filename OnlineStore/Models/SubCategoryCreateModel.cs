using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Models
{
    public class SubCategoryCreateModel
    {
        [Required]
        public string? SubCategoryName { get; set; }
        public int? CategoryId { get; set; }
    }
}
