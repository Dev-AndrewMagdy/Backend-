using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TamayouzShared.Base;
using TamayouzShared.Base;

namespace TamayouzShared.Model.Blogs
{
    public class Blog : BaseEntity
    {
        public string? Title { get; set; }
        public string? Descreption { get; set; }
        public int? BlogCategory { get; set; }
        public bool isActive { get; set; }
        [NotMapped]
        private string? _Picture;
        public string Picture
        {
            get => $"{baseUrl()}{_Picture}";
            set => _Picture = value;
        }
    }
}