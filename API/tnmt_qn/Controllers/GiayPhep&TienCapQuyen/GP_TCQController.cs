using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tnmt_qn.Data;
using tnmt_qn.Dto;
using tnmt_qn.Service;

namespace tnmt_qn.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class GP_TCQController : ControllerBase
    {
        private readonly IGP_TCQService _service;
        private readonly DatabaseContext _context;

        public GP_TCQController(IGP_TCQService service, DatabaseContext context)
        {
            _service = service;
            _context = context;
        }

        [HttpPost]
        [Route("luu")]
        public async Task<ActionResult<GP_TCQ>> SaveGP_TCQ(GP_TCQDto dto)
        {
            var res = await _service.SaveAsync(dto);
            if (res == true)
            {
                return Ok(new { message = "GP_TCQ: Đã tạo quan hệ" });
            }
            else
            {
                return BadRequest(new { message = "GP_TCQ: Lỗi tạo quan hệ", error = true });
            }
        }

        [HttpPost]
        [Route("xoa")]
        public async Task<ActionResult<GP_TCQ>> DeleteGP_TCQ(GP_TCQDto dto)
        {
            var res = await _service.DeleteAsync(dto);
            if (res == true)
            {
                return Ok(new { message = "GP_TCQ: Dữ liệu đã được xóa" });
            }
            else
            {
                return Ok(new { message = "GP_TCQ: Lỗi xóa dữ liệu", error = true });
            }
        }
    }
}
