using KudryavtsevAlexey.Forum.Domain.Entities;
using KudryavtsevAlexey.Forum.Services.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KudryavtsevAlexey.Forum.Services.ServicesAbstractions
{
    public interface ICommentService
    {
        public Task<List<ArticleMainCommentDto>> GetArticleComments(ArticleDto article);

        public Task<ArticleMainCommentDto> GetArticleMainCommentById(int id);

        public Task<List<ListingMainCommentDto>> GetListingComments(ListingDto listing);

        public Task<ListingMainCommentDto> GetListingMainCommentById(int id);

        public Task<ArticleSubCommentDto> GetArticleSubCommentById(int id);
        
        public Task<ListingSubCommentDto> GetListingSubCommentById(int id);

        public Task<List<ArticleMainCommentDto>> GetAllArticlesComments();

        public Task<List<ListingMainCommentDto>> GetAllListingsComments();
    }
}
