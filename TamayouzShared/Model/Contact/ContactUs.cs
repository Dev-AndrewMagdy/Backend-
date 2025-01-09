using TamayouzShared.Base;

namespace TamayouzShared.Model.ConactUs
{
    public class ContactUs : BaseEntity
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? MobilePhone { get; set; }
        public string? Subject { get; set; }
        public string? Message { get; set; }
    }
}
