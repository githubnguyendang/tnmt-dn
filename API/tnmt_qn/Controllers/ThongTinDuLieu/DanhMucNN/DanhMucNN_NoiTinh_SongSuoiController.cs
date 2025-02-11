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
    public class DanhMucNN_NoiTinh_SongSuoiController : ControllerBase
    {
        private readonly DanhMucNN_NoiTinh_SongSuoiService _service;

        public DanhMucNN_NoiTinh_SongSuoiController(DanhMucNN_NoiTinh_SongSuoiService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("danh-sach")]
        public async Task<List<DanhMucNN_NoiTinh_SongSuoiDto>> GetAll()
        {
            return await _service.GetAllDanhMucNN_NoiTinh_SongSuoiAsync();
        }

        [HttpPost]
        [Route("luu")]
        public async Task<ActionResult<DanhMucNN_NoiTinh_SongSuoiDto>> Save(DanhMucNN_NoiTinh_SongSuoiDto moddel)
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
        public async Task<ActionResult<DanhMucNN_NoiTinh_SongSuoiDto>> Delete(int Id)
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
