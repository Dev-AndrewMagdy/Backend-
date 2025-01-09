using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace TamayouzShared.Model.Home
{
    public class HomeRequest
    {
        [Required]
        public required string BannerTitle { get; set; }
        [Required]
        public required string BannerSubtitle { get; set; }
        [Required]
        public required string MainContent { get; set; }
        public IFormFile? formFile {get; set;}
    }
}
