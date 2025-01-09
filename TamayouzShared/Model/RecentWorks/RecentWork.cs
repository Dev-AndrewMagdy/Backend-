using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TamayouzShared.Base;

namespace TamayouzShared.Model.RecentWorks
{
    public class RecentWork : BaseEntity
    {
        public string? WorkName { get; set; }
        public string? WorkDiscription { get; set; }
        public int WorkCategory { get; set; }
       
        [NotMapped]
        private string? _Picture;
        public string? Picture
        {
            get => $"{baseUrl()}{_Picture}";
            set => _Picture = value;
        }
    }
}
