using Application.Models.Address;
using Application.Models.Exceptions;
using Domain.AddressAggregate.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        #region Properties
        private readonly IAddressAppService _addressAppService;
        #endregion

        #region Constructors
        public AddressesController(IAddressAppService addressAppService)
        {
            _addressAppService = addressAppService;
        }
        #endregion

        #region Methods
        [HttpGet("{code}", Name = "GetAddress")]
        [ProducesResponseType(typeof(GetAddressResponse), 200)]
        [ProducesResponseType(typeof(NotFoundResponseModel), 404)]
        [ProducesResponseType(typeof(PreconditionFailedResponseModel), 412)]
        public async Task<IActionResult> Get(string code)
        {
            var response = await _addressAppService.GetByCodeAsync(code);
            return base.StatusCode((int)HttpStatusCode.OK, response);
        }

        [HttpPost]
        [ProducesResponseType(typeof(GetAddressResponse), 201)]
        public async Task<IActionResult> Post([FromBody] CreateAddressRequest request)
        {
            if (ModelState.IsValid == false)
            {
                return base.BadRequest(request);
            }

            await _addressAppService.AddAsync(request);

            return base.StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut("{code}")]
        [ProducesResponseType(typeof(NotFoundResponseModel), 404)]
        [ProducesResponseType(typeof(PreconditionFailedResponseModel), 412)]
        public async Task<IActionResult> Put(string code, [FromBody] UpdateAddressRequest request)
        {
            if (ModelState.IsValid == false)
            {
                return base.BadRequest(request);
            }

            await _addressAppService.UpdateAsync(code, request);

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

            await _addressAppService.LogicDeleteAsync(code);

            return base.StatusCode((int)HttpStatusCode.OK);
        }
        #endregion
    }
}