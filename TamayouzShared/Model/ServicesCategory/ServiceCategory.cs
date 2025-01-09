using Model.Services;
using System.ComponentModel.DataAnnotations.Schema;
using TamayouzShared.Base;

namespace TamayouzShared.Model.ServicesCategory
{
    public class ServiceCategoty : BaseEntity
    {
        public string? CategoryName { get; set; }
        public string? CategoryDiscription { get; set; }
        [NotMapped]
        private string _Picture;
        public string Picture
        {
            get
            {
                if (string.IsNullOrEmpty(_Picture))
                {
                    return null;
                }
                return _Picture.StartsWith(baseUrl(), StringComparison.OrdinalIgnoreCase)
                    ? _Picture
                    : $"{baseUrl()}{_Picture}";
            }
            set => _Picture = value;
        }
       // public ICollection<Service> Service { get; set; }
        public ICollection<Service> Service { get; set; } = new List<Service>();

        public int ServiceCount => Service.Count;
    }
}