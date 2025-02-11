using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using tnmt_qn.Data;
using tnmt_qn.Dto;
using tnmt_qn.Service;

namespace tnmt_qn.Controllers
{
    [Route("muc-dich-kt")]
    [ApiController]
    [Authorize]
    public class MucDichKTController : ControllerBase
    {
        private readonly MucDichKTService _service;

        public MucDichKTController(MucDichKTService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("danh-sach")]
        public async Task<List<MucDichKTDto>> GetAll()
        {
            return (await _service.GetAllAsync());
        }

        [HttpPost]
        [Route("luu")]
        public async Task<ActionResult<MucDichKT>> Save(MucDichKTDto dto)
        {
            var res = await _service.SaveAsync(dto);
            if (res > 0)
            {
                return Ok(new { message = "Mục đihs khai thác: Dữ liệu đã được lưu", id = res });
            }
            else
            {
                return BadRequest(new { message = "Mục đihs khai thác: Lỗi lưu dữ liệu", error = true });
            }
        }

        [HttpGet]
        [Route("xoa/{Id}")]
        public async Task<ActionResult<MucDichKT>> Delete(int Id)
        {
            var res = await _service.DeleteAsync(Id);
            if (res == true)
            {
                return Ok(new { message = "Mục đihs khai thác: Dữ liệu đã được xóa" });
            }
            else
            {
                return BadRequest(new { message = "Mục đihs khai thác: Lỗi xóa dữ liệu", error = true });
            }
        }
    }
}
