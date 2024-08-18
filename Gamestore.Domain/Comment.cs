using Gamestore.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gamestore.Domain
{
    public class Comment : BaseEntity
    {
        [Required]
        [ForeignKey(nameof(Game))]
        public int GameId { get; set; }

        [Required]
        public string AuthorName { get; set; } = string.Empty;

        [Required]
        [ForeignKey(nameof(Customer))]
        public int AuthorId { get; set; }

        [Required]
        public string Body { get; set; } = string.Empty;

        public int ParentId { get; set; }

        [Required]
        public bool? IsCommentBanned { get; set; }
    }
}
