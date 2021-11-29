using KudryavtsevAlexey.Forum.Domain.BaseEntities;

namespace KudryavtsevAlexey.Forum.Domain.Entities.Comments
{
    public class ArticleSubComment : Comment
    {
        public int ArticleId { get; set; }

        public Article Article { get; set; }

        public int ArticleMainCommentId { get; set; }

        public ArticleMainComment ArticleMainComment { get; set; }
    }
}
