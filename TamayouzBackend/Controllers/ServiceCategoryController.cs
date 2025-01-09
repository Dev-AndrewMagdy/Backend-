using Microsoft.AspNetCore.Mvc;
using TamayouzShared.Base;
using TamayouzAPI.Helper;
using TamayouzShared.Model.ServicesCategory;
using TamayouzAPI.Repository.Categories;

namespace TamayouzAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceCategoryController(ICategoryRepository servicesRepository, ImagesProvider imagesProvider) : ControllerBase
    {
        [HttpPost("AddCategory")]
        public async Task<ActionResult<APIResponse<ServiceCategoty>>> AddCategory([FromForm] ServiceCategoryRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new APIResponse<ServiceCategoty>
                {
                    Success = false,
                    Message = "خطأ فى البيانات المدخلة",
                    Data = null
                });
            }

            string[] allowedFileExtentions = [".jpg", ".jpeg", ".png"];

            string? createdImageName = await imagesProvider.SaveFileAsync(request.ImageFile, allowedFileExtentions);

            var category = new ServiceCategoty
            {
                CategoryName = request.CategoryName,
                CategoryDiscription = request.CategoryDiscription,
                Picture = createdImageName,
                isActive = request.isActive,
            };

            if (await servicesRepository.AddAsync(category))
            {
                return Ok(ResponseHelper.ResultResponse<ServiceCategoty>(true, null, "تم اضافة المركز بنجاح"));
            }
            else
            {
                return BadRequest(ResponseHelper.ResultResponse<ServiceCategoty>(false, null, "فشل اضافة المركز"));
            }
        }

        [HttpPost("UpdateCategory")]
        public async Task<ActionResult<APIResponse<ServiceCategoty>>> UpdateCategory([FromForm] ServiceCategoryRequest request, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new APIResponse<ServiceCategoty>
                {
                    Success = false,
                    Message = "خطأ فى البيانات المدخلة",
                    Data = null
                });
            }

            //* handle empty image reques/
            string[] allowedFileExtentions = [".jpg", ".jpeg", ".png"];
            string? createdImageName = await imagesProvider.SaveFileAsync(request.ImageFile, allowedFileExtentions);

            var category = new ServiceCategoty
            {
                ID = id,
                CategoryName = request.CategoryName,
                CategoryDiscription = request.CategoryDiscription,
                Picture = createdImageName,
                isActive = request.isActive,
            };

            if (await servicesRepository.UpdateAsync(category))
            {
                return Ok(ResponseHelper.ResultResponse<ServiceCategoty>(true, null, "تم اضافة المركز بنجاح"));
            }
            else
            {
                return BadRequest(ResponseHelper.ResultResponse<ServiceCategoty>(false, null, "فشل اضافة المركز"));
            }
        }


        [HttpGet("GetCategoryList")]
        public async Task<ActionResult<APIResponse<IEnumerable<ServiceCategoty>>>> GetCategoryList()
        {
            IEnumerable<ServiceCategoty> data = await servicesRepository.GetAllAsync();
            return Ok(ResponseHelper.ResultResponse<IEnumerable<ServiceCategoty>>(true, data, "CategoryList"));
        }

  

    }
}
