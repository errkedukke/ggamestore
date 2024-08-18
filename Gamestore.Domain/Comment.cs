using Gamestore.Domain.Common;

namespace Gamestore.Domain
{
    public class Comment : BaseEntity
    {
        public Game? Game { get; set; }

        public Customer? Author { get; set; }

        public Comment? ParentComment { get; set; }

        public string Body { get; set; } = string.Empty;

        public bool IsBanned { get; set; }
    }
}
