using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TamayouzAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
               table: "AspNetRoles",
               columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
               values: new object[] { Guid.NewGuid().ToString(), "User", "User".ToUpper(), Guid.NewGuid().ToString() }
           );

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
                values: new object[] { Guid.NewGuid().ToString(), "Admin", "Admin".ToUpper(), Guid.NewGuid().ToString() }
            );

            migrationBuilder.InsertData(
               table: "About",
               columns: new[] { "ID", "TagLine", "Discription", "mobilePhone1",
                   "mobilePhone2", "Email", "Vision" ,
                   "Message", "Targets", "StartWrok" , "EndWrok" , "Picture" , "isActive"},
               values: new object[]
               {
                   1,
                   "Leading the way in innovation",
                   "We are committed to excellence.",
                   "123-456-7890",
                   "098-765-4321",
                   "info@example.com",
                   "To be a global leader in our industry",
                   "Welcome to our world of innovation",
                   "To achieve market leadership by 2025",
                   "08:00 AM",
                   "05:00 PM",
                   "about_us.jpg",
                    true
               });

            migrationBuilder.InsertData(
              table: "SocialLink",
              columns: new[] { "ID", "Platform", "Url", "AboutId", "isActive" },
              values: new object[]
              {   1,
                   "Facebook",
                   "https://facebook.com/ourpage",
                   1,true
              });

            migrationBuilder.InsertData(
              table: "SocialLink",
              columns: new[] { "ID", "Platform", "Url", "AboutId", "isActive" },
              values: new object[]
              {    2,
                   "Facebook",
                   "https://facebook.com/ourpage",
                    1,
                    true
              });

            migrationBuilder.InsertData(
               table: "Home",
               columns: new[] { "ID", "BannerTitle", "BannerSubtitle", "MainContent", "BannerImage", "isActive" },
               values: new object[]
               { 1,
                   "Welcome to Our Site!",
                   "Your success starts here",
                   "We offer a variety of services to help you achieve your goals.",
                  "home.png" , true
               });



            migrationBuilder.InsertData(
             table: "Footer",
             columns: new[] { "ID", "Picture", "AboutId", "isActive" },
             values: new object[]
             { 1, "footer_logo.png", 1 , true});
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [AspNetRoles]");
            migrationBuilder.Sql("DELETE FROM [About]");
            migrationBuilder.Sql("DELETE FROM [Home]");
            migrationBuilder.Sql("DELETE FROM [SocialLink]");
            migrationBuilder.Sql("DELETE FROM [Footer]");
        }
    }
}
