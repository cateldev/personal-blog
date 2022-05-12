using System.Threading.Tasks;
using BlogPessoal.src.DTOS;
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

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> NewPostAsync([FromBody] NewPostDTO post)
        {
            if(!ModelState.IsValid) return BadRequest();            
            await _repository.NewPostAsync(post);
            return Created($"api/Posts", post);
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult> UpdatePostAsync([FromBody] UpdatePostDTO post)
        {
            if(!ModelState.IsValid) return BadRequest();
            await _repository.UpdatePostAsync(post);
            return Ok(post);
        }

        [HttpDelete("delete/{idPost}")]
        [Authorize]
        public async Task<ActionResult> DeletePost([FromRoute] int idPost)
        {
            await _repository.DeletePostAsync(idPost);
            return NoContent();
        }

        [HttpGet("id/{idPost}")]
        [Authorize]
        public async Task<ActionResult> GetPostByIdAsync([FromRoute] int idPosts)
        {
            var posts = await _repository.GetPostByIdAsync(idPosts);
            if (posts == null) return NotFound();
            return Ok(posts);
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult> GetAllPostsAsync()
        {
            var list = await _repository.GetAllPostsAsync();
            if (list.Count < 1) return NoContent();
            return Ok(list);
        }

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