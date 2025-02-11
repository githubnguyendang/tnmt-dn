using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using tnmt_qn.Data;
using tnmt_qn.Dto;
using tnmt_qn.Service;
using static tnmt_qn.Dto.PhanDoanSongDto;

namespace tnmt_qn.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class PhanDoanSongController : ControllerBase
    {
        private readonly PhanDoanSongService _service;

        public PhanDoanSongController(PhanDoanSongService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("danh-sach")]
        public async Task<List<PhanDoanSongDto>> GetAll(string? phanDoan)
        {
            return (await _service.GetAllAsync(phanDoan));
        }

        [HttpGet]
        [Route("{Id}")]
        public async Task<PhanDoanSongDto?> GetById(int Id)
        {
            return await _service.GetByIdAsync(Id);
        }

        [HttpPost]
        [Route("luu")]
        public async Task<ActionResult<PhanDoanSong>> Save(PhanDoanSongDto moddel)
        {
            var res = await _service.SaveAsync(moddel);
            if (res == true)
            {
                return Ok(new { message = "Lưu vực :Dữ liệu đã được lưu" });
            }
            else
            {
                return BadRequest(new { message = "Lưu vực :Lỗi lưu dữ liệu", error = true });
            }
        }

        [HttpGet]
        [Route("xoa/{Id}")]
        public async Task<ActionResult<PhanDoanSong>> Delete(int Id)
        {
            var res = await _service.DeleteAsync(Id);
            if (res == true)
            {
                return Ok(new { message = "Lưu vực :Dữ liệu đã được xóa" });
            }
            else
            {
                return BadRequest(new { message = "Lưu vực :Lỗi xóa dữ liệu", error = true });
            }
        }

        [HttpGet("tai-luong")]
        public async Task<ActionResult<List<PhanDoanSongDto>>> GetCalculatedPollutantDataNormal(string? phanDoan)
        {
            try
            {
                var phanDoanSongsWithComputedData = await _service.GetDataCaculatePolutantNormalAsync(phanDoan);
                return Ok(phanDoanSongsWithComputedData);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpGet("tai-luong-du-bao")]
        public async Task<ActionResult<List<PhanDoanSongDto>>> GetCalculatedPollutantDataDB(string? phanDoan)
        {
            try
            {
                var phanDoanSongsWithComputedData = await _service.GetDataCaculatePolutantDBAsync(phanDoan);
                return Ok(phanDoanSongsWithComputedData);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }
}
