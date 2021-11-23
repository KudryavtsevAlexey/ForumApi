using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

using KudryavtsevAlexey.Forum.Services.MappingHelpers;
using KudryavtsevAlexey.Forum.Services.Services;
using KudryavtsevAlexey.Forum.Services.ServicesAbstractions;

namespace KudryavtsevAlexey.Forum.Services.ServiceManager
{
    public interface IServiceManager
    {
        IArticleService ArticleService { get; }

        ICommentService CommentService { get; }

        IListingService ListingService { get; }

        IOrganizationService OrganizationService { get; }

        ITagService TagService { get; }

        IUserService UserService { get; }
    }
}
