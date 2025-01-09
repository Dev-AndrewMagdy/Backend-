using Microsoft.AspNetCore.Mvc;
using Model.Services;
using TamayouzShared.Base;
using TamayouzAPI.Helper;
using TamayouzShared.Model.AboutUs;
using TamayouzAPI.Repository;

namespace TamayouzAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController(IAboutRepository aboutRepository , ImagesProvider imagesProvider) : ControllerBase
    {
        [HttpGet("GetAbout")] 
        public async Task<ActionResult<APIResponse<About>>> GetAbout()
        {
            About? about = await aboutRepository.GetAbout();
            return Ok(ResponseHelper.ResultResponse<About>(true, about, "About"));
        }

        [HttpPut("SetAboutInfo")]
        public async Task<ActionResult<APIResponse<About>>> setAboutInfo([FromForm] AboutRequest aboutRequest)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(new APIResponse<Service>
                {
                    Success = false,
                    Message = "خطأ فى البيانات المدخلة",
                    Data = null
                });
            }

            string[] allowedFileExtentions = [".jpg", ".jpeg", ".png"];
            string? createdImageName = await imagesProvider.SaveFileAsync(aboutRequest.Picture, allowedFileExtentions);

            var about = new About
            {
                ID = 1,
                TagLine = aboutRequest.TagLine,
                Discription = aboutRequest.Discription,
                mobilePhone1 = aboutRequest.mobilePhone1,
                mobilePhone2 = aboutRequest.mobilePhone2,
                Email = aboutRequest.Email,
                Vision = aboutRequest.Vision,
                Message = aboutRequest.Message,
                StartWrok = aboutRequest.StartWrok,
                EndWrok = aboutRequest.EndWrok,
                Picture = createdImageName,
                SocialLinks = aboutRequest.SocialLinks,
            };

            bool updateState = await aboutRepository.UpdateAsync(about);

            return Ok(ResponseHelper.ResultResponse<IEnumerable<About>>(updateState, null, updateState ? "تم تحديث المعلومات" : "فشل تحديث المعلومات"));
        }


    }
}
