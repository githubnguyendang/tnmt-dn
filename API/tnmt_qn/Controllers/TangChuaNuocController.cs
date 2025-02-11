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
    public class TangChuaNuocController : ControllerBase
    {
        private readonly TangChuaNuocService _service;

        public TangChuaNuocController(TangChuaNuocService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("danh-sach")]
        public async Task<List<TangChuaNuocDto>> GetAll()
        {
            return (await _service.GetAllAsync());
        }

        [HttpGet]
        [Route("{Id}")]
        public async Task<TangChuaNuocDto?> GetById(int Id)
        {
            return await _service.GetByIdAsync(Id);
        }

        [HttpPost]
        [Route("luu")]
        public async Task<ActionResult<TangChuaNuoc>> Save(TangChuaNuocDto dto)
        {
            var res = await _service.SaveAsync(dto);
            if (res == true)
            {
                return Ok(new { message = "Tầng chứa nước :Dữ liệu đã được lưu" });
            }
            else
            {
                return BadRequest(new { message = "Tầng chứa nước :Lỗi lưu dữ liệu", error = true });
            }
        }

        [HttpGet]
        [Route("xoa/{Id}")]
        public async Task<ActionResult<TangChuaNuoc>> Delete(int Id)
        {
            var res = await _service.DeleteAsync(Id);
            if (res == true)
            {
                return Ok(new { message = "Tầng chứa nước :Dữ liệu đã được xóa" });
            }
            else
            {
                return BadRequest(new { message = "Tầng chứa nước :Lỗi xóa dữ liệu", error = true });
            }
        }
    }
}