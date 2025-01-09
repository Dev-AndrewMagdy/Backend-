using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TamayouzShared.Base;

namespace TamayouzShared.Model.FAQ
{
    public class TermsAndServices : BaseEntity
    {
        public string? TermsServicesScheme { get; set; }
    }
}