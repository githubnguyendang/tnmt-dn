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
    public class NM_SoLuongController : ControllerBase
    {
        private readonly NM_SoLuongService _service;

        public NM_SoLuongController(NM_SoLuongService service)
        {
            _service = service;
        }
        //Ao Ho
        [HttpGet]
        [Route("danh-sach/ao-ho")]
        public async Task<List<KKTNN_NuocMat_SoLuong_AoHoDamPhaDto>> GetAllAoHoDamPha()
        {
            return (await _service.GetAllAoHoDamPhaAsync());
        }

        [HttpPost]
        [Route("luu/ao-ho")]
        public async Task<ActionResult<KKTNN_NuocMat_SoLuong_AoHoDamPhaDto>> SaveAoHoDamPha(KKTNN_NuocMat_SoLuong_AoHoDamPhaDto moddel)
        {
            var res = await _service.SaveAoHoDamPhaAsync(moddel);
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
        [Route("ao-ho/xoa/{Id}")]
        public async Task<ActionResult<KKTNN_NuocMat_SoLuong_AoHoDamPhaDto>> DeleteAoHoDamPha(int Id)
        {
            var res = await _service.DeleteAoHoDamPhaAsync(Id);
            if (res == true)
            {
                return Ok(new { message = "Dữ liệu đã được xóa" });
            }
            else
            {
                return BadRequest(new { message = "Lỗi xóa dữ liệu", error = true });
            }
        }
        //Song Suoi
        [HttpGet]
        [Route("danh-sach/song-suoi")]
        public async Task<List<KKTNN_NuocMat_SoLuong_SongSuoiDto>> GetAllSongSuoi()
        {
            return (await _service.GetAllSongSuoiAsync());
        }

        [HttpPost]
        [Route("luu/song-suoi")]
        public async Task<ActionResult<KKTNN_NuocMat_SoLuong_SongSuoiDto>> SaveSongSuoi(KKTNN_NuocMat_SoLuong_SongSuoiDto moddel)
        {
            var res = await _service.SaveSongSuoiAsync(moddel);
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
        [Route("song-suoi/xoa/{Id}")]
        public async Task<ActionResult<KKTNN_NuocMat_SoLuong_SongSuoiDto>> DeleteSongSuoi(int Id)
        {
            var res = await _service.DeleteSongSuoiAsync(Id);
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
