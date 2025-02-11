using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using tnmt_qn.Data;
using tnmt_qn.Dto;

using tnmt_qn.Service;

namespace tnmt_qn.Controllers
{

// Route là đường dẫn của contronler 

    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class NN_LuuVucSongController : ControllerBase
    {
        private readonly NN_LuuVucSongService _service;

        public NN_LuuVucSongController(NN_LuuVucSongService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("danh-sach")]
        public async Task<List<NN_LuuVucSongDto>> GetAll()
        {
            return await _service.GetAllLuuVucSongAsync();
        }

        [HttpPost]
        [Route("luu")]
        public async Task<ActionResult<NN_LuuVucSongDto>> Save(NN_LuuVucSongDto moddel)
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
        public async Task<ActionResult<NN_LuuVucSongDto>> Delete(int Id)
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
