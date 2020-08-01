using Application.Models.Exceptions;
using Application.Models.Tap;
using Domain.TapAggregate.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TapsController : ControllerBase
    {
        #region Properties
        private readonly ITapAppService _tapAppService;
        #endregion

        #region Constructors
        public TapsController(ITapAppService tapAppService)
        {
            this._tapAppService = tapAppService;
        }
        #endregion

        #region Methods
        [ProducesResponseType(typeof(GetTapResponse), 200)]
        [ProducesResponseType(typeof(NotFoundResponseModel), 404)]
        [ProducesResponseType(typeof(PreconditionFailedResponseModel), 412)]
        [HttpGet("{code}", Name = "GetTap")]
        public async Task<IActionResult> Get(string code)
        {
            var response = await _tapAppService.GetByCodeAsync(code);
            return base.StatusCode((int)HttpStatusCode.OK, response);
        }

        [HttpPost]
        [ProducesResponseType(typeof(GetTapResponse), 201)]
        public async Task<IActionResult> Post([FromBody] CreateTapRequest request)
        {
            if (ModelState.IsValid == false)
            {
                return base.BadRequest(request);
            }

            var response = await _tapAppService.AddAsync(request);

            return base.StatusCode((int)HttpStatusCode.Created, response);
        }

        [HttpPut("{code}")]
        [ProducesResponseType(typeof(NotFoundResponseModel), 404)]
        [ProducesResponseType(typeof(PreconditionFailedResponseModel), 412)]
        public async Task<IActionResult> Put(string code, [FromBody] UpdateTapRequest request)
        {
            if (ModelState.IsValid == false)
            {
                return base.BadRequest(request);
            }

            await _tapAppService.UpdateAsync(code, request);

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

            await _tapAppService.LogicDeleteAsync(code);

            return base.StatusCode((int)HttpStatusCode.OK);
        }
        #endregion
    }
}