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
    public class StoragePreDataController : ControllerBase
    {
        private readonly StoragePreDataService _service;

        public StoragePreDataController(StoragePreDataService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("list")]
        public async Task<List<StoragePreDataDto>> GetAllData()
        {
            return await _service.GetAllAsync();
        }

        [HttpGet]
        [Route("{ConstructionCode}")]
        public async Task<List<StoragePreDataDto>> GetByConstruction(string ConstructionCode)
        {
            return await _service.GetByConstructionCode(ConstructionCode);
        }

        [HttpPost]
        [Route("save")]
        public async Task<ActionResult<StoragePreData>> Save(List<StoragePreDataDto> dtos)
        {
            var res = await _service.SaveAsync(dtos);
            if (res > 0)
            {
                return Ok(new { message = "Saved station successfully" });
            }
            else
            {
                return BadRequest(new { message = "Saving station failed", error = true });
            }
        }

        [HttpGet]
        [Route("delete/{Id}")]
        public async Task<ActionResult<StoragePreData>> Delete(int Id)
        {
            var res = await _service.DeleteAsync(Id);
            if (res == true)
            {
                return Ok(new { message = "StoragePreData successfully deleted" });
            }
            else
            {
                return BadRequest(new { message = "Removing StoragePreData failed", error = true });
            }
        }

        // *** Thêm chức năng upload file Excel ***
        [HttpPost]
        [Route("upload")]
        public async Task<IActionResult> UploadExcel(IFormFile file)
        {
            if (file == null || file.Length <= 0)
            {
                return BadRequest("Please upload a valid Excel file.");
            }

            if (!Path.GetExtension(file.FileName).Equals(".xls", StringComparison.OrdinalIgnoreCase) &&
                !Path.GetExtension(file.FileName).Equals(".xlsx", StringComparison.OrdinalIgnoreCase))
            {
                return BadRequest("Invalid file format. Only .xls and .xlsx files are allowed.");
            }

            // Thiết lập LicenseContext cho EPPlus
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            var records = new List<StoragePreDataDto>();

            using (var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream);
                using (var package = new ExcelPackage(stream))
                {
                    var worksheet = package.Workbook.Worksheets[0];
                    var rowCount = worksheet.Dimension.Rows;

                    for (int row = 2; row <= rowCount; row++)
                    {
                        var record = new StoragePreDataDto
                        {
                            ConstructionCode = worksheet.Cells[row, 1].Value?.ToString(),
                            StationCode = worksheet.Cells[row, 2].Value?.ToString(),
                            ParameterName = worksheet.Cells[row, 3].Value?.ToString(),
                            Value = double.TryParse(worksheet.Cells[row, 4].Value?.ToString(), out double value) ? value : 0,
                            Unit = worksheet.Cells[row, 5].Value?.ToString(),
                            Time = DateTime.TryParse(worksheet.Cells[row, 6].Value?.ToString(), out DateTime time) ? time : DateTime.Now,
                            DeviceStatus = int.TryParse(worksheet.Cells[row, 7].Value?.ToString(), out int deviceStatus) ? deviceStatus : 0,
                            Status = bool.TryParse(worksheet.Cells[row, 8].Value?.ToString(), out bool status) ? status : true
                        };
                        records.Add(record);
                    }
                }
            }

            var result = await _service.SaveAsync(records);

            if (result > 0)
            {
                return Ok(new { message = "File uploaded and data saved successfully", totalRecords = records.Count });
            }
            else
            {
                return BadRequest("Error saving data from Excel file.");
            }
        }

    }
}
