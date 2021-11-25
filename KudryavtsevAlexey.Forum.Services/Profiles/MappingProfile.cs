using AutoMapper;
using KudryavtsevAlexey.Forum.Domain.Entities;
using KudryavtsevAlexey.Forum.Domain.Entities.Comments;
using KudryavtsevAlexey.Forum.Services.Dtos;

namespace KudryavtsevAlexey.Forum.Services.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Article, ArticleDto>()
                .ReverseMap();

            CreateMap<Article, PutArticleDto>()
                .ReverseMap();

            CreateMap<OrganizationDto, Organization>()
                .ReverseMap();

            CreateMap<UserDto, User>()
                .ReverseMap();

            CreateMap<ArticleMainCommentDto, ArticleMainComment>()
                .ReverseMap();

            CreateMap<TagDto, Tag>()
                .ReverseMap();
        }
    }
}
