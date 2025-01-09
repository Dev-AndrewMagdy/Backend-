using System.ComponentModel.DataAnnotations.Schema;
using TamayouzShared.Base;

namespace TamayouzShared.Model.Team
{
    public class TeamUser : BaseEntity
    {
        public string? Name { get;  set; }
        public string? Title { get;  set; }
        public string? Description { get;  set; }
        [NotMapped]
        private string? _Picture;
        public string? Picture
        {
            get => $"{baseUrl()}{_Picture}";
            set => _Picture = value;
        }
    }
}
