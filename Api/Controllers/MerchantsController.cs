using Api.Attributes;
using Application.Models.Exceptions;
using Application.Models.Merchant;
using Domain.MerchantAggregate.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    [TypeFilter(typeof(HandleErrorAttribute))]
    public class MerchantsController : ControllerBase
    {
        #region Properties
        private readonly IMerchantAppService _merchantAppService;
        #endregion

        #region Constructor
        public MerchantsController(IMerchantAppService merchantAppService)
        {
            this._merchantAppService = merchantAppService;
        }
        #endregion

        #region Methods
        [HttpGet("{code}", Name = "GetMerchant")]
        [ProducesResponseType(typeof(GetMerchantResponse), 200)]
        [ProducesResponseType(typeof(NotFoundResponseModel), 404)]
        [ProducesResponseType(typeof(PreconditionFailedResponseModel), 412)]
        public async Task<IActionResult> Get(string code)
        {
            var response = await _merchantAppService.GetByCodeAsync(code);
            return base.StatusCode((int)HttpStatusCode.OK, response);
        }

        [HttpPost]
        [ProducesResponseType(typeof(GetMerchantResponse), 201)]
        public async Task<IActionResult> Post([FromBody] CreateMerchantRequest request)
        {
            if (ModelState.IsValid == false)
            {
                return base.BadRequest(request);
            }

            var response = await _merchantAppService.AddAsync(request);

            return base.StatusCode((int)HttpStatusCode.Created, response);
        }

        [HttpPut("{code}")]
        [ProducesResponseType(typeof(NotFoundResponseModel), 404)]
        [ProducesResponseType(typeof(PreconditionFailedResponseModel), 412)]
        public async Task<IActionResult> Put(string code, [FromBody] UpdateMerchantRequest request)
        {
            if (ModelState.IsValid == false)
            {
                return base.BadRequest(request);
            }

            await _merchantAppService.UpdateAsync(code, request);

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

            await _merchantAppService.LogicDeleteAsync(code);

            return base.StatusCode((int)HttpStatusCode.OK);
        }
        #endregion
    }
}