using Microsoft.AspNetCore.Mvc;
using TamayouzShared.Base;
using TamayouzAPI.Helper;
using TamayouzShared.Model.Home;
using TamayouzShared.Model.Footer;
using TamayouzAPI.Repository.Main;

namespace TamayouzAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainController(IMainRepository mainRepository , ImagesProvider imagesProvider) : ControllerBase
    {
        [HttpGet("Home")]
        public async Task<ActionResult<APIResponse<Home>>> Home()
        {
            Home? Home = await mainRepository.GetHomeAsync();
            return Ok(ResponseHelper.ResultResponse<Home>(true, Home, "Home"));
        }

        [HttpPut("SetHome")]
        public async Task<ActionResult<APIResponse<Home>>> setHome([FromForm] HomeRequest homeRequest)
        {
            string[] allowedFileExtentions = [".jpg", ".jpeg", ".png"];
           // string? createdImageName = await imagesProvider.SaveFileAsync(homeRequest.formFile, allowedFileExtentions);
            string? createdImageName = null;

            if (homeRequest.formFile != null)
            {
                createdImageName = await imagesProvider.SaveFileAsync(homeRequest.formFile, allowedFileExtentions);
            }

            Home home = new Home
            {
                ID = 1,
                BannerTitle = homeRequest.BannerTitle,
                BannerSubtitle = homeRequest.BannerSubtitle,
                MainContent = homeRequest.MainContent,
                BannerImage = createdImageName
            };

            bool updateState = await mainRepository.UpdateAsync(home);
            return Ok(ResponseHelper.ResultResponse<Home>(updateState, null, updateState ? "Home updated" : "Failed Home updated"));
        }

        [HttpGet("Footer")]
        public async Task<ActionResult<APIResponse<Footer>>> Footer()
        {
            //  About? about = await aboutRepository.GetAbout();
            return Ok(ResponseHelper.ResultResponse<Footer>(true, null, "Footer"));
        }

        [HttpPut("SetFooter")]
        public async Task<ActionResult<APIResponse<Footer>>> setFooter([FromForm] FooterRequest footerRequest)
        {
            //  About? about = await aboutRepository.GetAbout();
            return Ok(ResponseHelper.ResultResponse<Footer>(true, null, "Footer updated"));
        }
    }
}
