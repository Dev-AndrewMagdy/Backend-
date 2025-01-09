using System.Text.Json.Serialization;
using TamayouzShared.Base;

namespace TamayouzShared.Model.AboutUs
{
    public class SocialLink : BaseEntity
    {
        public string? Platform { get; set; } // e.g., "Facebook", "Twitter"
        public string? Url { get; set; }
        public string? favicon { get; set; }

        public int AboutId { get; set; }
        [JsonIgnore]
        public virtual About About { get; set; }
    }
}
