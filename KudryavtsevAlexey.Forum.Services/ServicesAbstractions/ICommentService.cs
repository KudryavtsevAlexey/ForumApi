using KudryavtsevAlexey.Forum.Domain.Entities;
using KudryavtsevAlexey.Forum.Services.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;
using KudryavtsevAlexey.Forum.Services.Dtos.Comment;
using Microsoft.Identity.Client;

namespace KudryavtsevAlexey.Forum.Services.ServicesAbstractions
{
    public interface ICommentService
    {
        public Task<List<ArticleMainCommentDto>> GetArticleComments(int id);

        public Task<ArticleMainCommentDto> GetArticleMainCommentById(int id);

        public Task<List<ListingMainCommentDto>> GetListingComments(int id);

        public Task<ListingMainCommentDto> GetListingMainCommentById(int id);

        public Task<ArticleSubCommentDto> GetArticleSubCommentById(int id);
        
        public Task<ListingSubCommentDto> GetListingSubCommentById(int id);

        public Task<List<ArticleMainCommentDto>> GetAllArticlesComments();

        public Task<List<ListingMainCommentDto>> GetAllListingsComments();

        public Task CreateArticleMainComment(CreateArticleMainCommentDto articleMainCommentDto);

        public Task CreateListingMainComment(CreateListingMainCommentDto listingMainCommentDto);

        public Task CreateArticleSubComment(CreateArticleSubCommentDto articleSubCommentDto);

        public Task CreateListingSubComment(CreateListingSubCommentDto listingSubCommentDto);

        public Task UpdateArticleMainComment(int id, UpdateArticleMainCommentDto articleMainCommentDto);

        public Task UpdateListingMainComment(int id, UpdateListingMainCommentDto listingMainCommentDto);

        public Task UpdateArticleSubComment(int id, UpdateArticleSubCommentDto articleSubCommentDto);

        public Task UpdateListingSubComment(int id, UpdateListingSubCommentDto listingSubCommentDto);

        public Task DeleteArticleMainComment(int id);

        public Task DeleteListingMainComment(int id);

        public Task DeleteArticleSubComment(int id);

        public Task DeleteListingSubComment(int id);
    }
}
