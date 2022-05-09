using BlogPessoal.src.DTOS;
using BlogPessoal.src.repositories;
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
        public IActionResult NewPost([FromBody] NewPostDTO post)
        {
            if(!ModelState.IsValid) return BadRequest();            
            _repository.NewPost(post);
            return Created($"api/Posts", post);
        }

        [HttpPut]
        public IActionResult UpdatePost([FromBody] UpdatePostDTO
        post)
        {
            if(!ModelState.IsValid) return BadRequest();
            _repository.UpdatePost(post);
            return Ok(post);
        }

        [HttpDelete("delete/{idPost}")]
        public IActionResult DeletePost([FromRoute] int idPost)
        {
            _repository.DeletePost(idPost);
            return NoContent();
        }

        [HttpGet("id/{idPost}")]
        public IActionResult GetPostById([FromRoute] int idPosts)
        {
            var posts = _repository.GetPostById(idPosts);
            if (posts == null) return NotFound();
            return Ok(posts);
        }

        [HttpGet]
        public IActionResult GetAllPosts()
        {
            var list = _repository.GetAllPosts();
            if (list.Count < 1) return NoContent();
            return Ok(list);
        }

        [HttpGet("search")]
        public IActionResult GetPostBySearch(
        [FromQuery] string title,
        [FromQuery] string description,
        [FromQuery] string creator)
        {
            var posts = _repository.GetPostBySearch(title,
            description, creator);
            if (posts.Count < 1) return NoContent();
            return Ok(posts);
        }

        #endregion Methods
    }
}