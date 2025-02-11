using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tnmt_qn.Data;
using tnmt_qn.Dto;
using tnmt_qn.Service;

namespace tnmt_qn.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class GiamSatSoLieuController : ControllerBase
    {
        private readonly GiamSatService _service;

        public GiamSatSoLieuController(GiamSatService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("danhsach")]
        public async Task<List<GS_SoLieuDto>> GetAll(string? MaCT,string? tenct, int? loai_ct)
        {
            return await _service.GetAllAsync(MaCT, tenct, loai_ct);
        }

        [HttpGet]
        [Route("thong-tin")]
        public async Task<List<StoragePreDataDto>> GetAll(string? ConstructionCode, DateTime StartDate, DateTime EndDate)
        {
            return await _service.GetAllDetailsAsync(ConstructionCode, StartDate, EndDate);
        }
    }
}