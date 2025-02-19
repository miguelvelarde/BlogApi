using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Controllers
{
    [Route("api/post")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public PostController(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetPostsAsync()
        {
            try
            {
                var posts = await _postRepository.GetAllAsync();
                var listPostDto = posts.Select(post => _mapper.Map<PostDto>(post));
                return Ok(listPostDto);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("{postId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetPostByIdAsync(int postId)
        {
            try
            {
                var post = await _postRepository.GetByIdAsync(postId);
                if (post == null)
                {
                    return NotFound();
                }

                var postDto = _mapper.Map<PostDto>(post);
                return Ok(postDto);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreatePostAsync([FromBody] PostDtoCreate postDto)
        {
            if (postDto == null)
            {
                return BadRequest();
            }

            try
            {
                var result = await _postRepository.AddAsync(postDto);
                if (result is null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Error creating the post.");
                }

                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPatch("{postId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdatePostAsync(int postId, [FromBody] PostDtoUpdate postDto)
        {
            if (postDto is null || postId < 1)
            {
                return BadRequest();
            }

            try
            {
                var result = await _postRepository.UpdateAsync(postId, postDto);
                if (result is null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Error updating the post.");
                }

                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete("{postId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeletePostAsync(int postId)
        {
            try
            {
                var result = await _postRepository.DeleteAsync(postId);
                if (!result)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "Error updating the post. Verify the post exists.");
                }
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}



