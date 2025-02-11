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
    public class CTKTSDN_KTNDDCuaHoGDController : ControllerBase
    {
        private readonly CTKTSDN_KTNDDCuaHoGDService _service;

        public CTKTSDN_KTNDDCuaHoGDController(CTKTSDN_KTNDDCuaHoGDService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("danh-sach")]
        public async Task<List<CTKTSDN_KTNDDCuaHoGDDto>> GetAll()
        {
            return await _service.GetAllCTKTSDN_KTNDDCuaHoGDAsync();
        }

        [HttpPost]
        [Route("luu")]
        public async Task<ActionResult<CTKTSDN_KTNDDCuaHoGDDto>> Save(CTKTSDN_KTNDDCuaHoGDDto moddel)
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
        public async Task<ActionResult<CTKTSDN_KTNDDCuaHoGDDto>> Delete(int Id)
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
