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
    public class Tram_ThongTinController : ControllerBase
    {
        private readonly Tram_ThongTinService _service;

        public Tram_ThongTinController(Tram_ThongTinService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("danh-sach")]
        public async Task<List<Tram_ThongTinDto>> GetAll()
        {
            return (await _service.GetAllAsync());
        }

        [HttpGet]
        [Route("{Id}")]
        public async Task<Tram_ThongTinDto?> GetById(int Id)
        {
            return await _service.GetByIdAsync(Id);
        }

        [HttpPost]
        [Route("luu")]
        public async Task<ActionResult<Tram_ThongTin>> Save(Tram_ThongTinDto moddel)
        {
            var res = await _service.SaveAsync(moddel);
            if (res == true)
            {
                return Ok(new { message = "Loại trạm: Dữ liệu đã được lưu" });
            }
            else
            {
                return BadRequest(new { message = "Loại trạm: Lỗi lưu dữ liệu", error = true });
            }
        }

        [HttpGet]
        [Route("xoa/{Id}")]
        public async Task<ActionResult<Tram_ThongTin>> Delete(int Id)
        {
            var res = await _service.DeleteAsync(Id);
            if (res == true)
            {
                return Ok(new { message = "Loại trạm: Dữ liệu đã được xóa" });
            }
            else
            {
                return BadRequest(new { message = "Loại trạm: Lỗi xóa dữ liệu", error = true });
            }
        }
    }
}
