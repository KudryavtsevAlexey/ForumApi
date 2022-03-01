using KudryavtsevAlexey.Forum.Domain.BaseExceptions;

namespace KudryavtsevAlexey.Forum.Domain.CustomExceptions
{
    public class ArticleSubCommentNotFoundException : NotFoundException
    {
        public ArticleSubCommentNotFoundException(int articleSubCommentId)
            :base($"Article subcomment with identifier {articleSubCommentId} was not found")
        {
            
        }
    }
}
