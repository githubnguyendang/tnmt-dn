using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using tnmt_qn.Data;
using tnmt_qn.Dto;
using tnmt_qn.Service;
using static tnmt_qn.Dto.TaiLuongNuocThaiSongDBDto;

namespace tnmt_qn.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class TaiLuongNuocThaiSongDBController : ControllerBase
    {
        private readonly TaiLuongNuocThaiSongDBService _service;

        public TaiLuongNuocThaiSongDBController(TaiLuongNuocThaiSongDBService service)
        {
            _service = service;
        }

     

        [HttpGet("tai-luong")]
        public async Task<ActionResult<List<TaiLuongNuocThaiSongDBDto>>> GetCalculatedPollutantData()
        {
            try
            {
                var phanDoanSongsWithComputedData = await _service.GetDataCaculatePolutantAsync();
                return Ok(phanDoanSongsWithComputedData);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
