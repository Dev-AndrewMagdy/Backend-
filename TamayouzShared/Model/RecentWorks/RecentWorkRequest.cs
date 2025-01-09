using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace TamayouzShared.Model.RecentWork
{
    public class RecentWorkRequest
    {
        [Required]
        [MaxLength(50)]
        public required string WorkName { get; set; }
        [Required]
        [MaxLength(50)]
        public required string? WorkDiscription { get; set; }
        [Required]
        public required int WorkCategory { get; set; }
        [Required]
        public required bool isActive { get; set; }
        [NotMapped]
        public IFormFile? ImageFile { get; set; }
    }
}
