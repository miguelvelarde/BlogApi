using BlogApi.Configuration;
using BlogApi.Models;
using Microsoft.Extensions.Options;

namespace BlogApi.Services;

public class UserRepositoryService : IUserRepository
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly string _jwtSecret;

    private readonly List<User> _users;

    public UserRepositoryService(ApplicationDbContext context, IMapper mapper, IOptions<SecretsManager> configuration)
    {
        _context = context;
        _mapper = mapper;
        _jwtSecret = configuration.Value.SecretKey;

        _users =
        [
            new User { Id = 1, UserName = "admin", NickName = "Admin", Password = "admin" },
            new User { Id = 2, UserName = "user", NickName = "User", Password = "user" }
        ];
    }

    public async Task<IEnumerable<UserDto>> GetAllAsync()
    {
        //var users = await _context.Users.FromSqlRaw("EXEC [dbo].[UsersGetAll]").ToListAsync();
        //return _mapper.Map<IEnumerable<UserDto>>(users);

        await Task.Delay(2000);
        return _mapper.Map<IEnumerable<UserDto>>(_users);
    }

    public async Task<UserDto> GetByIdAsync(int id)
    {
        // var result = await _context.Users.FromSqlRaw("EXEC [dbo].[UsersGetById] @p0", id).ToListAsync();
        // var user = result.FirstOrDefault();
        // return _mapper.Map<UserDto>(user);
        await Task.Delay(2000);
        var user = _users.FirstOrDefault(u => u.Id == id);
        return _mapper.Map<UserDto>(user);
    }

    public async Task<UserDto> AddAsync(UserCreateDto userDto)
    {
        try
        {
            // userDto.Password = TokenService.EncryptToMD5(userDto.Password);

            // var result = await _context.Users.FromSqlRaw(
            //     "EXEC [dbo].[UsersAddNew] @p0, @p1, @p2",
            //     userDto.UserName, userDto.NickName, userDto.Password).ToListAsync();

            // var insertedUser = result.FirstOrDefault();
            // return result != null ? _mapper.Map<UserDto>(insertedUser) : null;
            await Task.Delay(2000);
            userDto.Password = TokenService.EncryptToMD5(userDto.Password);
            var user = _mapper.Map<User>(userDto);
            _users.Add(user);
            
            return _mapper.Map<UserDto>(user);
        }
        catch
        {
            return null;
        }
    }

    public async Task<UserDto> UpdateAsync(int userId, UserUpdateDto userDto)
    {
        try
        {
            // var user = _mapper.Map<User>(userDto);
            // user.Id = userId;
            // var result = await _context.Users.FromSqlRaw(
            //     "EXEC [dbo].[UsersUpdate] @p0, @p1, @p2, @p3",
            //     user.Id, user.UserName, user.NickName, TokenService.EncryptToMD5(user.Password)).ToListAsync();

            // var updatedUser = result.FirstOrDefault();
            // return _mapper.Map<UserDto>(updatedUser);
            await Task.Delay(2000);

            var userToUpdate = _users.FirstOrDefault(u => u.Id == userId);
            if (userToUpdate == null)
            {
                return null;
            }

            userToUpdate.UserName = userDto.UserName;
            userToUpdate.NickName = userDto.NickName;
            userToUpdate.Password = userDto.Password;
            
            return _mapper.Map<UserDto>(userToUpdate);

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
            // var result = await _context.Database.ExecuteSqlRawAsync("EXEC [dbo].[UsersDelete] @p0", id);
            // return result > 0;
            await Task.Delay(2000);
            var user = _users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return false;
            }

            _users.Remove(user);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task<UserLoginResponseDto> Login(UserLoginDto userDto)
    {
        // var result = await _context.Users.FromSqlRaw("EXEC [dbo].[UsersLogin] @p0, @p1",
        //     userDto.NickName, TokenService.EncryptToMD5(userDto.Password)).ToListAsync();

        // var user = result.FirstOrDefault();

        // if (user == null)
        // {
        //     return null;
        // }

        // var userLoginResponseDto = _mapper.Map<UserLoginResponseDto>(user);

        // userLoginResponseDto.Token = TokenService.GenerateJwtToken(user, _jwtSecret);

        // return userLoginResponseDto;

        await Task.Delay(2000);
        var user = _users.FirstOrDefault(u => u.UserName == userDto.NickName && u.Password == userDto.Password);
        
        if (user == null)
        {
            return null;
        }

        var userLoginResponseDto = _mapper.Map<UserLoginResponseDto>(user);

        userLoginResponseDto.Token = TokenService.GenerateJwtToken(user, _jwtSecret);

        return userLoginResponseDto;
    }


}
