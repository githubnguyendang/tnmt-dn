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
    public class VHHC_LuuVucSongController : ControllerBase 
    {
        private readonly VHHC_LuuVucSongService _service;

        public VHHC_LuuVucSongController(VHHC_LuuVucSongService service) //Controller VHHC_LuuVucSong lấy dữ liệu từ VHHC_LuuVucSongSerice
        {
            _service = service;
        }

        [HttpGet]
        [Route("danh-sach")] //Tạo API lấy dữ liệu (VHHC_luuVucSong/danh-sach)
        public async Task<List<VHHC_LuuVucSongDto>> GetAll()
        {
            return await _service.GetAllVHHC_LuuVucSongAsync();
        }

        [HttpPost]
        [Route("luu")] //Tạo API lưu dữ liệu (VHHC_luuVucSong/luu)
        public async Task<ActionResult<VHHC_LuuVucSongDto>> Save(VHHC_LuuVucSongDto moddel)
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
        [Route("xoa/{Id}")] //Tạo API xoá dữ liệu (VHHC_luuVucSong/xoa)
        public async Task<ActionResult<VHHC_LuuVucSongDto>> Delete(int Id)
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
