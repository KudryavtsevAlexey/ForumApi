using AutoMapper;

using KudryavtsevAlexey.Forum.Infrastructure.Database;
using KudryavtsevAlexey.Forum.Services.Services;
using KudryavtsevAlexey.Forum.Services.ServicesAbstractions;

using System;
using KudryavtsevAlexey.Forum.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace KudryavtsevAlexey.Forum.Services.ServiceManager
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IArticleService> _lazyArticleService;
        private readonly Lazy<ICommentService> _lazyCommentService;
        private readonly Lazy<IListingService> _lazyListingService;
        private readonly Lazy<IOrganizationService> _lazyOrganizationService;
        private readonly Lazy<IUserService> _lazyUserService;
        private readonly Lazy<IAccountService> _lazyAccountService;
        private readonly Lazy<ITagService> _lazyTagService;

        public ServiceManager(ForumDbContext dbContext, UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
                            IMapper mapper, IConfiguration configuration)
        {
            _lazyArticleService = new Lazy<IArticleService>(() => new ArticleService(dbContext, mapper));
            _lazyCommentService = new Lazy<ICommentService>(() => new CommentService(dbContext, mapper));
            _lazyListingService = new Lazy<IListingService>(() => new ListingService(dbContext, mapper));
            _lazyOrganizationService = new Lazy<IOrganizationService>(() => new OrganizationService(dbContext, mapper));
            _lazyUserService = new Lazy<IUserService>(() => new UserService(dbContext, mapper));
            _lazyAccountService = new Lazy<IAccountService>(() => new AccountService(dbContext, userManager, signInManager, mapper, configuration));
            _lazyTagService = new Lazy<ITagService>(() => new TagService(dbContext, mapper));
        }

        public IArticleService ArticleService => _lazyArticleService.Value;
        public ICommentService CommentService => _lazyCommentService.Value;
        public IListingService ListingService => _lazyListingService.Value;
        public IOrganizationService OrganizationService => _lazyOrganizationService.Value;
        public IUserService UserService => _lazyUserService.Value;
        public IAccountService AccountService => _lazyAccountService.Value;
        public ITagService TagService => _lazyTagService.Value;
    }
}
