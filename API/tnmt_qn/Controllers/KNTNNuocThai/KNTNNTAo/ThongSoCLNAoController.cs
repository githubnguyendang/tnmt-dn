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
    public class ThongSoCLNAoController : ControllerBase
    {
        private readonly ThongSoCLNAoService _service;

        public ThongSoCLNAoController(ThongSoCLNAoService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("danhsach")]
        public async Task<List<ThongSoCLNAoDto>> GetAll()
        {
            return await _service.GetAllThongSoCLNAoAsync();
        }

        [HttpPost]
        [Route("luu")]
        public async Task<ActionResult<ThongSoCLNAo>> Save(ThongSoCLNAoDto dto)
        {
            var res = await _service.SaveThongSoCLNAoAsync(dto);
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
            var res = await _service.DeleteThongSoCLNAoAsync(Id);
            if (res == true)
            {
                return Ok(new { message = "Dữ liệu: Dữ liệu đã được xóa" });
            }
            else
            {
                return BadRequest(new { message = "Dữ liệu: Lỗi xóa dữ liệu", error = true });
            }
        }
    }
}