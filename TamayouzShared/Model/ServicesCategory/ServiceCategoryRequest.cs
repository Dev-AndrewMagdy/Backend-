using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TamayouzShared.Model.ServicesCategory
{
    public class ServiceCategoryRequest
    {
        [Required]
        [MaxLength(50)]
        public required string CategoryName { get; set; }
        [Required]
        [MaxLength(200)]
        public required string CategoryDiscription { get; set; }
        [Required]
        public bool isActive { get; set; }
        [NotMapped]
        public IFormFile? ImageFile { get; set; }
    }
}
