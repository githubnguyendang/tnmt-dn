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
    public class BieuMauSoHaiHaiController : ControllerBase
    {
        private readonly BieuMauHaiHaiService _service;

        public BieuMauSoHaiHaiController(BieuMauHaiHaiService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("danhsach")]
        public async Task<List<BieuMauHaiHaiDto>> GetAll()
        {
            return await _service.GetAllBieuMauHaiHaiAsync();
        }

        [HttpPost]
        [Route("luu")]
        public async Task<ActionResult<BieuMauSoHaiHai>> Save(BieuMauHaiHaiDto dto)
        {
            var res = await _service.SaveBieuMauHaiHaiAsync(dto);
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
            var res = await _service.DeleteBieuMauHaiHaiAsync(Id);
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