using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using tnmt_qn.Data;
using tnmt_qn.Dto;
using tnmt_qn.Service;

namespace tnmt_qn.Controllers
{
    [Route("tien-cap-quyen")]
    [ApiController]
    [Authorize]
    public class TienCapQuyenController : ControllerBase
    {
        private readonly ITCQ_ThongTinService _service;

        public TienCapQuyenController(ITCQ_ThongTinService service)
        {
            _service = service;
        }
        
        [HttpGet]
        [Route("danh-sach")]
        public async Task<List<TCQ_ThongTinDto>> GetByLicensingAuthorities([FromQuery] TCQ_FilterDto filterDto)
        {
            return (await _service.GetByLicensingAuthoritiesAsync(filterDto));
        }

        [HttpGet]
        [Route("{Id}")]
        public async Task<TCQ_ThongTinDto> GetById(int Id)
        {
            return await _service.GetByIdAsync(Id);
        }

        [HttpPost]
        [Route("luu")]
        public async Task<ActionResult<TCQ_ThongTin>> Save(TCQ_ThongTinDto dto)
        {
            var res = await _service.SaveAsync(dto);
            if (res > 0)
            {
                return Ok(new { message = "Tiền cấp quyền: Dữ liệu đã được lưu", id = res });
            }
            else
            {
                return BadRequest(new { message = "Tiền cấp quyền: Lỗi lưu dữ liệu", error = true });
            }
        }

        [HttpGet]
        [Route("xoa/{Id}")]
        public async Task<ActionResult<TCQ_ThongTin>> Delete(int Id)
        {
            var res = await _service.DeleteAsync(Id);
            if (res == true)
            {
                return Ok(new { message = "Tiền cấp quyền: Dữ liệu đã được xóa" });
            }
            else
            {
                return BadRequest(new { message = "Tiền cấp quyền: Lỗi xóa dữ liệu", error = true });
            }
        }
    }
}
