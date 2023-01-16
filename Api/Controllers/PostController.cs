using Application.Posts.Commands;
using Application.Posts.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PostController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePost createpost)
        {
            var createdPost = await _mediator.Send(createpost);
            return CreatedAtRoute("GetById", new { createdPost.Id }, createdPost);    
        }

        [HttpGet("{id:int}", Name = "GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var post = await _mediator.Send(new GetPostById { PostId = id } );
            return Ok(post);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var posts = await _mediator.Send(new GetAllPosts());
            return Ok(posts);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromBody] UpdatePost updatePost)
        {
            var result = await _mediator.Send(updatePost);
            return Ok(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromBody] DeletePost deletePost)
        {
            var result = await _mediator.Send(deletePost);
            return NoContent();
        }
    }
}
