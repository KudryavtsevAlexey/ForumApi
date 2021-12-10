using AutoMapper;
using KudryavtsevAlexey.Forum.Domain.Entities;
using KudryavtsevAlexey.Forum.Domain.Entities.Comments;
using KudryavtsevAlexey.Forum.Services.Dtos;
using KudryavtsevAlexey.Forum.Services.Dtos.Article;
using KudryavtsevAlexey.Forum.Services.Dtos.Comment;
using KudryavtsevAlexey.Forum.Services.Dtos.Listing;
using KudryavtsevAlexey.Forum.Services.Dtos.Organization;
using KudryavtsevAlexey.Forum.Services.Dtos.Tag;
using KudryavtsevAlexey.Forum.Services.Dtos.User;

namespace KudryavtsevAlexey.Forum.Services.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Article, ArticleDto>()
                .MaxDepth(1);

            CreateMap<ArticleDto, Article>();

            CreateMap<ArticleMainComment, ArticleMainCommentDto>()
                .MaxDepth(1);

            CreateMap<ArticleMainCommentDto, ArticleMainComment>();

            CreateMap<ArticleSubComment, ArticleSubCommentDto>()
                .MaxDepth(1);

            CreateMap<ArticleSubCommentDto, ArticleSubComment>();

            CreateMap<Tag, TagDto>()
                .MaxDepth(1);

            CreateMap<TagDto, Tag>();

            CreateMap<Article, UpdateArticleDto>()
                .MaxDepth(1);

            CreateMap<UpdateArticleDto, Article>();

            CreateMap<Listing, ListingDto>()
                .MaxDepth(1);

            CreateMap<ListingDto, Listing>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.Title, opt => opt.MapFrom(x => x.Title))
                .ForMember(x => x.ShortDescription, opt => opt.MapFrom(x => x.ShortDescription))
                .ForMember(x => x.PublishedAt, opt => opt.MapFrom(x => x.PublishedAt))
                .ForMember(x => x.Category, opt => opt.MapFrom(x => x.Category))
                .ForMember(x => x.UserId, opt => opt.MapFrom(x => x.UserId))
                .ForMember(x => x.User, opt => opt.MapFrom(x => x.User))
                .ForMember(x => x.OrganizationId, opt => opt.MapFrom(x => x.OrganizationId))
                .ForMember(x => x.Organization, opt => opt.MapFrom(x => x.Organization))
                .ForMember(x => x.Tags, opt => opt.MapFrom(x => x.Tags))
                .ForMember(x => x.MainComments, opt => opt.MapFrom(x => x.MainComments));

            CreateMap<ListingMainComment, ListingMainCommentDto>()
                .MaxDepth(1);

            CreateMap<ListingMainCommentDto, ListingMainComment>();

            CreateMap<ListingSubComment, ListingSubCommentDto>()
                .MaxDepth(1);

            CreateMap<ListingSubCommentDto, ListingSubComment>();

            CreateMap<Subscriber, SubscriberDto>()
                .MaxDepth(1);


            CreateMap<SubscriberDto, Subscriber>();

            CreateMap<Organization, OrganizationDto>()
                .MaxDepth(1);

            CreateMap<OrganizationDto, Organization>();

            CreateMap<ApplicationUser, ApplicationUserDto>()
                .MaxDepth(1);

            CreateMap<ApplicationUserDto, ApplicationUser>();

            CreateMap<RegisterUserDto, ApplicationUser>()
                .ForMember(x=>x.UserName, opt=>opt.MapFrom(x=>x.UserName))
                .ForMember(x=>x.Email, opt=>opt.MapFrom(x=>x.Email))
                .ForMember(x=>x.Name, opt=>opt.MapFrom(x=>x.Name))
                .ForMember(x=>x.Location, opt=>opt.MapFrom(x=>x.Location))
                .ForAllOtherMembers(opt=>opt.Ignore());

            CreateMap<SignInUserDto, ApplicationUser>()
                .ForMember(x => x.UserName, opt => opt.MapFrom(x => x.Email))
                .ForAllOtherMembers(opt=>opt.Ignore());
        }
    }
}
