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
    public class DoanSongController : ControllerBase
    {
        private readonly DoanSongService _service;

        public DoanSongController(DoanSongService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("danh-sach")]
        public async Task<List<DoanSongDto>> GetAllData(string? MucPLCLNuoc)
        {
            return await _service.GetAllAsync(MucPLCLNuoc);
        }
    }
}
