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
}