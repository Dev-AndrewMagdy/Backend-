using TamayouzShared.Base;
using TamayouzShared.Model.ServicesCategory;

namespace Model.Services{

    public class Service : BaseEntity {

        public string? ServiceName { get; set; }
        public string? serviceDescription{ get; set; }

        private string? _picturePathName;
        public string Picture
        {
            get => $"{baseUrl()}{_picturePathName}";
            set => _picturePathName = value;
        }
        public int? ServiceCategory { get; set; }

        public ServiceCategoty Category { get; set; }
    }
}