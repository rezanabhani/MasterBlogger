using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using MB.Domain.CommentAgg;
using MB.Infrastructure.EfCore;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrastructure.Query
{
    public class ArticleQuery : IArticleQuery
    {
        private readonly MasterBloggerContext _context;

        public ArticleQuery(MasterBloggerContext context)
        {
            _context = context;
        }

        public List<ArticleQueryView> GetArticles()
        {
            return _context.Articles
                .Include(x => x.ArticleCategory)
                .Include(x => x.Comments)
                .Select(x => new ArticleQueryView()
                {
                    Id = x.Id,
                    Title = x.Title,
                    Image = x.Image,
                    ArticleCategory = x.ArticleCategory.Title,
                    CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
                    ShortDescription = x.ShortDescription,
                    CommentsCount = x.Comments.Count(x => x.Status == Statuses.Confirm)
                }).ToList();
        }

        public ArticleQueryView GetArticle(long id)
        {
            return _context.Articles
                .Include(x => x.ArticleCategory)
                .Select(x => new ArticleQueryView()
            {
                Id = x.Id,
                Title = x.Title,
                Image = x.Image,
                ArticleCategory = x.ArticleCategory.Title,
                CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
                ShortDescription = x.ShortDescription,
                Content = x.Content,
                CommentsCount = x.Comments.Count(x => x.Status == Statuses.Confirm),
                Comments = MapComments(x.Comments.Where(x => x.Status == Statuses.Confirm))
            }).FirstOrDefault(x => x.Id == id);
        }

        private static List<CommentQueryView> MapComments(IEnumerable<Comment> comments)
        {
            return comments.Select(comment => new CommentQueryView()
            {
                Name = comment.Name,
                CreationDate = comment.CreationDate.ToString(), 
                Message = comment.Message
            }).ToList();
        }
    }
}
