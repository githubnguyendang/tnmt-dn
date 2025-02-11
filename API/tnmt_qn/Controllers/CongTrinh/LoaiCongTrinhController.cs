using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using tnmt_qn.Data;
using tnmt_qn.Dto;
using tnmt_qn.Service;

namespace tnmt_qn.Controllers
{
    [Route("loai-ct")]
    [ApiController]
    [Authorize]
    public class LoaiCongTrinhController : ControllerBase
    {
        private readonly CT_LoaiService _service;

        public LoaiCongTrinhController(CT_LoaiService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("danh-sach")]
        public async Task<List<CT_LoaiDto>> GetAll()
        {
            return (await _service.GetAllAsync());
        }

        [HttpGet]
        [Route("{Id}")]
        public async Task<CT_LoaiDto?> GetById(int Id)
        {
            return await _service.GetByIdAsync(Id);
        }

        [HttpPost]
        [Route("luu")]
        public async Task<ActionResult<CT_Loai>> Save(CT_LoaiDto dto)
        {
            var res = await _service.SaveAsync(dto);
            if (res == true)
            {
                return Ok(new { message = "Loại công trình: Dữ liệu đã được lưu" });
            }
            else
            {
                return BadRequest(new { message = "Loại công trình: Lỗi lưu dữ liệu", error = true });
            }
        }

        [HttpGet]
        [Route("xoa/{Id}")]
        public async Task<ActionResult<CT_Loai>> Delete(int Id)
        {
            var res = await _service.DeleteAsync(Id);
            if (res == true)
            {
                return Ok(new { message = "Loại công trình: Dữ liệu đã được xóa" });
            }
            else
            {
                return BadRequest(new { message = "Loại công trình: Lỗi xóa dữ liệu", error = true });
            }
        }
    }
}
