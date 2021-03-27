using Application.Models.Beverage;
using Application.Models.Exceptions;
using Domain.BeverageAggregate.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeveragesController : ControllerBase
    {
        #region Properties
        private readonly IBeverageAppService _beverageAppService;
        #endregion

        #region Constructors
        public BeveragesController(IBeverageAppService beverageAppService)
        {
            this._beverageAppService = beverageAppService;
        }
        #endregion

        #region Methods
        [ProducesResponseType(typeof(GetBeverageResponse), 200)]
        [ProducesResponseType(typeof(NotFoundResponseModel), 404)]
        [ProducesResponseType(typeof(PreconditionFailedResponseModel), 412)]
        public async Task<IActionResult> Get()
        {
            var response = await _beverageAppService.Get();
            return base.StatusCode((int)HttpStatusCode.OK, response);
        }

        [HttpGet("{code}", Name = "GetBeverage")]
        [ProducesResponseType(typeof(GetBeverageResponse), 200)]
        [ProducesResponseType(typeof(NotFoundResponseModel), 404)]
        [ProducesResponseType(typeof(PreconditionFailedResponseModel), 412)]
        public async Task<IActionResult> Get(string code)
        {
            var response = await _beverageAppService.GetByCodeAsync(code);
            return base.StatusCode((int)HttpStatusCode.OK, response);
        }

        [HttpPost]
        [ProducesResponseType(typeof(GetBeverageResponse), 201)]
        public async Task<IActionResult> Post([FromBody] CreateBeverageRequest request)
        {
            if (ModelState.IsValid == false)
            {
                return base.BadRequest(request);
            }

            var response = await _beverageAppService.AddAsync(request);

            return base.StatusCode((int)HttpStatusCode.Created, response);
        }

        [HttpPut("{code}")]
        [ProducesResponseType(typeof(NotFoundResponseModel), 404)]
        [ProducesResponseType(typeof(PreconditionFailedResponseModel), 412)]
        public async Task<IActionResult> Put(string code, [FromBody] UpdateBeverageRequest request)
        {
            if (ModelState.IsValid == false)
            {
                return base.BadRequest(request);
            }

            await _beverageAppService.UpdateAsync(code, request);

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

            await _beverageAppService.LogicDeleteAsync(code);

            return base.StatusCode((int)HttpStatusCode.OK);
        }

        [HttpPost("{code}/beverage-price")]
        public async Task<IActionResult> PostBeveragePrice(string code, [FromBody] CreateBeveragePriceRequest request)
        {
            if (ModelState.IsValid == false)
            {
                return base.BadRequest(request);
            }

            var response = await _beverageAppService.CreateBeveragePriceAsync(code, request);

            return base.StatusCode((int)HttpStatusCode.OK, response);
        }
        #endregion
    }
}