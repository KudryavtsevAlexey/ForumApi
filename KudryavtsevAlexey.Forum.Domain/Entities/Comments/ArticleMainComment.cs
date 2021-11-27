using System.Collections.Generic;

namespace KudryavtsevAlexey.Forum.Domain.Entities.Comments
{
    public class ArticleMainComment : Comment
    {
        public int ArticleId { get; set; }

        public Article Article { get; set; }

        public ICollection<ArticleSubComment> SubComments { get; set; }
    }
}
