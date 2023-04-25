using System.Collections.Generic;
using MB.Application.Contracts.Article;

namespace MB.Domain.ArticleAgg
{
    public interface IArticleRepository
    {
        Article Get(long id);
        List<ArticleViewModel> GetList();
        void CreateAndSave(Article entity);
        void Save();
        bool Exists(string title);
    }
}
