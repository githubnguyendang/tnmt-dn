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
    public class SLDTKTSDN_XaThaiController : ControllerBase
    {
        private readonly SLDTKTSDN_XaThaiService _service;

        public SLDTKTSDN_XaThaiController(SLDTKTSDN_XaThaiService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("danh-sach")]
        public async Task<List<SLDTKTSDN_XaThaiDto>> GetAll()
        {
            return await _service.GetAllSLDTKTSDN_XaThaiAsync();
        }

        [HttpPost]
        [Route("luu")]
        public async Task<ActionResult<SLDTKTSDN_XaThaiDto>> Save(SLDTKTSDN_XaThaiDto moddel)
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
        public async Task<ActionResult<SLDTKTSDN_XaThaiDto>> Delete(int Id)
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
