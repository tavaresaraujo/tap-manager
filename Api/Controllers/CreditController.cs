using Application.Models.Credit;
using Application.Models.Exceptions;
using Domain.UserAggregate.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditController : ControllerBase
    {
        #region Properties
        private readonly ICreditAppService _creditAppService;
        #endregion

        #region Constructor
        public CreditController(ICreditAppService creditAppService)
        {
            this._creditAppService = creditAppService;
        }
        #endregion

        #region Methods
        [HttpGet("{code}", Name = "GetCredit")]
        [ProducesResponseType(typeof(GetCreditResponse), 200)]
        [ProducesResponseType(typeof(NotFoundResponseModel), 404)]
        [ProducesResponseType(typeof(PreconditionFailedResponseModel), 412)]
        public async Task<IActionResult> Get(string code)
        {
            var response = await _creditAppService.GetByCodeAsync(code);
            return base.StatusCode((int)HttpStatusCode.OK, response);
        }

        [HttpPost]
        [ProducesResponseType(typeof(GetCreditResponse), 201)]
        public async Task<IActionResult> Post([FromBody] CreateCreditRequest request)
        {
            if (ModelState.IsValid == false)
            {
                return base.BadRequest(request);
            }

            await _creditAppService.AddAsync(request);

            return base.StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut("{code}")]
        [ProducesResponseType(typeof(NotFoundResponseModel), 404)]
        [ProducesResponseType(typeof(PreconditionFailedResponseModel), 412)]
        public async Task<IActionResult> Put(string code, [FromBody] UpdateCreditRequest request)
        {
            if (ModelState.IsValid == false)
            {
                return base.BadRequest(request);
            }

            await _creditAppService.UpdateAsync(code, request);

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

            await _creditAppService.LogicDeleteAsync(code);

            return base.StatusCode((int)HttpStatusCode.OK);
        }
        #endregion
    }
}