using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace TamayouzShared.Model.Services
{
    public class ServiceRequest
    {
      [Required]
      [MaxLength(50)]
      public required string ServiceName { get; set; }
      [Required]
      [MaxLength(200)]
      public required string serviceDescription { get; set; }
      [Required]
      public bool isActive { get; set; }
      [Required]
      public int serviceCategory { get; set; }
      [NotMapped]
      public IFormFile? ImageFile { get; set; }
    }
}
