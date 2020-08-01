using Application.Models.Exceptions;
using Application.Models.Phone;
using Domain.PhoneAggregate.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhonesController : ControllerBase
    {
        #region Properties
        private readonly IPhoneAppService _phoneAppService;
        #endregion

        #region Constructor
        public PhonesController(IPhoneAppService phoneAppService)
        {
            this._phoneAppService = phoneAppService;
        }
        #endregion

        #region Methods
        [ProducesResponseType(typeof(GetPhoneResponse), 200)]
        [ProducesResponseType(typeof(NotFoundResponseModel), 404)]
        [ProducesResponseType(typeof(PreconditionFailedResponseModel), 412)]
        [HttpGet("{code}", Name = "GetPhone")]
        public async Task<IActionResult> Get(string code)
        {
            var response = await _phoneAppService.GetByCodeAsync(code);
            return base.StatusCode((int)HttpStatusCode.OK, response);
        }

        [HttpPost]
        [ProducesResponseType(typeof(GetPhoneResponse), 201)]
        public async Task<IActionResult> Post([FromBody] CreatePhoneRequest request)
        {
            if (ModelState.IsValid == false)
            {
                return base.BadRequest(request);
            }

            await _phoneAppService.AddAsync(request);

            return base.StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut("{code}")]
        [ProducesResponseType(typeof(NotFoundResponseModel), 404)]
        [ProducesResponseType(typeof(PreconditionFailedResponseModel), 412)]
        public async Task<IActionResult> Put(string code, [FromBody] UpdatePhoneRequest request)
        {
            if (ModelState.IsValid == false)
            {
                return base.BadRequest(request);
            }

            await _phoneAppService.UpdateAsync(code, request);

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

            await _phoneAppService.LogicDeleteAsync(code);

            return base.StatusCode((int)HttpStatusCode.OK);
        }
        #endregion
    }
}