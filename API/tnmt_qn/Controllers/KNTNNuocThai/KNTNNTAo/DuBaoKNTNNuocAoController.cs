
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
    public class DuBaoKNTNNuocAoController : ControllerBase
    {
        private readonly DuBaoKhaNangTiepNhanNuocHoService _service;

        public DuBaoKNTNNuocAoController(DuBaoKhaNangTiepNhanNuocHoService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("danh-sach")]
        public async Task<List<DuBaoKhaNangTiepNhanNuocHoDto>> GetAll()
        {
            return (await _service.GetAllAsync());
        }


        [HttpPost]
        [Route("du-bao")]
        public async Task<ActionResult<DuBaoKhaNangTiepNhanNuocHoDto>> Save([FromBody] DuBaoKhaNangTiepNhanNuocHoDto model)
        {
            try
            {
                // Perform the calculation and save the results to the database
                var result = await _service.CalculateDuBaoAsync(model);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error saving data: " + ex.Message, error = true });
            }
        }

    }
}
