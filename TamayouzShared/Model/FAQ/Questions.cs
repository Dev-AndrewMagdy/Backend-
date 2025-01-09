using TamayouzShared.Base;

namespace TamayouzShared.Model.FAQ
{
    public class Questions : BaseEntity
    {
        public string? Question { get; set; }
        public string? Answer { get; set; }
        public bool isActive { get; set; }
    }
}