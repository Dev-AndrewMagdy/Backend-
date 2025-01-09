using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace TamayouzShared.Model.Team
{
    public class TeamUserRequest
    {
        [MaxLength(50)]
        public string? Name { get; set; }
        [MaxLength(80)]
        public string? Title { get;  set; }
        [MaxLength(180)]
        public string? Description { get; set; }
        public IFormFile? ImageFile { get; set; }
        public bool isActive { get; set; }

    }
}
