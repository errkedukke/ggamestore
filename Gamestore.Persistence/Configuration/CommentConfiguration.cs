using Gamestore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gamestore.Persistence.Configuration;

public class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        // Table name (optional)
        builder.ToTable("Comments");

        // Primary Key
        builder.HasKey(c => c.Id);

        // Foreign Key Relationships

        // Game relationship: Comment is related to Game via GameId
        builder.HasOne(c => c.Game)
            .WithMany() // Assuming no navigation property in Game for Comments
            .HasForeignKey(c => c.GameId)
            .OnDelete(DeleteBehavior.NoAction); // Cascading delete when a Game is deleted

        // Author relationship: Comment is related to User via AuthorId
        builder.HasOne(c => c.Author)
            .WithMany() // Assuming no navigation property in User for Comments
            .HasForeignKey(c => c.AuthorId)
            .OnDelete(DeleteBehavior.NoAction); // Prevent delete if User exists

        // ParentComment relationship: A Comment can have a ParentComment, creating a self-referencing relationship
        builder.HasOne(c => c.ParentComment)
            .WithMany(c => c.Replies) // Replies is the collection of child comments
            .HasForeignKey(c => c.ParentCommentId)
            .OnDelete(DeleteBehavior.NoAction); // Prevent cascading delete on parent, set to null instead

        // Properties Configuration

        // Body: Required, max length of 1000 characters
        builder.Property(c => c.Body)
            .IsRequired()
            .HasMaxLength(1000);

        // IsBanned: Optional, default to false
        builder.Property(c => c.IsBanned)
            .IsRequired()
            .HasDefaultValue(false);

        // Replies: Configure the collection of replies (this is done via the self-referencing relationship)
        builder.HasMany(c => c.Replies)
            .WithOne(c => c.ParentComment)
            .HasForeignKey(c => c.ParentCommentId)
            .OnDelete(DeleteBehavior.NoAction); // Set null on parent comment deletion
    }
}
