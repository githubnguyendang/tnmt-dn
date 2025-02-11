using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using tnmt_qn.Data;
using tnmt_qn.Dto;
using tnmt_qn.Service;

namespace tnmt_qn.Controllers
{
    [Route("giay-phep")]
    [ApiController]
    [Authorize]
    public class GiayPhepController : ControllerBase
    {
        private readonly IGP_ThongTinService _service;

        public GiayPhepController(IGP_ThongTinService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("danh-sach")]
        public async Task<List<GP_ThongTinDto>> GetAllData([FromQuery] GPFilterFormDto filterFormDto)
        {
            return await _service.GetAllAsync(filterFormDto);
        }

        [HttpGet]
        [Route("dem-theo-co-quan-cp")]
        public async Task<CountFolowLicensingAuthoritiesDto> CountFolowLicensingAuthorities()
        {
            return await _service.CountFolowLicensingAuthoritiesAsync();
        }

        [HttpGet]
        [Route("dem-theo-loai-ct")]
        public async Task<CountFolowConstructionTypesDto> CountFolowConstructionTypes()
        {
            return await _service.CountFolowConstructionTypesAsync();
        }

        [HttpGet]
        [Route("thong-ke-gp")]
        public async Task<LicenseStatisticsDto> LicenseStatistics([FromQuery] GPFilterFormDto filterFormDto)
        {
            return await _service.LicenseStatisticsAsync(filterFormDto);
        }

        [HttpGet]
        [Route("{Id}")]
        public async Task<GP_ThongTinDto> GetOneData(int Id)
        {
            return await _service.GetByIdAsync(Id);
        }

        [HttpPost]
        [Route("luu")]
        public async Task<ActionResult<GP_ThongTin>> SaveConstruction(GP_ThongTinDto dto)
        {
            var res = await _service.SaveAsync(dto);
            if (res > 0)
            {
                return Ok(new { message = "Giấy phép: Dữ liệu đã được lưu", id = res });
            }
            else
            {
                return BadRequest(new { message = "Giấy phép: Lỗi lưu dữ liệu", error = true });
            }
        }

        [HttpGet]
        [Route("xoa/{Id}")]
        public async Task<ActionResult<GP_ThongTin>> DeleteConstruction(int Id)
        {
            var res = await _service.DeleteAsync(Id);
            if (res == true)
            {
                return Ok(new { message = "Giấy phép: Dữ liệu đã được xóa" });
            }
            else
            {
                return BadRequest(new { message = "Giấy phép: Lỗi xóa dữ liệu", error = true });
            }
        }
    }
}
