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
    public class NM_ChatLuongController : ControllerBase
    {
        private readonly NM_ChatLuongService _service;

        public NM_ChatLuongController(NM_ChatLuongService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("danh-sach")]
        public async Task<List<KKTNN_NuocMat_ChatLuongDto>> GetAll()
        {
            return (await _service.GetAllAsync());
        }

        [HttpPost]
        [Route("luu")]
        public async Task<ActionResult<KKTNN_NuocMat_ChatLuongDto>> Save(KKTNN_NuocMat_ChatLuongDto moddel)
        {
            var res = await _service.SaveAsync(moddel);
            if (res == true)
            {
                return Ok(new { message = "Loại công trình: Dữ liệu đã được lưu" });
            }
            else
            {
                return BadRequest(new { message = "Loại công trình: Lỗi lưu dữ liệu", error = true });
            }
        }

        [HttpGet]
        [Route("xoa/{Id}")]
        public async Task<ActionResult<KKTNN_NuocMat_ChatLuongDto>> Delete(int Id)
        {
            var res = await _service.DeleteAsync(Id);
            if (res == true)
            {
                return Ok(new { message = "Loại công trình: Dữ liệu đã được xóa" });
            }
            else
            {
                return BadRequest(new { message = "Loại công trình: Lỗi xóa dữ liệu", error = true });
            }
        }
    }
}
