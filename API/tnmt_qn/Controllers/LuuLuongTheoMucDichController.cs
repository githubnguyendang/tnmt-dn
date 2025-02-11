using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using tnmt_qn.Data;
using tnmt_qn.Dto;
using tnmt_qn.Service;

namespace tnmt_qn.Controllers
{
    //[Route("luu-luong-theo-muc-dich")]
    //[ApiController]
    //[Authorize]
    //public class LuuLuongTheoMucDichController : ControllerBase
    //{
    //    private readonly LuuLuongTheoMucDichService _service;

    //    public LuuLuongTheoMucDichController(LuuLuongTheoMucDichService service)
    //    {
    //        _service = service;
    //    }

    //    [HttpPost]
    //    [Route("luu")]
    //    public async Task<ActionResult<LuuLuongTheoMucDich>> Save(LuuLuongTheoMucDichDto dto)
    //    {
    //        var res = await _service.SaveAsync(dto);
    //        if (res > 0)
    //        {
    //            return Ok(new { message = "Lưu lượng theo mục đích: Dữ liệu đã được lưu", id = res });
    //        }
    //        else
    //        {
    //            return BadRequest(new { message = "Lưu lượng theo mục đích: Lỗi lưu dữ liệu", error = true });
    //        }
    //    }

    //    [HttpGet]
    //    [Route("xoa/{Id}")]
    //    public async Task<ActionResult<LuuLuongTheoMucDich>> Delete(int Id)
    //    {
    //        var res = await _service.DeleteAsync(Id);
    //        if (res == true)
    //        {
    //            return Ok(new { message = "Lưu lượng theo mục đích: Dữ liệu đã được xóa" });
    //        }
    //        else
    //        {
    //            return BadRequest(new { message = "Lưu lượng theo mục đích: Lỗi xóa dữ liệu", error = true });
    //        }
    //    }
    //}
}
