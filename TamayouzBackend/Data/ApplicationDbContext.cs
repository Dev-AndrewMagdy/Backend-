using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Model.Services;
using TamayouzShared.Model.Auth;
using TamayouzShared.Model.ServicesCategory;
using TamayouzShared.Model.Team;
using TamayouzShared.Model.RecentWorks;
using TamayouzShared.Model.RecentWorkCategory;
using TamayouzShared.Model.ConactUs;
using TamayouzShared.Model.AboutUs;
using TamayouzShared.Model.Blogs;
using TamayouzShared.Model.FAQ;
using TamayouzShared.Model.Branch;
using TamayouzShared.Model.Footer;
using TamayouzShared.Model.Home;

namespace TamayouzAPI.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Service> Service { get; set; }
        public DbSet<ServiceCategoty> ServiceCategoty { get; set; }
        public DbSet<RecentWork> RecentWork { get; set; }
        public DbSet<RecentWorkCategory> RecentWorkCategory { get; set; }
        public DbSet<TeamUser> Team { get; set; }
        public DbSet<ContactUs> ContactUs { get; set; }
        public DbSet<About> About { get; set; }
        public DbSet<SocialLink> SocialLink { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Questions> Questions { get; set; }
        public DbSet<TermsAndServices> TermsAndServices { get; set; }
        public DbSet<Branch> Branchs { get; set; }
        public DbSet<Home> Home { get; set; }
        public DbSet<Footer> Footer { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Service>()
           .HasOne(p => p.Category)
           .WithMany(c => c.Service)
           .HasForeignKey(p => p.ServiceCategory);
        }

            /* protected override void OnModelCreating(ModelBuilder modelBuilder)
             {
                 base.OnModelCreating(modelBuilder);
                 *//*
                 modelBuilder.Entity<About>().HasData(
                 new About
                 {
                     ID = 1,
                     TagLine = "Leading the way in innovation",
                     Discription = "We are committed to excellence.",
                     mobilePhone1 = "123-456-7890",
                     mobilePhone2 = "098-765-4321",
                     Email = "info@example.com",
                     Vision = "To be a global leader in our industry",
                     Message = "Welcome to our world of innovation",
                     Targets = "To achieve market leadership by 2025",
                     StartWrok = "08:00 AM",
                     EndWrok = "05:00 PM",
                     // Set the Picture path accordingly
                     Picture = "about_us.jpg"
                 });


                 modelBuilder.Entity<Home>().HasData(
                     new Home
                     {
                         ID = 1,
                         BannerTitle = "Welcome to Our Site!",
                         BannerSubtitle = "Your success starts here",
                         MainContent = "We offer a variety of services to help you achieve your goals.",
                         BannerImage = "home.png"
                         // Add other properties as necessary, potentially using navigation properties
                     });


                 // Seed SocialLink data if applicable
                 modelBuilder.Entity<SocialLink>().HasData(
                     new SocialLink { ID = 1, Platform = "Facebook", Url = "https://facebook.com/ourpage", AboutId = 1 },
                     new SocialLink { ID = 2, Platform = "Twitter", Url = "https://twitter.com/ourpage", AboutId = 1 }
                 );


                 modelBuilder.Entity<Footer>().HasData(
                 new Footer
                 {
                     ID = 1,
                     Picture = "footer_logo.png",
                     AboutId = 1  // Reference the existing About entity
                 });
             *//*
             }*/
        }
}
