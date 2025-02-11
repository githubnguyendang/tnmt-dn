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
    public class NN_NguonNuoc_SongSuoiController : ControllerBase
    {
        private readonly NN_NguonNuoc_SongSuoiService _service;

        public NN_NguonNuoc_SongSuoiController(NN_NguonNuoc_SongSuoiService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("danh-sach")]
        public async Task<List<NN_NguonNuoc_SongSuoiDto>> GetAll()
        {
            return await _service.GetAllNguonNuocSongSuoiAsync();
        }

        [HttpPost]
        [Route("luu")]
        public async Task<ActionResult<NN_NguonNuoc_SongSuoiDto>> Save(NN_NguonNuoc_SongSuoiDto moddel)
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
        public async Task<ActionResult<NN_NguonNuoc_SongSuoiDto>> Delete(int Id)
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
