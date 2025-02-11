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
    public class DuLieuTramController : ControllerBase
    {
        private readonly DuLieuTramService _service;

        public DuLieuTramController(DuLieuTramService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("danh-sach")]
        public async Task<List<DuLieuTramDto>> GetAll()
        {
            return (await _service.GetAllDuLieuTramAsync());
        }
        
        [HttpGet]
        [Route("lay-theo-id-tram-1-gio/{IdTram}")]
        public async Task<List<DuLieuTramDto>> GetRainDataByStationFor1HourId(int IdTram, DateTime StartTime, DateTime EndTime)
        {
            return (await _service.GetRainDataByStationIdFor1HourAsync(IdTram, StartTime, EndTime));
        }

        [HttpGet]
        [Route("lay-theo-id-tram-6-gio/{IdTram}")]
        public async Task<List<DuLieuTramDto>> GetRainDataByStationIdFor6Hour(int IdTram, DateTime StartTime, DateTime EndTime)
        {
            return (await _service.GetRainDataByStationIdFor6HourAsync(IdTram, StartTime, EndTime));
        }

        [HttpGet]
        [Route("lay-theo-id-tram-12-gio/{IdTram}")]
        public async Task<List<DuLieuTramDto>> GetRainDataByStationIdFor12Hour(int IdTram, DateTime StartTime, DateTime EndTime)
        {
            return (await _service.GetRainDataByStationIdFor12HourAsync(IdTram, StartTime, EndTime));
        }

        [HttpGet]
        [Route("lay-theo-id-tram-24-gio/{IdTram}")]
        public async Task<List<DuLieuTramDto>> GetRainDataByStationIdFor24Hour(int IdTram, DateTime StartTime, DateTime EndTime)
        {
            return (await _service.GetRainDataByStationIdFor24HourAsync(IdTram, StartTime, EndTime));
        }

        [HttpGet]
        [Route("thong-ke-yeu-to-khi-tuong-1-gio/{IdTram}")]
        public async Task<List<ApexChartSeriesTramDto>> YeuToKhiTuong1Hour(int IdTram)
        {
            return (await _service.YeuToKhiTuong1HourAsync(IdTram));
        }
        [HttpGet]
        [Route("thong-ke-yeu-to-khi-tuong-6-gio/{IdTram}")]
        public async Task<List<ApexChartSeriesTramDto>> YeuToKhiTuong6Hour(int IdTram)
        {
            return (await _service.YeuToKhiTuong6HourAsync(IdTram));
        }

        [HttpGet]
        [Route("thong-ke-yeu-to-khi-tuong-12-gio/{IdTram}")]
        public async Task<List<ApexChartSeriesTramDto>> YeuToKhiTuong12Hour(int IdTram)
        {
            return (await _service.YeuToKhiTuong12HourAsync(IdTram));
        }

        [HttpGet]
        [Route("thong-ke-yeu-to-khi-tuong-24-gio/{IdTram}")]
        public async Task<List<ApexChartSeriesTramDto>> YeuToKhiTuong24Hour(int IdTram)
        {
            return (await _service.YeuToKhiTuong24HourAsync(IdTram));
        }

        [HttpGet]
        [Route("xoa/{Id}")]
        public async Task<ActionResult<DuLieuTram>> Delete(int Id)
        {
            var res = await _service.DeleteAsync(Id);
            if (res == true)
            {
                return Ok(new { message = "Trạm :Dữ liệu đã được xóa" });
            }
            else
            {
                return BadRequest(new { message = "Trạm :Lỗi xóa dữ liệu", error = true });
            }
        }
    }
}
