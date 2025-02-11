using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tnmt_qn.Data;
using tnmt_qn.Dto;
using tnmt_qn.Service;
using tnmt_qn.Service.BaoCaoBieuMau;

namespace tnmt_qn.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class BieuMauSoHaiMuoiController : ControllerBase
    {
        private readonly BieuMauHaiMuoiService _service;

        public BieuMauSoHaiMuoiController(BieuMauHaiMuoiService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("danhsach")]
        public async Task<List<CT_ThongTinDto>> GetAll()
        {
            return await _service.GetAllAsync();
        }

    }
}