using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Server.Models
{
    public partial class fbContext : DbContext
    {
        public fbContext()
        {
        }

        public fbContext(DbContextOptions<fbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Post> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=BHAVNAWKS727;Database=fb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("Comment");

                entity.Property(e => e.CommentId).HasColumnName("Comment_ID");

                entity.Property(e => e.CommentDetail)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Comment_Detail");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("Created_Date");

                entity.Property(e => e.PostId).HasColumnName("Post_ID");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("Updated_Date");

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.PostId)
                    .HasConstraintName("FK__Comment__Post_ID__267ABA7A");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.ToTable("Post");

                entity.Property(e => e.PostId).HasColumnName("Post_ID");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("Created_Date");

                entity.Property(e => e.PostDescription)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Post_Description");

                entity.Property(e => e.PostName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("Post_Name");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("Updated_Date");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
