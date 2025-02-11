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
    public class SLDTKTSDN_NuocMatController : ControllerBase
    {
        private readonly SLDTKTSDN_NuocMatService _service;

        public SLDTKTSDN_NuocMatController(SLDTKTSDN_NuocMatService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("danh-sach")]
        public async Task<List<SLDTKTSDN_NuocMatDto>> GetAll()
        {
            return await _service.GetAllSLDTKTSDN_NuocMatAsync();
        }

        [HttpPost]
        [Route("luu")]
        public async Task<ActionResult<SLDTKTSDN_NuocMatDto>> Save(SLDTKTSDN_NuocMatDto moddel)
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
        public async Task<ActionResult<SLDTKTSDN_NuocMatDto>> Delete(int Id)
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
