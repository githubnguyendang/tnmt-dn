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
    public class DuLieuNguonNuocThaiLonDBController : ControllerBase
    {
        private readonly DuLieuNguonNuocThaiLonDBService _service;

        public DuLieuNguonNuocThaiLonDBController(DuLieuNguonNuocThaiLonDBService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("danh-sach")]
        public async Task<List<DuLieuNguonNuocThaiLonDBDto>> GetAll()
        {
            return (await _service.GetAllAsync());
        }

        [HttpGet]
        [Route("{Id}")]
        public async Task<DuLieuNguonNuocThaiLonDBDto> GetById(int Id)
        {
            return await _service.GetByIdAsync(Id);
        }

        [HttpPost]
        [Route("du-bao")]
        public async Task<ActionResult<DuLieuNguonNuocThaiLonDB>> Save(DuLieuNguonNuocThaiLonDBDto moddel)
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
        public async Task<ActionResult<DuLieuNguonNuocThaiLonDB>> Delete(int Id)
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
