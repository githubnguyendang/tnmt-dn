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
    public class ThongSoDiemQuanTracController : ControllerBase
    {
        private readonly ThongSoDiemQuanTracService _service;

        public ThongSoDiemQuanTracController(ThongSoDiemQuanTracService service)
        {
            _service = service;
        }
        [HttpGet]
        [Route("list")]
        public async Task<List<ThongSoDiemQuanTracDto>> GetAllData()
        {
            return (await _service.GetAllDataAsync());
        }

        [HttpGet]
        [Route("danh-sach")]
        public async Task<List<ThongSoDiemQuanTracDto>> GetAll(int nam)
        {
            return (await _service.GetAllAsync(nam));
        }

        [HttpPost]
        [Route("luu")]
        public async Task<ActionResult<ThongSoDiemQuanTrac>> Save(ThongSoDiemQuanTracDto moddel)
        {
            var res = await _service.SaveAsync(moddel);
            if (res == true)
            {
                return Ok(new { message = "Dữ liệu :Dữ liệu đã được lưu" });
            }
            else
            {
                return BadRequest(new { message = "Dữ liệu :Lỗi lưu dữ liệu", error = true });
            }
        }

        [HttpGet]
        [Route("xoa/{Id}")]
        public async Task<ActionResult<ThongSoDiemQuanTrac>> Delete(int Id)
        {
            var res = await _service.DeleteAsync(Id);
            if (res == true)
            {
                return Ok(new { message = "Dữ liệu :Dữ liệu đã được xóa" });
            }
            else
            {
                return BadRequest(new { message = "Dữ liệu :Lỗi xóa dữ liệu", error = true });
            }
        }
    }
}
