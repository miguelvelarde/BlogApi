namespace BlogApi.Interfaces;

public interface IUserRepository
{
    Task<IEnumerable<UserDto>> GetAllAsync();
    Task<UserDto> GetByIdAsync(int id);
    Task<UserDto> AddAsync(UserCreateDto user);
    Task<UserDto> UpdateAsync(int userId, UserUpdateDto user);
    Task<bool> DeleteAsync(int id);
    Task<UserLoginResponseDto> Login(UserLoginDto userDto);
}