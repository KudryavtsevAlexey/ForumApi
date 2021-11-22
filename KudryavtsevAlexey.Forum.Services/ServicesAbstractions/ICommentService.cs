using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KudryavtsevAlexey.Forum.Domain.Entities;
using KudryavtsevAlexey.Forum.Domain.Entities.Comments;

namespace KudryavtsevAlexey.Forum.Services.ServicesAbstractions
{
    public interface ICommentService
    {
        public Task<List<ArticleMainComment>> GetArticleComments(Article article);

        public Task<ArticleMainComment> GetArticleMainCommentById(int id);

        public Task<List<ListingMainComment>> GetListingComments(Listing listing);

        public Task<ListingMainComment> GetListingMainCommentById(int id);

        public Task<ArticleSubComment> GetArticleSubCommentById(int id);
        
        public Task<ListingSubComment> GetListingSubCommentById(int id);

        public Task<List<ArticleMainComment>> GetAllArticleComments();

        public Task<List<ListingMainComment>> GetAllListingComments();
    }
}
