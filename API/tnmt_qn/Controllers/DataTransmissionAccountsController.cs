using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using tnmt_qn.Data;
using tnmt_qn.Dto;
using tnmt_qn.Service;
using OfficeOpenXml;
using System.IO;

namespace tnmt_qn.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class DataTransmissionAccountsController : ControllerBase
    {
        private readonly DataTransmissionAccountsService _service;

        public DataTransmissionAccountsController(DataTransmissionAccountsService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("list")]
        public async Task<List<DataTransmissionAccountsDto>> GetAllData()
        {
            return await _service.GetAllAsync();
        }

        [HttpGet]
        [Route("{Username}")]
        public async Task<List<DataTransmissionAccountsDto>> GetByConstruction(string Username)
        {
            return await _service.GetByConstructionCode(Username);
        }

        [HttpPost]
        [Route("save")]
        public async Task<ActionResult<DataTransmissionAccounts>> Save(List<DataTransmissionAccountsDto> dtos)
        {
            var res = await _service.SaveAsync(dtos);
            if (res > 0)
            {
                return Ok(new { message = "Saved  successfully" });
            }
            else
            {
                return BadRequest(new { message = "Saving  failed", error = true });
            }
        }

        [HttpGet]
        [Route("delete/{Id}")]
        public async Task<ActionResult<DataTransmissionAccounts>> Delete(int Id)
        {
            var res = await _service.DeleteAsync(Id);
            if (res == true)
            {
                return Ok(new { message = "DataTransmissionAccounts successfully deleted" });
            }
            else
            {
                return BadRequest(new { message = "Removing DataTransmissionAccounts failed", error = true });
            }
        }

    }
}
