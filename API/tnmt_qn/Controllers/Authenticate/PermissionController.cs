using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using tnmt_qn.Data;
using tnmt_qn.Dto;
using tnmt_qn.Service;

namespace tnmt_qn.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class PermissionController : ControllerBase
    {
        private readonly PermissionService _service;

        public PermissionController(PermissionService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("list")]
        public async Task<List<PermissionDto>> GetAllPermission()
        {
            return (await _service.GetAllPermissionAsync());
        }

        [HttpGet]
        [Route("{Id}")]
        public async Task<PermissionDto> GetPermissionById(int Id)
        {
            return await _service.GetPermissionByIdAsync(Id);
        }

        [HttpPost]
        [Route("save")]
        public async Task<ActionResult<Permissions>> SavePermission(PermissionDto dto)
        {
            var res = await _service.SavePermissionAsync(dto);
            if (res == true)
            {
                return Ok(new { message = "Saved permission successfully" });
            }
            else
            {
                return BadRequest(new { message = "Save permission failed", error = true });
            }
        }

        [HttpPost]
        [Route("delete")]
        public async Task<ActionResult<Permissions>> DeletePermission(PermissionDto dto)
        {
            var res = await _service.DeletePermissionAsync(dto);
            if (res == true)
            {
                return Ok(new { message = "Permission successfully deleted" });
            }
            else
            {
                return BadRequest(new { message = "Removing permissions failed", error = true });
            }
        }
    }
}
