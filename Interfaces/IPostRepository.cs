namespace BlogApi.Interfaces;

public interface IPostRepository
{
    Task<IEnumerable<PostDto>> GetAllAsync();
    Task<PostDto> GetByIdAsync(int id);
    Task<PostDto> AddAsync(PostDtoCreate entity);
    Task<PostDto> UpdateAsync(int postId, PostDtoUpdate entity);
    Task<bool> DeleteAsync(int id);
}