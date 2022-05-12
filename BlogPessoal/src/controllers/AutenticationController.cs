using System;
using BlogPessoal.src.DTOS;
using BlogPessoal.src.services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogPessoal.src.controllers
{
    [ApiController]
    [Route("api/Authentication")]
    [Produces("application/json")]

    public class AuthenticationController : ControllerBase
    {
        #region Attributes
        private readonly IAuthentication _services;
        #endregion Attributes

        #region Constructors
        public AuthenticationController(IAuthentication services)
        {
            _services = services;
        }
        #endregion Constructors

        #region Methods
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Authenticate([FromBody] AuthenticateDTO authentication)
        {
            if(!ModelState.IsValid) return BadRequest();

            try
            {
                var authorization = _services.GetAuthorization(authentication);
                return Ok(authorization);
            }

            catch (Exception ex)
            {
                return Unauthorized(ex.Message);
            }
        }
        #endregion
    }
}