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
    public class NM_KhaiThacSuDungController : ControllerBase
    {
        private readonly NM_KhaiThacSuDungService _service;

        public NM_KhaiThacSuDungController(NM_KhaiThacSuDungService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("danh-sach")]
        public async Task<List<KKTNN_NuocMat_KhaiThacSuDungDto>> GetAll()
        {
            return (await _service.GetAllAsync());
        }
    }
}
