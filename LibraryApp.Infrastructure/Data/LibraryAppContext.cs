using LibraryApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Infrastructure.Data;

public class LibraryAppContext : DbContext
{
    public DbSet<Manga> Mangas { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Editor> Editors { get; set; }
    public DbSet<Status> Status { get; set; }
    public DbSet<User> Users { get; set; }

    public LibraryAppContext(DbContextOptions<LibraryAppContext> options) : base(options)
    {}
    
    // Méthode permettant de configurer les relations et les contraintes entre les tables
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        // Configuration des clés primaires
        modelBuilder.Entity<Author>().HasKey(a => a.Id);
        modelBuilder.Entity<Category>().HasKey(c => c.Id);
        modelBuilder.Entity<Editor>().HasKey(e => e.Id);
        modelBuilder.Entity<Status>().HasKey(s => s.Id);
        modelBuilder.Entity<User>().HasKey(u => u.Id);
        modelBuilder.Entity<Manga>().HasKey(m => m.Id);

        // Configuration des relations entre les tables
        // Author-Manga (One-to-Many)
        modelBuilder.Entity<Manga>()
            .HasOne(m => m.Author)
            .WithMany(a => a.Mangas)
            .HasForeignKey(m => m.AuthorId);

        // Category-Manga (One-to-Many)
        modelBuilder.Entity<Manga>()
            .HasOne(m => m.Category)
            .WithMany(c => c.Mangas)
            .HasForeignKey(m => m.CategoryId);

        // Editor-Manga (One-to-Many)
        modelBuilder.Entity<Manga>()
            .HasOne(m => m.Editor)
            .WithMany(e => e.Mangas)
            .HasForeignKey(m => m.EditorId);

        // Status-Manga (One-to-Many)
        modelBuilder.Entity<Manga>()
            .HasOne(m => m.Status)
            .WithMany(s => s.Mangas)
            .HasForeignKey(m => m.StatusId);

        // User-Manga (One-to-Many without ForeignKey in Manga)
        modelBuilder.Entity<User>()
            .HasMany(u => u.Mangas)
            .WithOne();
    }
}