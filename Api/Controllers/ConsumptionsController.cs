using Application.Models.Consumption;
using Application.Models.Exceptions;
using Domain.BeverageAggregate.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsumptionsController : ControllerBase
    {
        #region Properties
        private readonly IConsumptionAppService _consumptionAppService;
        #endregion

        #region Constructors
        public ConsumptionsController(IConsumptionAppService consumptionAppService)
        {
            this._consumptionAppService = consumptionAppService;
        }
        #endregion

        #region Methods
        [HttpGet("{code}", Name = "GetConsumption")]
        [ProducesResponseType(typeof(GetConsumptionResponse), 200)]
        [ProducesResponseType(typeof(NotFoundResponseModel), 404)]
        [ProducesResponseType(typeof(PreconditionFailedResponseModel), 412)]
        public async Task<IActionResult> Get(string code)
        {
            var response = await _consumptionAppService.GetByCodeAsync(code);
            return base.StatusCode((int)HttpStatusCode.OK, response);
        }

        [HttpPost]
        [ProducesResponseType(typeof(GetConsumptionResponse), 201)]
        public async Task<IActionResult> Post([FromBody] CreateConsumptionRequest request)
        {
            if (ModelState.IsValid == false)
            {
                return base.BadRequest(request);
            }

            await _consumptionAppService.AddAsync(request);

            return base.StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut("{code}")]
        [ProducesResponseType(typeof(NotFoundResponseModel), 404)]
        [ProducesResponseType(typeof(PreconditionFailedResponseModel), 412)]
        public async Task<IActionResult> Put(string code, [FromBody] UpdateConsumptionRequest request)
        {
            if (ModelState.IsValid == false)
            {
                return base.BadRequest(request);
            }

            await _consumptionAppService.UpdateAsync(code, request);

            return base.StatusCode((int)HttpStatusCode.OK);
        }

        [HttpDelete("{code}")]
        [ProducesResponseType(typeof(NotFoundResponseModel), 404)]
        [ProducesResponseType(typeof(PreconditionFailedResponseModel), 412)]
        public async Task<IActionResult> Delete(string code)
        {
            if (ModelState.IsValid == false)
            {
                return base.BadRequest(code);
            }

            await _consumptionAppService.LogicDeleteAsync(code);

            return base.StatusCode((int)HttpStatusCode.OK);
        }
        #endregion
    }
}