using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using tnmt_qn.Dto;
using tnmt_qn.Service;

namespace tnmt_qn.Controllers
{
    [Route("thanh-tra-kiem-tra")]
    [ApiController]
    //[Authorize]
    public class ThanhTraKiemTraController : ControllerBase
    {
        private readonly IThanhTraKiemTraService _service;

        public ThanhTraKiemTraController(IThanhTraKiemTraService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("danh-sach")]
        public async Task<List<ThanhTraKiemTraDto>> GetAll()
        {
            return await _service.GetAllAsync();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<ThanhTraKiemTraDto>> GetById(int id)
        {
            var item = await _service.GetByIdAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost]
        [Route("luu")]
        public async Task<ActionResult> Save(ThanhTraKiemTraDto dto)
        {
            var res = await _service.SaveAsync(dto);
            if (res)
            {
                return Ok(new { message = "Dữ liệu đã được lưu" });
            }
            else
            {
                return BadRequest(new { message = "Lỗi lưu dữ liệu", error = true });
            }
        }

        [HttpGet]
        [Route("xoa/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var res = await _service.DeleteAsync(id);
            if (res)
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