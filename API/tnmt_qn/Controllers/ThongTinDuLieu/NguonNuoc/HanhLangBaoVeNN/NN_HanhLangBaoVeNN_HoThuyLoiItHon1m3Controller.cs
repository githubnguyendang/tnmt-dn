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
    public class NN_HanhLangBaoVeNN_HoThuyLoiItHon1m3Controller : ControllerBase
    {
        private readonly NN_HanhLangBaoVeNN_HoThuyLoiItHon1m3Service _service;

        public NN_HanhLangBaoVeNN_HoThuyLoiItHon1m3Controller(NN_HanhLangBaoVeNN_HoThuyLoiItHon1m3Service service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("danh-sach")]
        public async Task<List<NN_HanhLangBaoVeNN_HoThuyLoiItHon1m3Dto>> GetAll()
        {
            return await _service.GetAllHanhLangBaoVeNN_HoThuyLoiItHon1m3Async();
        }

        [HttpPost]
        [Route("luu")]
        public async Task<ActionResult<NN_HanhLangBaoVeNN_HoThuyLoiItHon1m3Dto>> Save(NN_HanhLangBaoVeNN_HoThuyLoiItHon1m3Dto moddel)
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
        public async Task<ActionResult<NN_HanhLangBaoVeNN_HoThuyLoiItHon1m3Dto>> Delete(int Id)
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
