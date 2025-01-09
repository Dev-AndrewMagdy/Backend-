using TamayouzShared.Base;

namespace TamayouzShared.Model.Branch
{
    public class Branch : BaseEntity
    {
        public string? Address { get; set; }
        public string? MapLangAndLat { get; set; }
        public bool isMain { get; set; }
    }
}
