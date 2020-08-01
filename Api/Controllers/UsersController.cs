using Application.Models.Consumption;
using Application.Models.Credit;
using Application.Models.Exceptions;
using Application.Models.User;
using Domain.UserAggregate.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        #region Properties
        private readonly IUserAppService _userAppService;
        #endregion

        #region Constructors
        public UsersController(IUserAppService UserAppService)
        {
            this._userAppService = UserAppService;
        }
        #endregion

        #region Methods
        [HttpGet("{code}", Name = "GetUser")]
        [ProducesResponseType(typeof(GetUserResponse), 200)]
        [ProducesResponseType(typeof(NotFoundResponseModel), 404)]
        [ProducesResponseType(typeof(PreconditionFailedResponseModel), 412)]
        public async Task<IActionResult> Get(string code)
        {
            var response = await _userAppService.GetByCodeAsync(code);
            return base.StatusCode((int)HttpStatusCode.OK, response);
        }

        [HttpPost]
        [ProducesResponseType(typeof(GetUserResponse), 201)]
        public async Task<IActionResult> Post([FromBody] CreateUserRequest request)
        {
            if (ModelState.IsValid == false)
            {
                return base.BadRequest(request);
            }

            var response = await _userAppService.AddAsync(request);

            return base.StatusCode((int)HttpStatusCode.Created, response);
        }

        [HttpPut("{code}")]
        [ProducesResponseType(typeof(NotFoundResponseModel), 404)]
        [ProducesResponseType(typeof(PreconditionFailedResponseModel), 412)]
        public async Task<IActionResult> Put(string code, [FromBody] UpdateUserRequest request)
        {
            if (ModelState.IsValid == false)
            {
                return base.BadRequest(request);
            }

            await _userAppService.UpdateAsync(code, request);

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

            await _userAppService.LogicDeleteAsync(code);

            return base.StatusCode((int)HttpStatusCode.OK);
        }

        [HttpPost("{code}/credit")]
        public async Task<IActionResult> PostCredit(string code, [FromBody] CreateCreditRequest request)
        {
            if (ModelState.IsValid == false)
            {
                return base.BadRequest(request);
            }

            //Todo: implementar ProducesResponseType

            var response = await _userAppService.AddCreditAsync(code, request);

            return base.StatusCode((int)HttpStatusCode.OK, response);
        }

        [HttpPost("{code}/consumption")]
        public async Task<IActionResult> PostConsumptiont(string code, [FromBody] CreateConsumptionRequest request)
        {
            if (ModelState.IsValid == false)
            {
                return base.BadRequest(request);
            }

            var response = await _userAppService.AddConsumptionAsync(code, request);

            return base.StatusCode((int)HttpStatusCode.OK, response);
        }
        #endregion
    }
}