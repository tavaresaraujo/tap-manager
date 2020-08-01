using Application.Models.Exceptions;
using Application.Models.Supply;
using Domain.BeverageAggregate.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliesController : ControllerBase
    {
        #region Properties
        private readonly ISupplyAppService _supplyAppService;
        #endregion

        #region Constructors
        public SuppliesController(ISupplyAppService supplyAppService)
        {
            this._supplyAppService = supplyAppService;
        }
        #endregion

        #region Methods
        [ProducesResponseType(typeof(GetSupplyResponse), 200)]
        [ProducesResponseType(typeof(NotFoundResponseModel), 404)]
        [ProducesResponseType(typeof(PreconditionFailedResponseModel), 412)]
        [HttpGet("{code}", Name = "GetSupply")]
        public async Task<IActionResult> Get(string code)
        {
            var response = await _supplyAppService.GetByCodeAsync(code);
            return base.StatusCode((int)HttpStatusCode.OK, response);
        }

        [HttpPost]
        [ProducesResponseType(typeof(GetSupplyResponse), 201)]
        public async Task<IActionResult> Post([FromBody] CreateSupplyRequest request)
        {
            if (ModelState.IsValid == false)
            {
                return base.BadRequest(request);
            }

            var response = await _supplyAppService.AddAsync(request);

            return base.StatusCode((int)HttpStatusCode.Created, response);
        }

        [HttpPut("{code}")]
        [ProducesResponseType(typeof(NotFoundResponseModel), 404)]
        [ProducesResponseType(typeof(PreconditionFailedResponseModel), 412)]
        public async Task<IActionResult> Put(string code, [FromBody] UpdateSupplyRequest request)
        {
            if (ModelState.IsValid == false)
            {
                return base.BadRequest(request);
            }

            await _supplyAppService.UpdateAsync(code, request);

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

            await _supplyAppService.LogicDeleteAsync(code);

            return base.StatusCode((int)HttpStatusCode.OK);
        }
        #endregion
    }
}