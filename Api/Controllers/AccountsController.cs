using Application.Interfaces;
using Application.Models.Account;
using Application.Models.Address;
using Application.Models.Exceptions;
using Application.Models.Phone;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        #region Properties
        private readonly IAccountAppService _accountAppService;
        #endregion

        #region Constructors
        public AccountsController(IAccountAppService accountAppService)
        {
            this._accountAppService = accountAppService;
        }
        #endregion

        #region Methods
        [HttpGet("{code}", Name = "GetAccount")]
        [ProducesResponseType(typeof(GetAccountResponse), 200)]
        [ProducesResponseType(typeof(NotFoundResponseModel), 404)]
        [ProducesResponseType(typeof(PreconditionFailedResponseModel), 412)]
        public async Task<IActionResult> Get(string code)
        {
            var response = await _accountAppService.GetByCodeAsync(code);
            return base.StatusCode((int)HttpStatusCode.OK, response);
        }

        [HttpPost(Name = "PostAccount")]
        [ProducesResponseType(typeof(GetAccountResponse), 201)]
        public async Task<IActionResult> Post([FromBody] CreateAccountRequest request)
        {
            if (ModelState.IsValid == false)
            {
                return base.BadRequest(request);
            }

            var response = await _accountAppService.AddAsync(request);

            return base.StatusCode((int)HttpStatusCode.Created, response);
        }

        [HttpPost("full", Name = "PostAccountFull")]
        [ProducesResponseType(typeof(GetAccountResponse), 201)]
        public async Task<IActionResult> PostFull([FromBody] CreateAccountFullRequest request)
        {
            if (ModelState.IsValid == false)
            {
                return base.BadRequest(request);
            }

            var response = await _accountAppService.AddAsync(request);

            return base.StatusCode((int)HttpStatusCode.Created, response);
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

            await _accountAppService.UpdatePhoneAsync(code, request);

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

            await _accountAppService.LogicDeleteAsync(code);

            return base.StatusCode((int)HttpStatusCode.OK);
        }

        [HttpPut("{code}/phone")]
        public async Task<IActionResult> PutPhone(string code, [FromBody] UpdatePhoneRequest request)
        {
            //todo: ProducesResponseType

            if (ModelState.IsValid == false)
            {
                return base.BadRequest(request);
            }

            await _accountAppService.UpdatePhoneAsync(code, request);

            return base.StatusCode((int)HttpStatusCode.OK);
        }

        [HttpPut("{code}/address")]
        public async Task<IActionResult> PutAddress(string code, [FromBody] UpdateAddressRequest request)
        {
            //todo: ProducesResponseType

            if (ModelState.IsValid == false)
            {
                return base.BadRequest(request);
            }

            await _accountAppService.UpdateAddressAsync(code, request);

            return base.StatusCode((int)HttpStatusCode.OK);
        }

        [HttpPost("{code}/account-beverage")]
        public async Task<IActionResult> PostAccountBeverage(string code, [FromBody] CreateAccountBeverageRequest request)
        {
            //todo: ProducesResponseType

            if (ModelState.IsValid == false)
            {
                return base.BadRequest(request);
            }

            var response = await _accountAppService.AddAccountBeverageAsync(code, request);

            return base.StatusCode((int)HttpStatusCode.OK, response);
        }
        #endregion
    }
}