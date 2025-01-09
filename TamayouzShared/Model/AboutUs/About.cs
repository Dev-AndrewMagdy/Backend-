using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TamayouzShared.Base;

namespace TamayouzShared.Model.AboutUs
{
    public class About : BaseEntity
    {
        public string? TagLine { get; set; }
        public string? Discription { get; set; }
        public string? mobilePhone1 { get; set; }
        public string? mobilePhone2 { get; set; }
        public string? Email { get; set; }
        public string? Vision { get; set; }
        public string? Message { get; set; }
        public string? Targets { get; set; }
        public string? StartWrok { get; set; }
        public string? EndWrok { get; set; }
        public ICollection<SocialLink>? SocialLinks { get; set; }

        private string _Picture;
        public string Picture
        {
            get => $"{baseUrl()}{_Picture}";
            set => _Picture = value;
        }
    }
}
