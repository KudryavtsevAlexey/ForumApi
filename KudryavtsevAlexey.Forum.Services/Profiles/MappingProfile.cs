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

            CreateMap<Organization, OrganizationDto>()
                .ReverseMap();

            CreateMap<User, UserDto>()
                .ReverseMap();

            CreateMap<ArticleMainComment, ArticleMainCommentDto>()
                .ReverseMap();

            CreateMap<Tag, TagDto>()
                .ReverseMap();

            CreateMap<ArticleSubComment, ArticleSubCommentDto>()
                .ReverseMap();
        }
    }
}
