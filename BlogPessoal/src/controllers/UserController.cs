using BlogPessoal.src.repositories;
using BlogPessoal.src.DTOS;
using Microsoft.AspNetCore.Mvc;
using BlogPessoal.src.services;
using Microsoft.AspNetCore.Authorization;
using System;

namespace BlogPessoal.src.controllers
{
    [ApiController]
    [Route("api/Users")]
    [Produces("UserController/json")]
    public class UserController : ControllerBase
    {
        #region Attributes
        private readonly IAutentication _services;
        private readonly IUser _repository;
        #endregion Attributes

        #region Constructors
        public UserController(IUser repository, IAutentication services)
        {
            _repository = repository;
            _services = services;
        }
        #endregion Constructors

        #region Methods
        [HttpGet("id/{idUser}")]
        public IActionResult GetUserById([FromRoute] int idUser)
        {
           var user = _repository.GetUserById(idUser);
           if (user == null) return NotFound();
           return Ok(user);
        }    

        [HttpGet] 
        public IActionResult GetUserByName([FromQuery] string userName)
        {
            var users = _repository.GetUserByName(userName);
            if (users.Count < 1) return NoContent();
            return Ok(users);
        }

        [HttpGet("email/{emailUser}")]
        public IActionResult GetUserByEmail([FromRoute] string emailUser)
        {
           var user = _repository.GetUserByEmail(emailUser);
           if (user == null) return NotFound();
           return Ok(user);
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult NewUser([FromBody] NewUserDTO user)
        {
            if(!ModelState.IsValid) return BadRequest();
            try
            {
                _services.CreateUserNoDuplicate(user);
                return Created($"api/Usuarios/email/{user.Email}", user);
            }
            catch (Exception ex)
            {
                return Unauthorized(ex.Message);
            }
        }

        [HttpPut]
        [Authorize(Roles = "NORMAL,ADMINISTRATOR")]
        public IActionResult UpdateUser([FromBody] UpdateUserDTO user)
        {
            if (!ModelState.IsValid) return BadRequest();
            user.Password = _services.CodifyPassword(user.Password);
            _repository.UpdateUser(user);
            return Ok(user);
        }
        
        [HttpDelete("delete/{idUser}")]
        public IActionResult DeleteUser([FromRoute] int idUser)
        {
            _repository.DeleteUser(idUser);
            return NoContent();
        }
        #endregion Methods
    }
}