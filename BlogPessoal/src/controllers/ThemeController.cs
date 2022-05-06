using BlogPessoal.src.DTOS;
using BlogPessoal.src.repositories;
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
            var list = _repository.GetAllThemes();

            if (list.Count  < 1) return NoContent();

            return Ok(list);
        }

        [HttpGet("id/{idTheme}")]
        public IActionResult GetThemeById([FromRoute] int idTheme)
        {

        var theme = _repository.GetThemeById(idTheme);

        if (theme == null) return NotFound();

        return Ok(theme);

        }

        #endregion

        }
    }