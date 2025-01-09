using System.ComponentModel.DataAnnotations.Schema;
using TamayouzShared.Base;
using TamayouzShared.Model.AboutUs;

namespace TamayouzShared.Model.Footer
{
    public class Footer : BaseEntity
    {
        [NotMapped]
        private string? _Picture;
        public string? Picture
        {
            get => $"{baseUrl()}{_Picture}";
            set => _Picture = value;
        }
        public int? AboutId { get; set; }
        public About? About { get; set; }
    }
}