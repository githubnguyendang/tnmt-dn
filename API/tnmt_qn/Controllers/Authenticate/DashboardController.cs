﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using tnmt_qn.Data;
using tnmt_qn.Dto;
using tnmt_qn.Service;

namespace tnmt_qn.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class DashboardController : ControllerBase
    {
        private readonly DashboardService _service;

        public DashboardController(DashboardService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("list")]
        public async Task<List<DashboardDto>> GetAllDashboard()
        {
            return (await _service.GetAllDashboardAsync());
        }

        [HttpGet]
        [Route("listbyrole/{roleName}")]
        public async Task<List<RoleDashboardDto>> GetAllDashboardByRole(string roleName)
        {
            return await _service.GetDashboardByRoleAsync(roleName);
        }

        [HttpGet]
        [Route("listbyuser/{userName}")]
        public async Task<List<UserDashboardDto>> GetAllDashboardByUser(string userName)
        {
            return await _service.GetDashboardByUserAsync(userName);
        }


        [HttpGet]
        [Route("{Id}")]
        public async Task<DashboardDto> GetDashboardById(int Id)
        {
            return await _service.GetDashboardByIdAsync(Id);
        }

        [HttpPost]
        [Route("save")]
        public async Task<ActionResult<Dashboards>> SaveDashboard(DashboardDto moddel)
        {
            var res = await _service.SaveDashboardAsync(moddel);
            if (res == true)
            {
                return Ok(new { message = "Saved dashboards successfully" });
            }
            else
            {
                return BadRequest(new { message = "Save dashboards failed", error = true });
            }
        }

        [HttpGet]
        [Route("xoa/{Id}")]
        public async Task<ActionResult<Dashboards>> DeleteDashboard(int Id)
        {
            var res = await _service.DeleteDashboardAsync(Id);
            if (res == true)
            {
                return Ok(new { message = "Dashboard successfully deleted" });
            }
            else
            {
                return BadRequest(new { message = "Removing Dashboard failed", error = true });
            }
        }
    }
}
