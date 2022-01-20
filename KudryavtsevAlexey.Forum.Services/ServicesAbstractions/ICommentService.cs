using System;
using KudryavtsevAlexey.Forum.Domain.Entities;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using KudryavtsevAlexey.Forum.Services.Dtos.Comment;
using Microsoft.Identity.Client;

namespace KudryavtsevAlexey.Forum.Services.ServicesAbstractions
{
	public interface ICommentService
    {
        public Task<List<ArticleMainCommentDto>> GetArticleComments(int articleId);

        public Task<ArticleMainCommentDto> GetArticleMainCommentById(int articleMainCommentId);

        public Task<List<ListingMainCommentDto>> GetListingComments(int listingId);

        public Task<ListingMainCommentDto> GetListingMainCommentById(int listingMainCommentId);

        public Task<ArticleSubCommentDto> GetArticleSubCommentById(int articleSubCommentId);
        
        public Task<ListingSubCommentDto> GetListingSubCommentById(int listingSubCommentId);

        public Task<List<ArticleMainCommentDto>> GetAllArticlesComments();

        public Task<List<ListingMainCommentDto>> GetAllListingsComments();

        public Task CreateArticleMainComment(CreateArticleMainCommentDto articleMainCommentDto);

        public Task CreateListingMainComment(CreateListingMainCommentDto listingMainCommentDto);

        public Task CreateArticleSubComment(CreateArticleSubCommentDto articleSubCommentDto);

        public Task CreateListingSubComment(CreateListingSubCommentDto listingSubCommentDto);

        public Task UpdateArticleMainComment(UpdateArticleMainCommentDto articleMainCommentDto);

        public Task UpdateListingMainComment(UpdateListingMainCommentDto listingMainCommentDto);

        public Task UpdateArticleSubComment(UpdateArticleSubCommentDto articleSubCommentDto);

        public Task UpdateListingSubComment(UpdateListingSubCommentDto listingSubCommentDto);

        public Task DeleteArticleMainComment(int articleMainCommentId);

        public Task DeleteListingMainComment(int listingMainCommentId);

        public Task DeleteArticleSubComment(int articleSubCommentId);

        public Task DeleteListingSubComment(int listingSubCommentId);
    }
}
