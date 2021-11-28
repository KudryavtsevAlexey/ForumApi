using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
