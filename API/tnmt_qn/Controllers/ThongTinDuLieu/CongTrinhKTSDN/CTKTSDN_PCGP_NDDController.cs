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
    public class CTKTSDN_PCGP_NDDController : ControllerBase
    {
        private readonly CTKTSDN_PCGP_NDDService _service;

        public CTKTSDN_PCGP_NDDController(CTKTSDN_PCGP_NDDService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("danh-sach")]
        public async Task<List<CTKTSDN_PCGP_NDDDto>> GetAll()
        {
            return await _service.GetAllCTKTSDN_PCGP_NDDAsync();
        }

        [HttpPost]
        [Route("luu")]
        public async Task<ActionResult<CTKTSDN_PCGP_NDDDto>> Save(CTKTSDN_PCGP_NDDDto moddel)
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
        public async Task<ActionResult<CTKTSDN_PCGP_NDDDto>> Delete(int Id)
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
