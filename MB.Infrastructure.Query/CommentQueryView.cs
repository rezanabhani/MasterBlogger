using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MB.Infrastructure.Query
{
    public class CommentQueryView
    {
        public string Name { get; set; }
        public string CreationDate { get; set; }
        public string Message { get; set; }
    }
}
