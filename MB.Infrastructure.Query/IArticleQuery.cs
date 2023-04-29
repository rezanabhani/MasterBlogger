using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace MB.Infrastructure.Query
{
    public interface IArticleQuery
    {
        List<ArticleQueryView> GetArticles();
        ArticleQueryView GetArticle(long id);
    }
}
