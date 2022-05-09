using BlogPessoal.src.repositories;
using BlogPessoal.src.DTOS;
using Microsoft.AspNetCore.Mvc;

namespace BlogPessoal.src.controllers
{
    [ApiController]
    [Route("api/Users")]
    [Produces("UserController/json")]
    public class UserController : ControllerBase
    {
        #region Attributes
        private readonly IUser _repository;
        #endregion Attributes

        #region Constructors
        public UserController(IUser repository)
        {
            _repository = repository;
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
        public IActionResult NewUser([FromBody] NewUserDTO user)
        {
            if (!ModelState.IsValid) return BadRequest();

            _repository.NewUser(user);
            return Created($"api/user/{user.Email}", user);
        }

        [HttpPut]
        public IActionResult UpdateUser([FromBody] UpdateUserDTO user)
        {
            if (!ModelState.IsValid) return BadRequest();
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