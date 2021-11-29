using AutoMapper;

using KudryavtsevAlexey.Forum.Infrastructure.Database;
using KudryavtsevAlexey.Forum.Services.Services;
using KudryavtsevAlexey.Forum.Services.ServicesAbstractions;

using System;

namespace KudryavtsevAlexey.Forum.Services.ServiceManager
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IArticleService> _lazyArticleService;
        private readonly Lazy<ICommentService> _lazyCommentService;
        private readonly Lazy<IListingService> _lazyListingService;
        private readonly Lazy<IOrganizationService> _lazyOrganizationService;
        private readonly Lazy<IUserService> _lazyUserService;

        public ServiceManager(ForumDbContext dbContext, IMapper mapper)
        {
            _lazyArticleService = new Lazy<IArticleService>(() => new ArticleService(dbContext, mapper));
            _lazyCommentService = new Lazy<ICommentService>(() => new CommentService(dbContext, mapper));
            _lazyListingService = new Lazy<IListingService>(() => new ListingService(dbContext, mapper));
            _lazyOrganizationService = new Lazy<IOrganizationService>(() => new OrganizationService(dbContext));
            _lazyUserService = new Lazy<IUserService>(() => new UserService(dbContext, mapper));
        }

        public IArticleService ArticleService => _lazyArticleService.Value;
        public ICommentService CommentService => _lazyCommentService.Value;
        public IListingService ListingService => _lazyListingService.Value;
        public IOrganizationService OrganizationService => _lazyOrganizationService.Value;
        public IUserService UserService => _lazyUserService.Value;
    }
}
