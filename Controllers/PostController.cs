using BlogApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Controllers
{
    [Route("api/posts")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IRepository<Post> _postRepository;
        private readonly IMapper _mapper;

        public PostController(IRepository<Post> postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetPosts()
        {
            try
            {
                //var posts = await _postRepository.GetAllAsync();

                //var listPostDto = new List<PostDto>();

                //foreach (var post in posts)
                //{
                //    listPostDto.Add(_mapper.Map<PostDto>(post));
                //}

                //return Ok(listPostDto);

                var posts = await _postRepository.GetAllAsync();
                var listPostDto = posts.Select(post => _mapper.Map<PostDto>(post));
                return Ok(listPostDto);

            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
