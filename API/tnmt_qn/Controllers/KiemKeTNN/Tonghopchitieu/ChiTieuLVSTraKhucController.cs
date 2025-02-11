using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tnmt_qn.Data;
using tnmt_qn.Dto;
using tnmt_qn.Service;

namespace tnmt_qn.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class ChiTieuLVSTraKhucController : ControllerBase
    {
        private readonly ChiTieuLVSTraKhucService _service;

        public ChiTieuLVSTraKhucController(ChiTieuLVSTraKhucService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("danhsach")]
        public async Task<List<ChiTieuLVSTraKhucDto>> GetAll()
        {
            return await _service.GetAllChiTieuLVSTraKhucAsync();
        }

        [HttpPost]
        [Route("luu")]
        public async Task<ActionResult<ChiTieuLVSTraKhuc>> Save(ChiTieuLVSTraKhucDto dto)
        {
            var res = await _service.SaveChiTieuLVSTraKhucAsync(dto);
            if (res == true)
            {
                return Ok(new { message = "Biểu mẫu: Dữ liệu đã được lưu", id = res });
            }
            else
            {
                return BadRequest(new { message = "Biểu mẫu: Lỗi lưu dữ liệu", error = true });
            }
        }


        [HttpGet]
        [Route("xoa/{Id}")]
        public async Task<ActionResult> Delete(int Id)
        {
            var res = await _service.DeleteChiTieuLVSTraKhucAsync(Id);
            if (res == true)
            {
                return Ok(new { message = "Biểu mẫu: Dữ liệu đã được xóa" });
            }
            else
            {
                return BadRequest(new { message = "Biểu mẫu: Lỗi xóa dữ liệu", error = true });
            }
        }
    }
}