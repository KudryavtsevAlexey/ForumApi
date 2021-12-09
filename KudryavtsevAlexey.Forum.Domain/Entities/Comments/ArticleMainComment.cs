using System.Collections.Generic;
using KudryavtsevAlexey.Forum.Domain.BaseEntities;

namespace KudryavtsevAlexey.Forum.Domain.Entities.Comments
{
    public class ArticleMainComment : Comment
    {
        public int ArticleId { get; set; }

        public Article Article { get; set; }

        public ICollection<ArticleSubComment> SubComments { get; set; }

        public ArticleMainComment()
        {
            SubComments = new List<ArticleSubComment>();
        }
    }
}
