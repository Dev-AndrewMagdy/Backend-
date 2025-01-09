using Microsoft.AspNetCore.Mvc;
using TamayouzShared.Base;
using TamayouzAPI.Helper;
using TamayouzShared.Model.Team;
using TamayouzAPI.Repository.TeamRepository;

namespace TamayouzAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController(IteamRepository teamRepository, ImagesProvider imagesProvider) : ControllerBase
    {
        [HttpPost("AddTeamUser")]
        public async Task<ActionResult<APIResponse<TeamUser>>> AddTeamUser([FromForm] TeamUserRequest userRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new APIResponse<TeamUser>
                {
                    Success = false,
                    Message = "خطأ فى البيانات المدخلة",
                    Data = null
                });
            }

            string[] allowedFileExtentions = [".jpg", ".jpeg", ".png"];
            string? createdImageName = await imagesProvider.SaveFileAsync(userRequest.ImageFile, allowedFileExtentions);
            
            var teamUser = new TeamUser
            {
                Name = userRequest.Name,
                Title = userRequest.Title,
                Description = userRequest.Description,
                Picture = createdImageName,
                isActive = userRequest.isActive
            };

            if (await teamRepository.AddAsync(teamUser))
            {
                return Ok(ResponseHelper.ResultResponse<TeamUser>(true, null, "تم اضافة عضو الفريق بنجاح"));
            }
            else
            {
                return BadRequest(ResponseHelper.ResultResponse<TeamUser>(false, null, "فشل اضافة عضو الفريق بنجاح"));
            }

        }

        [HttpPut("UpdateTeamUser")]
        public async Task<ActionResult<APIResponse<TeamUser>>> UpdateTeamUser([FromForm] TeamUserRequest userRequest, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new APIResponse<TeamUser>
                {
                    Success = false,
                    Message = "خطأ فى البيانات المدخلة",
                    Data = null
                });
            }

            string[] allowedFileExtentions = [".jpg", ".jpeg", ".png"];
            string? createdImageName = await imagesProvider.SaveFileAsync(userRequest.ImageFile, allowedFileExtentions);

            var teamUser = new TeamUser
            {
                ID = id,
                Name = userRequest.Name,
                Title = userRequest.Title,
                Description = userRequest.Description,
                Picture = createdImageName,
            };

            bool updateState = await teamRepository.UpdateAsync(teamUser);
            //string status = updateState ? "تم اضافة الى سابقة الاعمال بنجاح" : "فشل اضافة سابقة الاعمال";

            return Ok(ResponseHelper.ResultResponse<TeamUser>(updateState, null, updateState ? "تم تحديث عضو الفريق بنجاح" : "فشل تحديث عضو الفريق بنجاح"));
        }

        [HttpDelete("DeleteTeamUser")]
        public async Task<ActionResult<APIResponse<TeamUser>>> DeleteTeamUser(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new APIResponse<TeamUser>
                {
                    Success = false,
                    Message = "خطأ فى البيانات المدخلة",
                    Data = null
                });
            }


            if (id == null)
            {
                return BadRequest(new APIResponse<TeamUser>
                {
                    Success = false,
                    Message = "failed ID",
                    Data = null
                });
            }
           
                
            if (await teamRepository.DeleteAsync(id))
            {
                return Ok(ResponseHelper.ResultResponse<TeamUser>(true, null, "تم حذف عضو الفريق بنجاح"));
            }
            else
            {
                return BadRequest(ResponseHelper.ResultResponse<TeamUser>(false, null, "فشل حذف عضو الفريق بنجاح"));
            }

        }

        [HttpGet("GetTeamUsers")]
        public async Task<ActionResult<APIResponse<IEnumerable<TeamUser>>>> GetTeamUsers()
        {
            IEnumerable<TeamUser> data = await teamRepository.GetAllAsync();
            return ResponseHelper.ResultResponse<IEnumerable<TeamUser>>(true, data, "All Team Users");
        }
    }
}
