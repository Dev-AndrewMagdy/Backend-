using TamayouzShared.Base;
using TamayouzShared.Model.AboutUs;
using TamayouzShared.Model.Blogs;
using TamayouzShared.Model.FAQ;
using TamayouzShared.Model.ServicesCategory;
using TamayouzShared.Model.Team;

namespace TamayouzShared.Model.Home
{
    public class Home : BaseEntity
    {
        public string? BannerTitle { get; set; }
        public string? BannerSubtitle { get; set; }
        public string? MainContent { get; set; }
        public List<ServiceCategoty>? ServiceCategoty { get; set; }
        public List<RecentWorks.RecentWork>? RecentWorks { get; set; }
        public List<TeamUser>? Team { get; set; }
        public List<Blog>? Blog { get; set; }
        public List<Questions>? FAQ { get; set; }
        public About? About { get; set; }

        private string? _BannerImage;
        public string? BannerImage
        {
            get
            {
                if (string.IsNullOrEmpty(_BannerImage))
                {
                    return null;
                }
                return _BannerImage.StartsWith(baseUrl(), StringComparison.OrdinalIgnoreCase)
                    ? _BannerImage
                    : $"{baseUrl()}{_BannerImage}";
            }
            set => _BannerImage = value;
        }

    }
}