using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace MB.Domain.ArticleCategoryAgg
{
    public interface IArticleCategoryRepository
    {
        List<ArticleCategory> GetAll();
        ArticleCategory Get(long id);
        void Add(ArticleCategory entity);
        bool Exists(string title);
        void Save();
    }
}
