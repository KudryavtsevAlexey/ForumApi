using KudryavtsevAlexey.Forum.Domain.BaseExceptions;

namespace KudryavtsevAlexey.Forum.Domain.CustomExceptions
{
    public class ArticleNotFoundException : NotFoundException
    {
        public ArticleNotFoundException(int articleId)
            : base($"Article with the identifier {articleId} was not found")
        {
        }
    }
}
