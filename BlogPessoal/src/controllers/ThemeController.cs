using BlogPessoal.src.DTOS;
using BlogPessoal.src.repositorios;
using Microsoft.AspNetCore.Mvc;

namespace BlogPessoal.src.controladores
{

[ApiController]
[Route("api/Theme")]    
[Produces("application/json")]
    public class TemaControlador : ControllerBase
    {
        #region Attributes
        private readonly ITheme _repository;

        #endregion Attributes

        #region Constructors
        public TemaControlador(ITheme repository)
        {
        _repository = repository;
        }

        #endregion Constructors

        #region Métodos

        [HttpGet]
        public IActionResult GetAllThemes()
        {
            var lista = _repositorio.PegarTodosTemas();
            if (lista.Count < 1) return NoContent();
            return Ok(lista);
        }

        #endregion
        }
    }