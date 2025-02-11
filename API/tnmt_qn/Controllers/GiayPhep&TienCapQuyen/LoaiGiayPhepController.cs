using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using tnmt_qn.Data;
using tnmt_qn.Dto;

using tnmt_qn.Service;

namespace tnmt_qn.Controllers
{
    [Route("loai-gp")]
    [ApiController]
    [Authorize]
    public class LoaiGiayPhepController : ControllerBase
    {
        private readonly GP_LoaiService _service;

        public LoaiGiayPhepController(GP_LoaiService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("danh-sach")]
        public async Task<List<GP_LoaiDto>> GetAllGP_Loai()
        {
            return (await _service.GetAllAsync());
        }

        [HttpGet]
        [Route("{Id}")]
        public async Task<GP_LoaiDto?> GetGP_LoaiById(int Id)
        {
            return await _service.GetGP_LoaiByIdAsync(Id);
        }

        [HttpPost]
        [Route("luu")]
        public async Task<ActionResult<GP_Loai>> SaveGP_Loai(GP_LoaiDto dto)
        {
            var res = await _service.SaveAsync(dto);
            if (res == true)
            {
                return Ok(new { message = "Loại giấy phép: Dữ liệu đã được lưu" });
            }
            else
            {
                return BadRequest(new { message = "Loại giấy phép: Lỗi lưu dữ liệu", error = true });
            }
        }

        [HttpGet]
        [Route("xoa/{Id}")]
        public async Task<ActionResult<GP_Loai>> DeleteLicenseType(int Id)
        {
            var res = await _service.DeleteAsync(Id);
            if (res == true)
            {
                return Ok(new { message = "Loại giấy phép: Dữ liệu đã được xóa" });
            }
            else
            {
                return BadRequest(new { message = "Loại giấy phép: Lỗi xóa dữ liệu", error = true });
            }
        }
    }
}
