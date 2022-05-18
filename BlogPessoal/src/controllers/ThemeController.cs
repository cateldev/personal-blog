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

        /// <summary>
        /// Create a new theme
        /// </summary>
        /// <param name="theme">NewThemeDTO</param>
        /// <returns>IActionResult</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/Theme
        ///     {
        ///        "description": "C#"
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Returns the newly created theme</response>
        /// <response code="400">Error in request</response>

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> NewThemeAsync([FromBody] NewThemeDTO theme)
        {
            if(!ModelState.IsValid) return BadRequest();

            await _repository.NewThemeAsync(theme);

            return Created($"api/Themes", theme);
        }

        /// <summary>
        /// Update theme by id
        /// </summary>
        /// <param name="theme">UpdateThemeDTO</param>
        /// <returns>IActionResult</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /api/Theme
        ///     {
        ///        "description": "Python"
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Theme updated</response>
        /// <response code="400">Error in request</response>
        /// <response code="404">Theme not found</response>

        [HttpPut]
        [Authorize(Roles = "ADMINISTRATOR")]
        public async Task<ActionResult> UpdateTheme([FromBody] UpdateThemeDTO theme)
        {
            if(!ModelState.IsValid) return BadRequest();
            await _repository.UpdateThemeAsync(theme);
            return Ok(theme);
        }

        /// <summary>
        /// Delete theme by id
        /// </summary>
        /// <param name="idTheme">int</param>
        /// <returns>IActionResult</returns>
        /// <response code="200">Theme deleted</response>
        /// <response code="404">Theme not found</response>

        [HttpDelete("delete/{idTheme}")]
        [Authorize(Roles = "ADMINISTRATOR")]
        public async Task<ActionResult> DeleteTheme([FromRoute] int idTheme)
        {
            await _repository.DeleteThemeAsync(idTheme);
            return NoContent();
        }

        /// <summary>
        /// Get all themes
        /// </summary>
        /// <returns>IActionResult</returns>
        /// <response code="200">Returns all themes</response>
        /// <response code="204">No content</response>

        [HttpGet]
        [Authorize]
        public async Task<ActionResult> GetAllThemesAsync()
        {
            var list = await _repository.GetAllThemesAsync();
            if (list.Count  < 1) return NoContent();
            return Ok(list);
        }

        /// <summary>
        /// Get theme by id
        /// </summary>
        /// <param name="idTheme">int</param>
        /// <returns>IActionResult</returns>
        /// <response code="200">Returns the theme</response>
        /// <response code="404">Theme not found</response>

        [HttpGet("id/{idTheme}")]
        [Authorize]
        public async Task<ActionResult> GetThemeByIdAsync([FromRoute] int idTheme)
        {

            var theme = await _repository.GetThemeByIdAsync(idTheme);
            if (theme == null) return NotFound();
            return Ok(theme);

        }

        /// <summary>
        /// Get themes by description
        /// </summary>
        /// <param name="descriptionTheme">string</param>
        /// <returns>IActionResult</returns>
        /// <response code="200">Returns the theme</response>
        /// <response code="204">Theme no content</response>

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