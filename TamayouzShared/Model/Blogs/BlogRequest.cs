using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace TamayouzShared.Model.Blogs
{
    public class BlogRequest
    {
        [MaxLength(100)]
        public string? Title { get; set; }
        [MaxLength(500)]
        public string? Descreption { get; set; }
        public int? BlogCategory { get; set; }
        public bool isActive { get; set; }

        private IFormFile? Picture;
    }
}