using Microsoft.AspNetCore.Mvc;
using TamayouzShared.Base;
using TamayouzAPI.Helper;
using TamayouzShared.Model.ConactUs;
using TamayouzAPI.Repository.Contact;

namespace TamayouzAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactUsController(IContactUsRepository conactUsRepository) : ControllerBase
    {
        [HttpPost("SubmitMessage")]
        public async Task<ActionResult<APIResponse<ContactUs>>> SubmitMessage([FromForm] ContactUs contactUs)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new APIResponse<ContactUs>
                {
                    Success = false,
                    Message = "خطأ فى البيانات المدخلة",
                    Data = null
                });
            }

            if (await conactUsRepository.AddAsync(contactUs))
            {
                return Ok(ResponseHelper.ResultResponse<ContactUs>(true, null, "تم االارسال بنجاح"));
            }
            else
            {
                return BadRequest(ResponseHelper.ResultResponse<ContactUs>(false, null, "فشل  الارسال "));
            }

        }

        [HttpGet("GetMessages")]
        public async Task<ActionResult<APIResponse<IEnumerable<ContactUs>>>> GetMessages()
        {
            IEnumerable<ContactUs> data = await conactUsRepository.GetAllAsync();
            return Ok(ResponseHelper.ResultResponse<IEnumerable<ContactUs>> (true, data, "All Messages contact"));
        }

    }
}
