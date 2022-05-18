using BlogPessoal.src.repositories;
using BlogPessoal.src.dtos;
using Microsoft.AspNetCore.Mvc;
using BlogPessoal.src.services;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Threading.Tasks;

namespace BlogPessoal.src.controllers
{
    [ApiController]
    [Route("api/Users")]
    [Produces("UserController/json")]
    public class UserController : ControllerBase
    {
        #region Attributes
        private readonly IAuthentication _services;
        private readonly IUser _repository;
        #endregion Attributes

        #region Constructors
        public UserController(IUser repository, IAuthentication services)
        {
            _repository = repository;
            _services = services;
        }
        #endregion Constructors

        #region Methods

        /// <summary>
        /// Get a user by id
        /// </summary>
        /// <param name="idUser">int</param>
        /// <returns>IActionResult</returns>
        /// <response code="200">Returns the user</response>
        /// <response code="404">User not found</response>

        [HttpGet("id/{idUser}")]
        [Authorize(Roles = "NORMAL,ADMINISTRATOR")]
        public async Task<ActionResult> GetUserByIdAsync([FromRoute] int idUser)
        {
           var user = await _repository.GetUserByIdAsync(idUser);
           if (user == null) return NotFound();
           return Ok(user);
        }    

        /// <summary>
        /// Get a users by name
        /// </summary>
        /// <param name="userName">string</param>
        /// <returns>IActionResult</returns>
        /// <response code="200">Returns the list users</response>
        /// <response code="204">Users not found</response>

        [HttpGet]
        [Authorize(Roles = "NORMAL,ADMINISTRATOR")]
        public async Task<ActionResult> GetUserByNameAsync([FromQuery] string userName)
        {
            var users = await _repository.GetUserByNameAsync(userName);
            if (users.Count < 1) return NoContent();
            return Ok(users);
        }

        /// <summary>
        /// Get a users by email
        /// </summary>
        /// <param name="emailUser">string</param>
        /// <returns>IActionResult</returns>
        /// <response code="200">Returns the list users</response>
        /// <response code="204">Users not found</response>

        [HttpGet("email/{emailUser}")]
        [Authorize(Roles = "NORMAL,ADMINISTRATOR")]
        public async Task<ActionResult> GetUserByEmailAsync([FromRoute] string emailUser)
        {
           var user = await _repository.GetUserByEmailAsync(emailUser);
           if (user == null) return NotFound();
           return Ok(user);
        }

        /// <summary>
        /// Create a new user
        /// </summary>
        /// <param name="user">NewUserDTO</param>
        /// <returns>IActionResult</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/User
        ///     {
        ///        "name": "Matheus Catel",
        ///        "email": "catel@domain.com",
        ///        "password": "12345",
        ///        "photo": "URLPHOTO",
        ///        "role": "ADMINISTRATOR"
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Returns the newly created user</response>
        /// <response code="400">Error in request</response>
        /// <response code="401">Exist user email in database</response>

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> NewUserAsync([FromBody] NewUserDTO user)
        {
            if(!ModelState.IsValid) return BadRequest();
            try
            {
                await _services.CreateUserNoDuplicateAsync(user);
                return Created($"api/Usuarios/email/{user.Email}", user);
            }

            catch (Exception ex)
            {
                return Unauthorized(ex.Message);
            }
        }

        /// <summary>
        /// Update a user
        /// </summary>
        /// <param name="user">UpdateUserDTO</param>
        /// <returns>IActionResult</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /api/User
        ///     {
        ///        "id": 1,    
        ///        "name": "Matheus Catel",
        ///        "password": "12345",
        ///        "photo": "URLPHOTO"
        ///        "role": "ADMINISTRATOR"
        ///     }
        ///
        /// </remarks>
        /// <response code="200">User updated</response>
        /// <response code="400">Error in request</response>
        /// <response code="404">User not found</response>

        [HttpPut]
        [Authorize(Roles = "NORMAL,ADMINISTRATOR")]
        public async Task<ActionResult> UpdateUserAsync([FromBody] UpdateUserDTO user)
        {
            if (!ModelState.IsValid) return BadRequest();
            user.Password = _services.EncodePassword(user.Password);
            await _repository.UpdateUserAsync(user);
            return Ok(user);
        }

        /// <summary>
        /// Delete a user by id
        /// </summary>
        /// <param name="idUser">int</param>
        /// <returns>IActionResult</returns>
        /// <response code="200">User deleted</response>
        /// <response code="404">User not found</response>
        
        [HttpDelete("delete/{idUser}")]
        [Authorize(Roles = "ADMINISTRATOR")]
        public async Task<ActionResult> DeleteUserAsync([FromRoute] int idUser)
        {
            await _repository.DeleteUserAsync(idUser);
            return NoContent();
        }
        #endregion Methods
    }
}