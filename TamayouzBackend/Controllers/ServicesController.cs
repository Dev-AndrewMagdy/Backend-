using Microsoft.AspNetCore.Mvc;
using Model.Services;
using TamayouzShared.Base;
using TamayouzAPI.Helper;
using TamayouzShared.Model.Services;
using TamayouzAPI.Repository.Services;

namespace TamayouzAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController(IServicesRepository servicesRepository, ImagesProvider imagesProvider) : ControllerBase
    {

        [HttpPost("AddService")]
        public async Task<ActionResult<APIResponse<Service>>> AddService([FromForm] ServiceRequest request)
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
            string createdImageName = await imagesProvider.SaveFileAsync(request.ImageFile, allowedFileExtentions);

             var service = new Service { 
                 ServiceName =  request.ServiceName,
                 serviceDescription = request.serviceDescription,
                 Picture = createdImageName,
                 isActive = request.isActive,
                // serviceCategory = request.serviceCategory
             };

            if (await servicesRepository.AddAsync(service))
            {
                return Ok(ResponseHelper.ResultResponse<Service>(true, null, "تم اضافة الخدمة بنجاح"));
            }
            else
            {
                return BadRequest(ResponseHelper.ResultResponse<Service>(false, null, "فشل اضافة الخدمة"));
            }
        }

        [HttpGet("GetAllServiceList")]
        public async Task<ActionResult<APIResponse<IEnumerable<Service>>>> GetAllServiceList()
        {
            IEnumerable<Service> data = await servicesRepository.GetAllAsync();
            return Ok(ResponseHelper.ResultResponse<IEnumerable<Service>>(true, data, "AllServiceList"));
        }

        [HttpGet("GetService/{id}")]
        public async Task<ActionResult<APIResponse<Service>>> GetService(int id)
        {
            Service? data = await servicesRepository.GetByIdAsync(id);
            return Ok(ResponseHelper.ResultResponse<Service>(true, data, "AllServiceList"));
        }

        [HttpGet("GetServiceByCategory")]
        public async Task<ActionResult<APIResponse<IEnumerable<Service>>>> GetServiceByCategory(int id)
        {
            IEnumerable<Service> data = await servicesRepository.getByCategory(id);
            return ResponseHelper.ResultResponse<IEnumerable<Service>>(true, data, "ServiceByCategory");
        }

   
    }
}