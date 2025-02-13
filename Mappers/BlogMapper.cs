namespace BlogApi.Mappers;

public class BlogMapper : Profile
{
    public BlogMapper()
    {
        CreateMap<Post, PostDto>().ReverseMap();
        CreateMap<Post, PostDtoCreate>().ReverseMap();
        CreateMap<Post, PostDtoUpdate>().ReverseMap();
    }
}
