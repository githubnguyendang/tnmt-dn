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
    public class NMua_TongLuongController : ControllerBase
    {
        private readonly NMua_TongLuongService _service;

        public NMua_TongLuongController(NMua_TongLuongService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("danh-sach/{nam_bao_cao}")]
        public List<Tram_ThongTinDto> GetAll(string nam_bao_cao)
        {
            return (_service.GetAll(nam_bao_cao));
        }

        [HttpPost]
        [Route("luu")]
        public async Task<ActionResult<KKTNN_NuocMua_TongLuongDto>> Save(KKTNN_NuocMua_TongLuongDto moddel)
        {
            var res = await _service.SaveAsync(moddel);
            if (res == true)
            {
                return Ok(new { message = "Dữ liệu đã được lưu" });
            }
            else
            {
                return BadRequest(new { message = "Lỗi lưu dữ liệu", error = true });
            }
        }

        [HttpGet]
        [Route("xoa/{Id}")]
        public async Task<ActionResult<KKTNN_NuocMua_TongLuongDto>> Delete(int Id)
        {
            var res = await _service.DeleteAsync(Id);
            if (res == true)
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
