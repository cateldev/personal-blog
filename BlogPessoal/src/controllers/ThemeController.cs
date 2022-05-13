using System.Threading.Tasks;
using BlogPessoal.src.dtos;
using BlogPessoal.src.repositories;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        public async Task<ActionResult> NewThemeAsync([FromBody] NewThemeDTO theme)
        {
            if(!ModelState.IsValid) return BadRequest();

            await _repository.NewThemeAsync(theme);

            return Created($"api/Themes", theme);
        }

        [HttpPut]
        [Authorize(Roles = "ADMINISTRATOR")]
        public async Task<ActionResult> UpdateTheme([FromBody] UpdateThemeDTO theme)
        {
            if(!ModelState.IsValid) return BadRequest();
            await _repository.UpdateThemeAsync(theme);
            return Ok(theme);
        }

        [HttpDelete("delete/{idTheme}")]
        [Authorize(Roles = "ADMINISTRATOR")]
        public async Task<ActionResult> DeleteTheme([FromRoute] int idTheme)
        {
            await _repository.DeleteThemeAsync(idTheme);
            return NoContent();
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult> GetAllThemesAsync()
        {
            var list = await _repository.GetAllThemesAsync();
            if (list.Count  < 1) return NoContent();
            return Ok(list);
        }

        [HttpGet("id/{idTheme}")]
        [Authorize]
        public async Task<ActionResult> GetThemeByIdAsync([FromRoute] int idTheme)
        {

            var theme = await _repository.GetThemeByIdAsync(idTheme);
            if (theme == null) return NotFound();
            return Ok(theme);

        }

        [HttpGet("search")]
        [Authorize]
        public async Task<ActionResult> GetThemeByDescriptionAsync([FromQuery] string descriptionTheme)
        {
            var themes = await _repository.GetThemeByDescriptionAsync(descriptionTheme);
             if (themes.Count < 1) return NoContent();
            return Ok(themes);
        }
        #endregion
        }
    }