namespace BlogApi.Services;

public class PostRepositoryService : IPostRepository
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public PostRepositoryService(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<PostDto>> GetAllAsync()
    {
        var posts = await _context.Posts.FromSqlRaw("EXEC [dbo].[PostsGetAll]").ToListAsync();
        return _mapper.Map<IEnumerable<PostDto>>(posts);
    }

    public async Task<PostDto> GetByIdAsync(int id)
    {
        var result = await _context.Posts.FromSqlRaw("EXEC [dbo].[PostsGetById] @p0", id).ToListAsync();
        var post = result.FirstOrDefault();
        return _mapper.Map<PostDto>(post);
    }

    public async Task<PostDto> AddAsync(PostDtoCreate postDto)
    {
        try
        {
            var post = _mapper.Map<Post>(postDto);
            var result = await _context.Posts.FromSqlRaw(
                "EXEC [dbo].[PostsAddNew] @p0, @p1, @p2, @p3",
                post.Title, post.Content, post.ImagePath, post.Tags).ToListAsync();

            var insertedPost = result.FirstOrDefault();
            return _mapper.Map<PostDto>(insertedPost);
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
            var result = await _context.Posts.FromSqlRaw(
                "EXEC [dbo].[PostsUpdate] @p0, @p1, @p2, @p3, @p4, @p5",
                postId, postDto.Title, postDto.Content, postDto.ImagePath, postDto.Tags, postDto.CreatedAt).ToListAsync();

            var updatedPost = result.FirstOrDefault();
            return _mapper.Map<PostDto>(updatedPost);
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
            var result = await _context.Database.ExecuteSqlRawAsync("EXEC [dbo].[PostsDelete] @p0", id);
            return result > 0;
        }
        catch
        {
            return false;
        }

    }
}


//using BlogApi.Models;

//namespace BlogApi.Services
//{
//    public class BookRepositoryService : IBookRepository
//    {
//        private readonly ApplicationDbContext _context;

//        public BookRepositoryService(ApplicationDbContext context)
//        {
//            _context = context;
//        }

//        public async Task<IEnumerable<Post>> GetAllAsync()
//        {
//            return await _context.Posts.FromSqlRaw("EXEC [dbo].[PostsGetAll]").ToListAsync();
//        }

//        public async Task<Post> GetByIdAsync(int id)
//        {
//            var result = await _context.Posts.FromSqlRaw("EXEC [dbo].[PostsGetById] @p0", id).ToListAsync();
//            return result.FirstOrDefault();
//        }

//        public async Task<IEnumerable<Post>> FindAsync(Expression<Func<Post, bool>> predicate)
//        {
//            return await _context.Posts.Where(predicate).ToListAsync();
//        }

//        public async Task<bool> AddAsync(Post post)
//        {
//            try
//            {
//                var result = await _context.Database.ExecuteSqlRawAsync(
//                    "EXEC [dbo].[PostsAddNew] @p0, @p1, @p2, @p3, @p4",
//                    post.Title, post.Content, post.ImagePath, post.Tags, post.CreatedAt);

//                return result > 0;
//            }
//            catch
//            {
//                return false;
//            }
//        }

//        public async Task<bool> UpdateAsync(Post post)
//        {
//            try
//            {
//                var result = await _context.Database.ExecuteSqlRawAsync(
//                    "EXEC [dbo].[PostsUpdate] @p0, @p1, @p2, @p3, @p4, @p5",
//                    post.Id, post.Title, post.Content, post.ImagePath, post.Tags, post.CreatedAt);

//                return result > 0;
//            }
//            catch
//            {
//                return false;
//            }
//        }

//        public async Task<bool> DeleteAsync(int id)
//        {
//            try
//            {
//                var result = await _context.Database.ExecuteSqlRawAsync("EXEC [dbo].[PostsDelete] @p0", id);
//                return result > 0;
//            }
//            catch
//            {
//                return false;
//            }

//        }
//    }
//}