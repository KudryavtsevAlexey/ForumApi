using AutoMapper;
using KudryavtsevAlexey.Forum.Domain.Entities;
using KudryavtsevAlexey.Forum.Domain.Entities.Comments;
using KudryavtsevAlexey.Forum.Services.Dtos.Article;
using KudryavtsevAlexey.Forum.Services.Dtos.Comment;
using KudryavtsevAlexey.Forum.Services.Dtos.Listing;
using KudryavtsevAlexey.Forum.Services.Dtos.Organization;
using KudryavtsevAlexey.Forum.Services.Dtos.Subscriber;
using KudryavtsevAlexey.Forum.Services.Dtos.Tag;
using KudryavtsevAlexey.Forum.Services.Dtos.User;

namespace KudryavtsevAlexey.Forum.Services.Profiles
{
	public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RegisterUserDto, ApplicationUser>()
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name))
                .ForMember(x => x.UserName, opt => opt.MapFrom(x => x.UserName))
                .ForMember(x => x.Location, opt => opt.MapFrom(x => x.Location))
                .ForMember(x => x.Email, opt => opt.MapFrom(x => x.Email))
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<Article, ArticleDto>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.Title, opt => opt.MapFrom(x => x.Title))
                .ForMember(x => x.PublishedAt, opt => opt.MapFrom(x => x.PublishedAt))
                .ForMember(x => x.Tags, opt => opt.MapFrom(x => x.Tags))
                .ForMember(x => x.User, opt => opt.MapFrom(x => x.User))
                .ForMember(x => x.UserId, opt => opt.MapFrom(x => x.UserId))
                .MaxDepth(1)
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<CreateArticleDto, Article>()
                .ForMember(x => x.Title, opt => opt.MapFrom(x => x.Title))
                .ForMember(x => x.ShortDescription, opt => opt.MapFrom(x => x.ShortDescription))
                .ForMember(x => x.UserId, opt => opt.MapFrom(x => x.UserId))
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<UpdateArticleDto, Article>()
	            .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
	            .ForMember(x => x.Title, opt => opt.MapFrom(x => x.Title))
	            .ForMember(x => x.ShortDescription, opt => opt.MapFrom(x => x.ShortDescription))
	            .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<ArticleMainComment, ArticleMainCommentDto>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.Content, opt => opt.MapFrom(x => x.Content))
                .ForMember(x => x.UserId, opt => opt.MapFrom(x => x.UserId))
                .ForMember(x => x.User, opt => opt.MapFrom(x => x.User))
                .ForMember(x => x.ArticleId, opt => opt.MapFrom(x => x.ArticleId))
                .ForMember(x => x.Article, opt => opt.MapFrom(x => x.Article))
                .ForMember(x => x.CreatedAt, opt => opt.MapFrom(x => x.CreatedAt))
                .ForMember(x => x.SubComments, opt => opt.MapFrom(x => x.SubComments))
                .MaxDepth(1)
                .ReverseMap()
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<ArticleSubComment, ArticleSubCommentDto>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.Content, opt => opt.MapFrom(x => x.Content))
                .ForMember(x => x.UserId, opt => opt.MapFrom(x => x.UserId))
                .ForMember(x => x.User, opt => opt.MapFrom(x => x.User))
                .ForMember(x => x.ArticleId, opt => opt.MapFrom(x => x.ArticleId))
                .ForMember(x => x.Article, opt => opt.MapFrom(x => x.Article))
                .ForMember(x => x.CreatedAt, opt => opt.MapFrom(x => x.CreatedAt))
                .ForMember(x => x.ArticleMainCommentId, opt => opt.MapFrom(x => x.ArticleMainCommentId))
                .ForMember(x => x.ArticleMainComment, opt => opt.MapFrom(x => x.ArticleMainComment))
                .MaxDepth(1)
                .ReverseMap()
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<ListingMainComment, ListingMainCommentDto>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.Content, opt => opt.MapFrom(x => x.Content))
                .ForMember(x => x.UserId, opt => opt.MapFrom(x => x.UserId))
                .ForMember(x => x.User, opt => opt.MapFrom(x => x.User))
                .ForMember(x => x.ListingId, opt => opt.MapFrom(x => x.ListingId))
                .ForMember(x => x.Listing, opt => opt.MapFrom(x => x.Listing))
                .ForMember(x => x.CreatedAt, opt => opt.MapFrom(x => x.CreatedAt))
                .ForMember(x => x.SubComments, opt => opt.MapFrom(x => x.SubComments))
                .MaxDepth(1)
                .ReverseMap()
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<ListingSubComment, ListingSubCommentDto>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.Content, opt => opt.MapFrom(x => x.Content))
                .ForMember(x => x.UserId, opt => opt.MapFrom(x => x.UserId))
                .ForMember(x => x.User, opt => opt.MapFrom(x => x.User))
                .ForMember(x => x.ListingId, opt => opt.MapFrom(x => x.ListingId))
                .ForMember(x => x.Listing, opt => opt.MapFrom(x => x.Listing))
                .ForMember(x => x.CreatedAt, opt => opt.MapFrom(x => x.CreatedAt))
                .ForMember(x => x.ListingMainCommentId, opt => opt.MapFrom(x => x.ListingMainCommentId))
                .ForMember(x => x.ListingMainComment, opt => opt.MapFrom(x => x.ListingMainComment))
                .MaxDepth(1)
                .ReverseMap()
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<CreateArticleMainCommentDto, ArticleMainComment>()
	            .ForMember(x => x.Content, opt => opt.MapFrom(x => x.Content))
                .ForMember(x => x.CreatedAt, opt => opt.MapFrom(x => x.CreatedAt))
                .ForMember(x => x.UserId, opt => opt.MapFrom(x => x.UserId))
                .ForMember(x => x.ArticleId, opt => opt.MapFrom(x => x.ArticleId))
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<CreateListingMainCommentDto, ListingMainComment>()
                .ForMember(x => x.Content, opt => opt.MapFrom(x => x.Content))
                .ForMember(x => x.CreatedAt, opt => opt.MapFrom(x => x.CreatedAt))
                .ForMember(x => x.UserId, opt => opt.MapFrom(x => x.UserId))
                .ForMember(x => x.ListingId, opt => opt.MapFrom(x => x.ListingId))
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<CreateArticleSubCommentDto, ArticleSubComment>()
                .ForMember(x => x.Content, opt => opt.MapFrom(x => x.Content))
                .ForMember(x => x.CreatedAt, opt => opt.MapFrom(x => x.CreatedAt))
                .ForMember(x => x.UserId, opt => opt.MapFrom(x => x.UserId))
                .ForMember(x => x.ArticleId, opt => opt.MapFrom(x => x.ArticleId))
                .ForMember(x => x.ArticleMainCommentId, opt => opt.MapFrom(x => x.ArticleMainCommentId))
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<CreateListingSubCommentDto, ListingSubComment>()
                .ForMember(x => x.Content, opt => opt.MapFrom(x => x.Content))
                .ForMember(x => x.CreatedAt, opt => opt.MapFrom(x => x.CreatedAt))
                .ForMember(x => x.UserId, opt => opt.MapFrom(x => x.UserId))
                .ForMember(x => x.ListingId, opt => opt.MapFrom(x => x.ListingId))
                .ForMember(x => x.ListingMainCommentId, opt => opt.MapFrom(x => x.ListingMainCommentId))
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<UpdateArticleMainCommentDto, ArticleMainComment>()
	            .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.Content, opt => opt.MapFrom(x => x.Content))
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<UpdateListingMainCommentDto, ListingMainComment>()
	            .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.Content, opt => opt.MapFrom(x => x.Content))
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<UpdateArticleSubCommentDto, ArticleSubComment>()
	            .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.Content, opt => opt.MapFrom(x => x.Content))
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<UpdateListingSubCommentDto, ListingSubComment>()
	            .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(x=>x.Content, opt=>opt.MapFrom(x=>x.Content))
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<Listing, ListingDto>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.Title, opt => opt.MapFrom(x => x.Title))
                .ForMember(x => x.ShortDescription, opt => opt.MapFrom(x => x.ShortDescription))
                .ForMember(x => x.Category, opt => opt.MapFrom(x => x.Category))
                .ForMember(x => x.Tags, opt => opt.MapFrom(x => x.Tags))
                .MaxDepth(1)
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<CreateListingDto, Listing>()
                .ForMember(x => x.Title, opt => opt.MapFrom(x => x.Title))
                .ForMember(x => x.ShortDescription, opt => opt.MapFrom(x => x.ShortDescription))
                .ForMember(x => x.Category, opt => opt.MapFrom(x => x.Category))
                .ForMember(x => x.UserId, opt => opt.MapFrom(x => x.UserId))
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<UpdateListingDto, Listing>()
	            .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.Title, opt => opt.MapFrom(x => x.Title))
                .ForMember(x => x.ShortDescription, opt => opt.MapFrom(x => x.Title))
                .ForMember(x => x.Category, opt => opt.MapFrom(x => x.Category))
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<Organization, OrganizationDto>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name))
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<ApplicationUser, ApplicationUserDto>()
	            .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
	            .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name))
	            .ForMember(x => x.UserName, opt => opt.MapFrom(x => x.UserName))
	            .ForMember(x => x.Location, opt => opt.MapFrom(x => x.Location))
	            .ForMember(x => x.Summary, opt => opt.MapFrom(x => x.Summary))
	            .ForMember(x => x.JoinedAt, opt => opt.MapFrom(x => x.JoinedAt))
	            .ForMember(x => x.OrganizationId, opt => opt.MapFrom(x => x.OrganizationId))
	            .ForMember(x => x.Organization, opt => opt.MapFrom(x => x.Organization))
	            .ForMember(x => x.Email, opt => opt.MapFrom(x => x.Email))
	            .MaxDepth(1)
	            .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<CreateOrganizationDto, Organization>()
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name))
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<UpdateOrganizationDto, Organization>()
	            .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name))
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<Tag, TagDto>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name))
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<CreateTagDto, Tag>()
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name))
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<UpdateTagDto, Tag>()
	            .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name))
                .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<Subscriber, ApplicationUserDto>()
	            .ForMember(x => x.Id, opt => opt.MapFrom(x => x.UserId))
	            .ForMember(x => x.UserName, opt => opt.MapFrom(x => x.User.UserName))
	            .ForMember(x => x.Name, opt => opt.MapFrom(x => x.User.Name))
	            .ForMember(x => x.Summary, opt => opt.MapFrom(x => x.User.Summary))
	            .ForMember(x => x.Location, opt => opt.MapFrom(x => x.User.Location))
	            .ForMember(x => x.JoinedAt, opt => opt.MapFrom(x => x.User.JoinedAt))
	            .ForMember(x => x.Email, opt => opt.MapFrom(x => x.User.Email))
	            .ForMember(x => x.OrganizationId, opt => opt.MapFrom(x => x.User.OrganizationId))
	            .ForMember(x => x.Organization, opt => opt.MapFrom(x => x.User.Organization))
	            .MaxDepth(1)
	            .ReverseMap()
	            .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<Subscriber, SubscriberDto>()
	            .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
	            .ForMember(x => x.UserId, opt => opt.MapFrom(x => x.UserId))
	            .ForPath(x => x.User.Name, opt => opt.MapFrom(x => x.User.Name))
	            .ForPath(x => x.User.Location, opt => opt.MapFrom(x => x.User.Location))
	            .ForPath(x => x.User.Summary, opt => opt.MapFrom(x => x.User.Summary))
	            .ForPath(x => x.User.OrganizationId, opt => opt.MapFrom(x => x.User.OrganizationId))
	            .ForPath(x => x.User.Organization, x => x.MapFrom(x => x.User.Organization))
	            .ForPath(x => x.User.JoinedAt, opt => opt.MapFrom(x => x.User.JoinedAt))
	            .ForPath(x => x.User.Email, opt => opt.MapFrom(x => x.User.Email))
	            .ForPath(x => x.User.UserName, opt => opt.MapFrom(x => x.User.UserName))
	            .MaxDepth(1)
	            .ReverseMap()
	            .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<ApplicationUser, Subscriber>()
	            .ForMember(x => x.Id, opt => opt.Ignore())
	            .ForMember(x => x.UserId, opt => opt.MapFrom(x => x.Id))
	            .ForPath(x => x.User.Name, opt => opt.MapFrom(x => x.Name))
	            .ForPath(x => x.User.Location, opt => opt.MapFrom(x => x.Location))
	            .ForPath(x => x.User.Summary, opt => opt.MapFrom(x => x.Summary))
	            .ForPath(x => x.User.OrganizationId, opt => opt.MapFrom(x => x.OrganizationId))
	            .ForPath(x => x.User.Organization, x => x.MapFrom(x => x.Organization))
	            .ForPath(x => x.User.JoinedAt, opt => opt.MapFrom(x => x.JoinedAt))
	            .ForPath(x => x.User.Email, opt => opt.MapFrom(x => x.Email))
	            .ForPath(x => x.User.UserName, opt => opt.MapFrom(x => x.UserName))
	            .MaxDepth(1)
	            .ReverseMap()
	            .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<ApplicationUser, Subscription>()
	            .ForMember(x => x.Id, opt => opt.Ignore())
	            .ForMember(x => x.UserId, opt => opt.MapFrom(x => x.Id))
	            .ForPath(x => x.User.Name, opt => opt.MapFrom(x => x.Name))
	            .ForPath(x => x.User.Location, opt => opt.MapFrom(x => x.Location))
	            .ForPath(x => x.User.Summary, opt => opt.MapFrom(x => x.Summary))
	            .ForPath(x => x.User.OrganizationId, opt => opt.MapFrom(x => x.OrganizationId))
	            .ForPath(x => x.User.Organization, x => x.MapFrom(x => x.Organization))
	            .ForPath(x => x.User.JoinedAt, opt => opt.MapFrom(x => x.JoinedAt))
	            .ForPath(x => x.User.Email, opt => opt.MapFrom(x => x.Email))
	            .ForPath(x => x.User.UserName, opt => opt.MapFrom(x => x.UserName))
	            .MaxDepth(1)
	            .ReverseMap()
	            .ForAllOtherMembers(opt => opt.Ignore());

            CreateMap<UpdateApplicationUserDto, ApplicationUser>()
	            .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.UserName, opt => opt.MapFrom(x => x.UserName))
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name))
                .ForMember(x => x.Location, opt => opt.MapFrom(x => x.Location))
                .ForMember(x => x.Summary, opt => opt.MapFrom(x => x.Summary))
	            .MaxDepth(1)
	            .ReverseMap()
                .ForAllOtherMembers(opt => opt.Ignore());
        }
    }
}
