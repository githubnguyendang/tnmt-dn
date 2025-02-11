using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using tnmt_qn.Service;
using tnmt_qn.Dto;
using Microsoft.AspNetCore.Authorization;

namespace tnmt_qn.Controllers
{
    [ApiController]
    [Route("forecast-dakdrinh")]
    [Authorize]
    public class ForecastDakdrinhController : ControllerBase
    {
        private readonly ForecaseDakdrinhInflowService _forecastDakdrinhService;

        public ForecastDakdrinhController(ForecaseDakdrinhInflowService forecastDakdrinhService)
        {
            _forecastDakdrinhService = forecastDakdrinhService;
        }

        [HttpPost("predict")]
        public ActionResult<List<float>> PredictInflow([FromBody] InflowPredictionInputDto input)
        {
            try
            {
                if (input.XQuangNgai == null || input.XDakTo == null ||
                    input.XQuangNgai.Length != input.XDakTo.Length)
                {
                    return BadRequest("Input data must contain two arrays of equal length.");
                }

                var prediction = _forecastDakdrinhService.PredictInflow(input.XQuangNgai, input.XDakTo);
                return Ok(prediction);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occurred: {ex.Message}");
            }

        }
    }
}