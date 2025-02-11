using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using tnmt_qn.Data;
using tnmt_qn.Dto;
using tnmt_qn.Service;

namespace tnmt_qn.Controllers
{
    [Route("hanh-chinh")]
    [ApiController]
    [Authorize]
    public class DonViHCController : ControllerBase
    {
        private readonly DonViHCService _service;

        public DonViHCController(DonViHCService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("huyen/danh-sach")]
        public async Task<List<HuyenDto>> GetAllDistricts()
        {
            return (await _service.GetAllDistrictAsync());
        }

        [HttpGet]
        [Route("xa/danh-sach")]
        public async Task<List<XaDto>> GetAllCommunes()
        {
            return (await _service.GetAllCommuneAsync());
        }

        [HttpGet]
        [Route("xa/danh-sach/{id_huyen}")]
        public async Task<List<XaDto>> GetAllCommunesByDistrict(string id_huyen)
        {
            return (await _service.GetAllCommuneByDistrictAsync(id_huyen));
        } 

        //[HttpPost]
        //[Route("luu")]
        //public async Task<ActionResult<DonViHC>> Save(ViTriDto moddel)
        //{
        //    var res = await _service.SaveAsync(moddel);
        //    if (res == true)
        //    {
        //        return Ok(new { message = "Dữ liệu đã được lưu" });
        //    }
        //    else
        //    {
        //        return BadRequest(new { message = "Lỗi lưu dữ liệu", error = true });
        //    }
        //}

        //[HttpGet]
        //[Route("xoa/{Id}")]
        //public async Task<ActionResult<DonViHC>> Delete(int Id)
        //{
        //    var res = await _service.DeleteAsync(Id);
        //    if (res == true)
        //    {
        //        return Ok(new { message = "Dữ liệu đã được xóa" });
        //    }
        //    else
        //    {
        //        return BadRequest(new { message = "Lỗi xóa dữ liệu", error = true });
        //    }
        //}
    }
}
