namespace BlogApi.Mappers;

public class BlogMapper : Profile
{
    public BlogMapper()
    {
        CreateMap<Post, PostDto>().ReverseMap();
        CreateMap<Post, PostDtoCreate>().ReverseMap();
        CreateMap<Post, PostDtoUpdate>().ReverseMap();

        CreateMap<User, UserDto>().ReverseMap();
        CreateMap<User, UserCreateDto>().ReverseMap();
        CreateMap<User, UserUpdateDto>().ReverseMap();

        CreateMap<User, UserLoginResponseDto>()
            .ForMember(dest => dest.User, opt => opt.MapFrom(src => src)) // Mapea todo el objeto User
            .ForMember(dest => dest.Token, opt => opt.Ignore()); // Ignora el Token (se asigna manualmente)
    }
}

