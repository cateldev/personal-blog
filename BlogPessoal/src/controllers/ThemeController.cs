using BlogPessoal.src.DTOS;
using BlogPessoal.src.repositories;
using Microsoft.AspNetCore.Mvc;

namespace BlogPessoal.src.controladores
{

    [ApiController]
    [Route("api/Theme")]    
    [Produces("application/json")]
    public class ThemeController : ControllerBase
    {
        #region Attributes
        private readonly ITheme _repository;
        #endregion Attributes

        #region Constructors
        public ThemeController(ITheme repository)
        {
        _repository = repository;
        }
        #endregion Constructors

        #region Métodos
        [HttpPost]
        public IActionResult NewTheme([FromBody] NewThemeDTO theme)
        {
            if(!ModelState.IsValid) return BadRequest();

            _repository.NewTheme(theme);

            return Created($"api/Themes", theme);
        }

        [HttpPut]
        public IActionResult UpdateTheme([FromBody] UpdateThemeDTO theme)
        {
            if(!ModelState.IsValid) return BadRequest();
            _repository.UpdateTheme(theme);
            return Ok(theme);
        }

        [HttpDelete("delete/{idTheme}")]
        public IActionResult DeleteTheme([FromRoute] int idTheme)
        {
             _repository.DeleteTheme(idTheme);
            return NoContent();
        }

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

        [HttpGet("search")]
        public IActionResult GetThemeByDescription([FromQuery] string descriptionTheme)
        {
            var themes = _repository.GetThemeByDescription(descriptionTheme);
             if (themes.Count < 1) return NoContent();
            return Ok(themes);
        }
        #endregion
        }
    }