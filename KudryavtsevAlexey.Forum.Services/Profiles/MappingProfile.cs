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
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.Title, opt => opt.MapFrom(x => x.Title))
                .ForMember(x => x.ShortDescription, opt => opt.MapFrom(x => x.ShortDescription))
                .ForMember(x => x.PublishedAt, opt => opt.MapFrom(x => x.PublishedAt))
                .ForMember(x => x.UserId, opt => opt.MapFrom(x => x.UserId))
                .ForMember(x => x.User, opt => opt.MapFrom(x => x.User))
                .ForMember(x => x.OrganizationId, opt => opt.MapFrom(x => x.OrganizationId))
                .ForMember(x => x.Organization, opt => opt.MapFrom(x => x.Organization))
                .ForMember(x => x.Tags, opt => opt.MapFrom(x => x.Tags))
                .ForMember(x => x.MainComments, opt => opt.MapFrom(x => x.MainComments))
                .MaxDepth(1);

            CreateMap<ArticleDto, Article>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.Title, opt => opt.MapFrom(x => x.Title))
                .ForMember(x => x.ShortDescription, opt => opt.MapFrom(x => x.ShortDescription))
                .ForMember(x => x.PublishedAt, opt => opt.MapFrom(x => x.PublishedAt))
                .ForMember(x => x.UserId, opt => opt.MapFrom(x => x.UserId))
                .ForMember(x => x.User, opt => opt.MapFrom(x => x.User))
                .ForMember(x => x.OrganizationId, opt => opt.MapFrom(x => x.OrganizationId))
                .ForMember(x => x.Organization, opt => opt.MapFrom(x => x.Organization))
                .ForMember(x => x.Tags, opt => opt.MapFrom(x => x.Tags))
                .ForMember(x => x.MainComments, opt => opt.MapFrom(x => x.MainComments));

            CreateMap<ArticleMainComment, ArticleMainCommentDto>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name))
                .ForMember(x => x.CreatedAt, opt => opt.MapFrom(x => x.CreatedAt))
                .ForMember(x => x.ArticleId, opt => opt.MapFrom(x => x.ArticleId))
                .ForMember(x => x.Article, opt => opt.MapFrom(x => x.Article))
                .ForMember(x => x.SubComments, opt => opt.MapFrom(x => x.SubComments))
                .MaxDepth(1);

            CreateMap<ArticleMainCommentDto, ArticleMainComment>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name))
                .ForMember(x => x.CreatedAt, opt => opt.MapFrom(x => x.CreatedAt))
                .ForMember(x => x.ArticleId, opt => opt.MapFrom(x => x.ArticleId))
                .ForMember(x => x.Article, opt => opt.MapFrom(x => x.Article))
                .ForMember(x => x.SubComments, opt => opt.MapFrom(x => x.SubComments));

            CreateMap<ArticleSubComment, ArticleSubCommentDto>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name))
                .ForMember(x => x.CreatedAt, opt => opt.MapFrom(x => x.CreatedAt))
                .ForMember(x => x.ArticleId, opt => opt.MapFrom(x => x.ArticleId))
                .ForMember(x => x.Article, opt => opt.MapFrom(x => x.Article))
                .ForMember(x => x.ArticleMainCommentId, opt => opt.MapFrom(x => x.ArticleMainCommentId))
                .ForMember(x => x.ArticleMainComment, opt => opt.MapFrom(x => x.ArticleMainComment))
                .MaxDepth(1);

            CreateMap<ArticleSubCommentDto, ArticleSubComment>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name))
                .ForMember(x => x.CreatedAt, opt => opt.MapFrom(x => x.CreatedAt))
                .ForMember(x => x.ArticleId, opt => opt.MapFrom(x => x.ArticleId))
                .ForMember(x => x.Article, opt => opt.MapFrom(x => x.Article))
                .ForMember(x => x.ArticleMainCommentId, opt => opt.MapFrom(x => x.ArticleMainCommentId))
                .ForMember(x => x.ArticleMainComment, opt => opt.MapFrom(x => x.ArticleMainComment));

            CreateMap<Tag, TagDto>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name))
                .ForMember(x => x.Articles, opt => opt.MapFrom(x => x.Articles))
                .ForMember(x => x.Listings, opt => opt.MapFrom(x => x.Listings))
                .MaxDepth(1);

            CreateMap<TagDto, Tag>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name))
                .ForMember(x => x.Articles, opt => opt.MapFrom(x => x.Articles))
                .ForMember(x => x.Listings, opt => opt.MapFrom(x => x.Listings));

            CreateMap<Article, PutArticleDto>()
                .ForMember(x => x.Title, opt => opt.MapFrom(x => x.Title))
                .ForMember(x => x.ShortDescription, opt => opt.MapFrom(x => x.ShortDescription))
                .ForMember(x => x.Tags, opt => opt.MapFrom(x => x.Tags))
                .MaxDepth(1);

            CreateMap<PutArticleDto, Article>()
                .ForMember(x => x.Title, opt => opt.MapFrom(x => x.Title))
                .ForMember(x => x.ShortDescription, opt => opt.MapFrom(x => x.ShortDescription))
                .ForMember(x => x.Tags, opt => opt.MapFrom(x => x.Tags));

            CreateMap<Listing, ListingDto>()
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
                .ForMember(x => x.MainComments, opt => opt.MapFrom(x => x.MainComments))
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
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name))
                .ForMember(x => x.CreatedAt, opt => opt.MapFrom(x => x.CreatedAt))
                .ForMember(x => x.ListingId, opt => opt.MapFrom(x => x.ListingId))
                .ForMember(x => x.Listing, opt => opt.MapFrom(x => x.Listing))
                .ForMember(x => x.SubComments, opt => opt.MapFrom(x => x.SubComments))
                .MaxDepth(1);

            CreateMap<ListingMainCommentDto, ListingMainComment>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name))
                .ForMember(x => x.CreatedAt, opt => opt.MapFrom(x => x.CreatedAt))
                .ForMember(x => x.ListingId, opt => opt.MapFrom(x => x.ListingId))
                .ForMember(x => x.Listing, opt => opt.MapFrom(x => x.Listing))
                .ForMember(x => x.SubComments, opt => opt.MapFrom(x => x.SubComments));

            CreateMap<ListingSubComment, ListingSubCommentDto>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name))
                .ForMember(x => x.CreatedAt, opt => opt.MapFrom(x => x.CreatedAt))
                .ForMember(x => x.ListingId, opt => opt.MapFrom(x => x.ListingId))
                .ForMember(x => x.Listing, opt => opt.MapFrom(x => x.Listing))
                .ForMember(x => x.ListingMainCommentId, opt => opt.MapFrom(x => x.ListingMainCommentId))
                .ForMember(x => x.ListingMainComment, opt => opt.MapFrom(x => x.ListingMainComment))
                .MaxDepth(1);

            CreateMap<ListingSubCommentDto, ListingSubComment>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name))
                .ForMember(x => x.CreatedAt, opt => opt.MapFrom(x => x.CreatedAt))
                .ForMember(x => x.ListingId, opt => opt.MapFrom(x => x.ListingId))
                .ForMember(x => x.Listing, opt => opt.MapFrom(x => x.Listing))
                .ForMember(x => x.ListingMainCommentId, opt => opt.MapFrom(x => x.ListingMainCommentId))
                .ForMember(x => x.ListingMainComment, opt => opt.MapFrom(x => x.ListingMainComment));

            CreateMap<Subscriber, SubscriberDto>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name))
                .ForMember(x => x.UserName, opt => opt.MapFrom(x => x.UserName))
                .ForMember(x => x.OrganizationId, opt => opt.MapFrom(x => x.OrganizationId))
                .ForMember(x => x.Organization, opt => opt.MapFrom(x => x.Organization))
                .ForMember(x => x.Users, opt => opt.MapFrom(x => x.Users))
                .ForMember(x => x.ImageUrl, opt => opt.MapFrom(x => x.ImageUrl))
                .MaxDepth(1);


            CreateMap<SubscriberDto, Subscriber>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name))
                .ForMember(x => x.UserName, opt => opt.MapFrom(x => x.UserName))
                .ForMember(x => x.OrganizationId, opt => opt.MapFrom(x => x.OrganizationId))
                .ForMember(x => x.Organization, opt => opt.MapFrom(x => x.Organization))
                .ForMember(x => x.Users, opt => opt.MapFrom(x => x.Users))
                .ForMember(x => x.ImageUrl, opt => opt.MapFrom(x => x.ImageUrl));

            CreateMap<Organization, OrganizationDto>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name))
                .ForMember(x => x.Users, opt => opt.MapFrom(x => x.Users))
                .ForMember(x => x.Articles, opt => opt.MapFrom(x => x.Articles))
                .ForMember(x => x.Listings, opt => opt.MapFrom(x => x.Listings))
                .ForMember(x => x.ImageUrl, opt => opt.MapFrom(x => x.ImageUrl))
                .MaxDepth(1);

            CreateMap<OrganizationDto, Organization>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name))
                .ForMember(x => x.Users, opt => opt.MapFrom(x => x.Users))
                .ForMember(x => x.Articles, opt => opt.MapFrom(x => x.Articles))
                .ForMember(x => x.Listings, opt => opt.MapFrom(x => x.Listings))
                .ForMember(x => x.ImageUrl, opt => opt.MapFrom(x => x.ImageUrl));

            CreateMap<ApplicationUser, ApplicationUserDto>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name))
                .ForMember(x => x.UserName, opt => opt.MapFrom(x => x.UserName))
                .ForMember(x => x.Location, opt => opt.MapFrom(x => x.Location))
                .ForMember(x => x.Summary, opt => opt.MapFrom(x => x.Summary))
                .ForMember(x => x.JoinedAt, opt => opt.MapFrom(x => x.JoinedAt))
                .ForMember(x => x.Articles, opt => opt.MapFrom(x => x.Articles))
                .ForMember(x => x.OrganizationId, opt => opt.MapFrom(x => x.OrganizationId))
                .ForMember(x => x.Organization, opt => opt.MapFrom(x => x.Organization))
                .ForMember(x => x.Listings, opt => opt.MapFrom(x => x.Listings))
                .ForMember(x => x.Subscribers, opt => opt.MapFrom(x => x.Subscribers))
                .MaxDepth(1);

            CreateMap<ApplicationUserDto, ApplicationUser>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name))
                .ForMember(x => x.UserName, opt => opt.MapFrom(x => x.UserName))
                .ForMember(x => x.Location, opt => opt.MapFrom(x => x.Location))
                .ForMember(x => x.Summary, opt => opt.MapFrom(x => x.Summary))
                .ForMember(x => x.JoinedAt, opt => opt.MapFrom(x => x.JoinedAt))
                .ForMember(x => x.Articles, opt => opt.MapFrom(x => x.Articles))
                .ForMember(x => x.OrganizationId, opt => opt.MapFrom(x => x.OrganizationId))
                .ForMember(x => x.Organization, opt => opt.MapFrom(x => x.Organization))
                .ForMember(x => x.Listings, opt => opt.MapFrom(x => x.Listings))
                .ForMember(x => x.Subscribers, opt => opt.MapFrom(x => x.Subscribers));

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
