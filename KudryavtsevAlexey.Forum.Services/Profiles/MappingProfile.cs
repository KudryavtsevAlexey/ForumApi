using System.Linq;
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
                .MaxDepth(1);

            CreateMap<ArticleDto, Article>();

            CreateMap<Article, PutArticleDto>();

            CreateMap<PutArticleDto, Article>();

            CreateMap<Organization, OrganizationDto>()
                .MaxDepth(1);

            CreateMap<OrganizationDto, Organization>();

            CreateMap<User, UserDto>()
                .MaxDepth(1);

            CreateMap<UserDto, User>();

            CreateMap<ArticleMainComment, ArticleMainCommentDto>()
                .MaxDepth(1);

            CreateMap<ArticleMainCommentDto, ArticleMainComment>();

            CreateMap<ArticleSubComment, ArticleSubCommentDto>()
                .MaxDepth(1);

            CreateMap<ArticleSubCommentDto, ArticleSubComment>();

            CreateMap<Tag, TagDto>()
                .MaxDepth(1);

            CreateMap<TagDto, Tag>();
        }
    }
}
