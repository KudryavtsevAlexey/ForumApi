using AutoMapper;

using KudryavtsevAlexey.Forum.Infrastructure.Database;
using KudryavtsevAlexey.Forum.Services.MappingHelpers;
using KudryavtsevAlexey.Forum.Services.Services;
using KudryavtsevAlexey.Forum.Services.ServicesAbstractions;

using System;
using System.Collections.Generic;
using KudryavtsevAlexey.Forum.Domain.Entities;
using KudryavtsevAlexey.Forum.Services.Dtos;

namespace KudryavtsevAlexey.Forum.Services.ServiceManager
{
    public class ServiceManager : IServiceManager
    {
        // TODO: Split comment service to 2 services (main and sub)

        // TODO: Create Dtos and mapping helpers for everything

        private readonly Lazy<IArticleService> _lazyArticleService;
        private readonly Lazy<IMappingHelper<ArticleDto, Article>> _lazyArticleMappingHelper;
        private readonly Lazy<ICommentService> _lazyCommentService;
        private readonly Lazy<IListingService> _lazyListingService;
        private readonly Lazy<IOrganizationService> _lazyOrganizationService;
        private readonly Lazy<ITagService> _lazyTagService;
        private readonly Lazy<IUserService> _lazyUserService;

        public ServiceManager(ForumDbContext dbContext, IMapper mapper)
        {
            _lazyArticleMappingHelper = new Lazy<IMappingHelper<ArticleDto, Article>>(() 
                => new MappingHelper<ArticleDto, Article>(mapper));
            _lazyArticleService = new Lazy<IArticleService>(() => new ArticleService(dbContext, _lazyArticleMappingHelper.Value));
            _lazyCommentService = new Lazy<ICommentService>(() => new CommentService(dbContext));
            _lazyListingService = new Lazy<IListingService>(() => new ListingService(dbContext));
            _lazyOrganizationService = new Lazy<IOrganizationService>(() => new OrganizationService(dbContext));
            _lazyTagService = new Lazy<ITagService>(() => new TagService(dbContext));
            _lazyUserService = new Lazy<IUserService>(() => new UserService(dbContext));
        }

        public IArticleService ArticleService => _lazyArticleService.Value;
        public ICommentService CommentService => _lazyCommentService.Value;
        public IListingService ListingService => _lazyListingService.Value;
        public IOrganizationService OrganizationService => _lazyOrganizationService.Value;
        public ITagService TagService => _lazyTagService.Value;
        public IUserService UserService => _lazyUserService.Value;
    }
}
