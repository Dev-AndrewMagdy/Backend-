using Microsoft.AspNetCore.Http;

namespace TamayouzShared.Model.AboutUs
{
    public class AboutRequest
    {
        public string? TagLine { get; set; }
        public string? Discription { get; set; }
        public string? mobilePhone1 { get; set; }
        public string? mobilePhone2 { get; set; }
        public string? Email { get; set; }
        public string? Vision { get; set; }
        public string? Message { get; set; }
        public string? StartWrok { get; set; }
        public string? EndWrok { get; set; }
        public IFormFile? Picture { get; set; }
        public ICollection<SocialLink>? SocialLinks { get; set; }
        
    }
}
