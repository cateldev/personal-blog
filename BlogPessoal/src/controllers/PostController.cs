using System.Threading.Tasks;
using BlogPessoal.src.dtos;
using BlogPessoal.src.repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlogPessoal.src.controladores
{
    [ApiController]
    [Route("api/Posts")]
    [Produces("application/json")]
    public class PostsController : ControllerBase
    {

        #region Attributes
        private readonly IPost _repository;
        #endregion Attributes

        #region Constructors
        public PostsController(IPost repository)
        {
        _repository = repository;
        
        }
        #endregion Constructors

        #region Methods

        /// <summary>
        /// Create a new post
        /// </summary>
        /// <param name="post">PostRegisterDTO</param>
        /// <returns>IActionResult</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /api/Post
        ///     {
        ///        "title": "C# in 2022",
        ///        "description": "C# in 2022 is the future of programming",
        ///        "photo": "URLPHOTO",
        ///        "descriptionTheme": "C#",
        ///        "emailCreator": "catel@domain.com"
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Returns the newly created post</response>
        /// <response code="400">Error in request</response>

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> NewPostAsync([FromBody] NewPostDTO post)
        {
            if(!ModelState.IsValid) return BadRequest();            
            await _repository.NewPostAsync(post);
            return Created($"api/Posts", post);
        }

        /// <summary>
        /// Update post
        /// </summary>
        /// <param name="post">PostRegisterDTO</param>
        /// <returns>IActionResult</returns>
        /// <remarks>
        /// Sample request:
        ///
        ///     PUT /api/Post
        ///     {
        ///        "title": "C# in 2022",
        ///        "description": "C# in 2022 is the future of programming",
        ///        "descriptionTheme": "C#",
        ///        "emailUser": "gustavo@email.com"
        ///     }
        ///
        /// </remarks>
        /// <response code="200">Returns the updated post</response>
        /// <response code="400">Error in request</response>

        [HttpPut]
        [Authorize]
        public async Task<ActionResult> UpdatePostAsync([FromBody] UpdatePostDTO post)
        {
            if(!ModelState.IsValid) return BadRequest();
            await _repository.UpdatePostAsync(post);
            return Ok(post);
        }

        /// <summary>
        /// Delete post by id
        /// </summary>
        /// <param name="idPost">int</param>
        /// <returns>IActionResult</returns>
        /// <response code="200">Post deleted</response>
        /// <response code="404">Post not found</response>

        [HttpDelete("delete/{idPost}")]
        [Authorize]
        public async Task<ActionResult> DeletePost([FromRoute] int idPost)
        {
            await _repository.DeletePostAsync(idPost);
            return NoContent();
        }

        /// <summary>
        /// Get post by id
        /// </summary>
        /// <param name="idPosts">int</param>
        /// <returns>IActionResult</returns>
        /// <response code="200">Returns the post</response>
        /// <response code="404">Post not found</response>

        [HttpGet("id/{idPost}")]
        [Authorize]
        public async Task<ActionResult> GetPostByIdAsync([FromRoute] int idPosts)
        {
            var posts = await _repository.GetPostByIdAsync(idPosts);
            if (posts == null) return NotFound();
            return Ok(posts);
        }

        /// <summary>
        /// Get all posts
        /// </summary>
        /// <returns>IActionResult</returns>
        /// <response code="200">Returns all posts</response>
        /// <response code="204">No content</response>

        [HttpGet]
        [Authorize]
        public async Task<ActionResult> GetAllPostsAsync()
        {
            var list = await _repository.GetAllPostsAsync();
            if (list.Count < 1) return NoContent();
            return Ok(list);
        }

        /// <summary>
        /// Get posts by title or description theme or name creator
        /// </summary>
        /// <param name="title">string</param>
        /// <param name="description">string</param>
        /// <param name="creator">string</param>
        /// <returns>IActionResult</returns>
        /// <response code="200">Returns the posts</response>
        /// <response code="204">No content</response>

        [HttpGet("search")]
        [Authorize]
        public async Task<ActionResult> GetPostBySearchAsync(
        [FromQuery] string title,
        [FromQuery] string description,
        [FromQuery] string creator)
        {
            var posts = await _repository.GetPostBySearchAsync(title, description, creator);
            if (posts.Count < 1) return NoContent();
            return Ok(posts);
        }

        #endregion Methods
    }
}