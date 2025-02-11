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
    public class SLN_TongLuongNuocMatController : ControllerBase
    {
        private readonly SLN_TongLuongNuocMatService _service;

        public SLN_TongLuongNuocMatController(SLN_TongLuongNuocMatService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("danh-sach")]
        public async Task<List<SLN_TongLuongNuocMatDto>> GetAll()
        {
            return await _service.GetAllSLN_TongLuongNuocMatAsync();
        }

        [HttpPost]
        [Route("luu")]
        public async Task<ActionResult<SLN_TongLuongNuocMatDto>> Save(SLN_TongLuongNuocMatDto moddel)
        {
            var res = await _service.SaveAsync(moddel);
            if (res == true)
            {
                return Ok(new { message = "Dữ liệu đã được lưu" });
            }
            else
            {
                return BadRequest(new { message = "Lỗi lưu dữ liệu", error = true });
            }
        }

        [HttpGet]
        [Route("xoa/{Id}")]
        public async Task<ActionResult<SLN_TongLuongNuocMatDto>> Delete(int Id)
        {
            var res = await _service.DeleteAsync(Id);
            if (res == true)
            {
                return Ok(new { message = "Dữ liệu đã được xóa" });
            }
            else
            {
                return BadRequest(new { message = "Lỗi xóa dữ liệu", error = true });
            }
        }
    }
}
