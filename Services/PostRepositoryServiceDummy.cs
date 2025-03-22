namespace BlogApi.Services;

public class PostRepositoryServiceDummy : IPostRepository
{
    private readonly IMapper _mapper;
    private readonly List<Post> _dummyPosts;

    public PostRepositoryServiceDummy(IMapper mapper)
    {
        _mapper = mapper;

        _dummyPosts = new List<Post>
        {
            new Post { Id = 1, Title = "Primer Post", Content = "Contenido del primer post", ImagePath = "/images/post1.jpg", Tags = "dummy,ejemplo", CreatedAt = DateTime.Now.AddDays(-5) },
            new Post { Id = 2, Title = "Segundo Post", Content = "Contenido del segundo post", ImagePath = "/images/post2.jpg", Tags = "dummy,test", CreatedAt = DateTime.Now.AddDays(-3) },
            new Post { Id = 3, Title = "Tercer Post", Content = "Contenido del tercer post", ImagePath = "/images/post3.jpg", Tags = "ejemplo,test", CreatedAt = DateTime.Now.AddDays(-1) }
        };
    }

    public async Task<IEnumerable<PostDto>> GetAllAsync()
    {
        await Task.Delay(100);
        return _mapper.Map<IEnumerable<PostDto>>(_dummyPosts);
    }

    public async Task<PostDto> GetByIdAsync(int id)
    {
        await Task.Delay(50);
        var post = _dummyPosts.FirstOrDefault(p => p.Id == id);
        return _mapper.Map<PostDto>(post);
    }

    public async Task<PostDto> AddAsync(PostDtoCreate postDto)
    {
        try
        {
            await Task.Delay(150);
            
            var post = _mapper.Map<Post>(postDto);
            post.Id = _dummyPosts.Max(p => p.Id) + 1;
            post.CreatedAt = DateTime.Now;
            
            _dummyPosts.Add(post);
            
            return _mapper.Map<PostDto>(post);
        }
        catch
        {
            return null;
        }
    }

    public async Task<PostDto> UpdateAsync(int postId, PostDtoUpdate postDto)
    {
        try
        {
            await Task.Delay(100);
            
            var existingPost = _dummyPosts.FirstOrDefault(p => p.Id == postId);
            if (existingPost == null)
            {
                return null;
            }
            
            existingPost.Title = postDto.Title;
            existingPost.Content = postDto.Content;
            existingPost.ImagePath = postDto.ImagePath;
            existingPost.Tags = postDto.Tags;
            existingPost.CreatedAt = postDto.CreatedAt;
            
            return _mapper.Map<PostDto>(existingPost);
        }
        catch
        {
            return null;
        }
    }

    public async Task<bool> DeleteAsync(int id)
    {
        try
        {
            await Task.Delay(75);
            
            var post = _dummyPosts.FirstOrDefault(p => p.Id == id);
            if (post == null)
            {
                return false;
            }
            
            _dummyPosts.Remove(post);
            return true;
        }
        catch
        {
            return false;
        }
    }
}