using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gamestore.Domain
{
    public class Comment
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [ForeignKey(nameof(Game))]
        public Guid GameId { get; set; }

        [Required]
        public string AuthorName { get; set; } = string.Empty;

        [Required]
        [ForeignKey(nameof(Customer))]
        public Guid AuthorId { get; set; }

        [Required]
        public string Body { get; set; } = string.Empty;

        public Guid? ParentId { get; set; }

        [Required]
        public bool? IsCommentBanned { get; set; }

        [Required]
        public DateTime DateTime { get; set; }
    }
}
