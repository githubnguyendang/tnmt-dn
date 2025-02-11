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
    public class DuLieuNguonNuocThaiTrongCayController : ControllerBase
    {
        private readonly DuLieuNguonNuocThaiTrongCayService _service;

        public DuLieuNguonNuocThaiTrongCayController(DuLieuNguonNuocThaiTrongCayService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("danh-sach")]
        public async Task<List<DuLieuNguonNuocThaiTrongCayDto>> GetAll()
        {
            return (await _service.GetAllAsync());
        }

        [HttpGet]
        [Route("{Id}")]
        public async Task<DuLieuNguonNuocThaiTrongCayDto?> GetById(int Id)
        {
            return await _service.GetByIdAsync(Id);
        }

        [HttpPost]
        [Route("luu")]
        public async Task<ActionResult<DuLieuNguonNuocThaiTrongCay>> Save(DuLieuNguonNuocThaiTrongCayDto moddel)
        {
            var res = await _service.SaveAsync(moddel);
            if (res == true)
            {
                return Ok(new { message = "Lưu vực :Dữ liệu đã được lưu" });
            }
            else
            {
                return BadRequest(new { message = "Lưu vực :Lỗi lưu dữ liệu", error = true });
            }
        }

        [HttpGet]
        [Route("xoa/{Id}")]
        public async Task<ActionResult<DuLieuNguonNuocThaiTrongCay>> Delete(int Id)
        {
            var res = await _service.DeleteAsync(Id);
            if (res == true)
            {
                return Ok(new { message = "Lưu vực :Dữ liệu đã được xóa" });
            }
            else
            {
                return BadRequest(new { message = "Lưu vực :Lỗi xóa dữ liệu", error = true });
            }
        }
    }
}
