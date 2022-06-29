using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PostsWebAPI.DataDB
{
    public partial class dbTaskContext : DbContext
    {
        public dbTaskContext()
        {
        }

        public dbTaskContext(DbContextOptions<dbTaskContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Post> Posts { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=dbTask;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>(entity =>
            {
                entity.ToTable("Post");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Body)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("body");

                entity.Property(e => e.Title)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("title");

                entity.Property(e => e.UserId).HasColumnName("userId");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
