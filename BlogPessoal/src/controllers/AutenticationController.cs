using System;
using BlogPessoal.src.DTOS;
using BlogPessoal.src.services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogPessoal.src.controladores
{
    [ApiController]
    [Route("api/Autenticacao")]
    [Produces("application/json")]

    public class AutenticationController : ControllerBase
    {
        #region Attributes
        private readonly IAutentication _services;
        #endregion Attributes

        #region Constructors
        public AutenticationController(IAutentication services)
        {
            _services = services;
        }
        #endregion Constructors

        #region Methods
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Autenticate([FromBody] AutenticateDTO autentication)
        {
            if(!ModelState.IsValid) return BadRequest();
            try
            {
                var autorization = _services.GetAutorization(autentication);
                return Ok(autorization);
            }
            catch (Exception ex)
            {
                return Unauthorized(ex.Message);
            }
        }
        #endregion
    }
}