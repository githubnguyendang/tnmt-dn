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
    public class NN_NguongKhaiThacNDDController : ControllerBase
    {
        private readonly NN_NguongKhaiThacNDDService _service;

        public NN_NguongKhaiThacNDDController(NN_NguongKhaiThacNDDService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("danh-sach")]
        public async Task<List<NN_NguongKhaiThacNDDDto>> GetAll()
        {
            return await _service.GetAllNguongKhaiThacNDDAsync();
        }

        [HttpPost]
        [Route("luu")]
        public async Task<ActionResult<NN_NguongKhaiThacNDDDto>> Save(NN_NguongKhaiThacNDDDto moddel)
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
        public async Task<ActionResult<NN_NguongKhaiThacNDDDto>> Delete(int Id)
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
