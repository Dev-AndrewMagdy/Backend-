using Microsoft.AspNetCore.Mvc;
using TamayouzShared.Base;
using TamayouzAPI.Helper;
using TamayouzShared.Model.RecentWorks;
using TamayouzShared.Model.RecentWorkCategory;
using TamayouzAPI.Repository.RecenetWorkCategory;
using TamayouzAPI.Repository.RecentWork;
using TamayouzShared.Model.RecentWork;

namespace TamayouzAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RececntWorkController(IRecentWorkRepository recentWorkRepository , IRecenetWorksCategoryRepository recenetWorksCategory, ImagesProvider imagesProvider) : ControllerBase
    {
        [HttpPost("AddRececntWork")]
        public async Task<ActionResult<APIResponse<RecentWork>>> AddRececntWork([FromForm] RecentWorkRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new APIResponse<RecentWork>
                {
                    Success = false,
                    Message = "خطأ فى البيانات المدخلة",
                    Data = null
                });
            }

            string[] allowedFileExtentions = [".jpg", ".jpeg", ".png"];
            string? createdImageName = await imagesProvider.SaveFileAsync(request.ImageFile, allowedFileExtentions);

            var recentWork = new RecentWork
            {
                WorkName = request.WorkName,
                WorkDiscription = request.WorkDiscription,
                Picture = createdImageName,
                isActive = request.isActive,
                
            };

            if (await recentWorkRepository.AddAsync(recentWork))
            {
                return Ok(ResponseHelper.ResultResponse<RecentWork>(true, null, "تم اضافة الى سابقة الاعمال بنجاح"));
            }
            else
            {
                return BadRequest(ResponseHelper.ResultResponse<RecentWork>(false, null, "فشل اضافة سابقة الاعمال"));
            }
        }

        [HttpPut("UpdateRececntWork")]
        public async Task<ActionResult<APIResponse<RecentWork>>> UpdateRececntWork([FromForm] RecentWorkRequest request , int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new APIResponse<RecentWork>
                {
                    Success = false,
                    Message = "خطأ فى البيانات المدخلة",
                    Data = null
                });
            }

            string[] allowedFileExtentions = [".jpg", ".jpeg", ".png"];
            string? createdImageName = await imagesProvider.SaveFileAsync(request.ImageFile, allowedFileExtentions);

            var recentWork = new RecentWork
            {
                ID = id,
                WorkName = request.WorkName,
                WorkDiscription = request.WorkDiscription,
                Picture = createdImageName,
                isActive = request.isActive,
            };

            bool updateState = await recentWorkRepository.UpdateAsync(recentWork);
            //string status = updateState ? "تم اضافة الى سابقة الاعمال بنجاح" : "فشل اضافة سابقة الاعمال";

            return Ok(ResponseHelper.ResultResponse<RecentWork>(updateState, null, updateState ? "تم اضافة الى سابقة الاعمال بنجاح" : "فشل اضافة سابقة الاعمال"));
        }

        [HttpDelete("DeleteRececntWork")]
        public async Task<ActionResult<APIResponse<RecentWork>>> DeleteRececntWork(int id)
        {
            if (await recentWorkRepository.DeleteAsync(id))
            {
                return Ok(ResponseHelper.ResultResponse<RecentWork>(true, null, "تم حذف سابقة الاعمال بنجاح"));
            }
            else
            {
                return BadRequest(ResponseHelper.ResultResponse<RecentWork>(false, null, "فشل حذف سابقة الاعمال"));
            }
        }

        [HttpGet("GetRececntWorksList")]
        public async Task<ActionResult<APIResponse<IEnumerable<RecentWork>>>> GetRececntWorks()
        {
            IEnumerable<RecentWork> data = await recentWorkRepository.GetAllAsync();
            return Ok(ResponseHelper.ResultResponse<IEnumerable<RecentWork>>(true, data, "Rececnt Works List"));
        }

        /*RececntWorkCategory*/

        [HttpPost("AddRececntWorkCategory")]
        public async Task<ActionResult<APIResponse<RecentWorkCategory>>> AddRececntWorkCategory([FromForm] RecentWorkCategory request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new APIResponse<RecentWork>
                {
                    Success = false,
                    Message = "خطأ فى البيانات المدخلة",
                    Data = null
                });
            }

          
            var recentWork = new RecentWorkCategory
            {
                Name = request.Name,
                isActive = request.isActive,
            };

            if (await recenetWorksCategory.AddAsync(recentWork))
            {
                return Ok(ResponseHelper.ResultResponse<RecentWork>(true, null, "تم اضافة الفئة بنجاح"));
            }
            else
            {
                return BadRequest(ResponseHelper.ResultResponse<RecentWork>(false, null, "فشل اضافة الفئة"));
            }
        }

        [HttpPut("UpdateRececntWorkCategory")]
        public async Task<ActionResult<APIResponse<RecentWorkCategory>>> UpdateRececntWorkCategory([FromForm] RecentWorkCategory request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new APIResponse<RecentWork>
                {
                    Success = false,
                    Message = "خطأ فى البيانات المدخلة",
                    Data = null
                });
            }


            var recentWork = new RecentWorkCategory
            {
                Name = request.Name,
                isActive = request.isActive,
            };

            if (await recenetWorksCategory.UpdateAsync(recentWork))
            {
                return Ok(ResponseHelper.ResultResponse<RecentWork>(true, null, "تم تحديث الفئة بنجاح"));
            }
            else
            {
                return BadRequest(ResponseHelper.ResultResponse<RecentWork>(false, null, "فشل تحديث الفئة"));
            }
        }

        [HttpGet("GetRececntWorksCategories")]
        public async Task<ActionResult<APIResponse<IEnumerable<RecentWorkCategory>>>> GetRececntWorksCategories()
        {
            IEnumerable<RecentWorkCategory> data = await recenetWorksCategory.GetAllAsync();
            return Ok(ResponseHelper.ResultResponse<IEnumerable<RecentWorkCategory>>(true, data, "Rececnt Works List"));
        }


    }
}
