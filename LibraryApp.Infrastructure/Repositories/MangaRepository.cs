using LibraryApp.Domain.Entities;
using LibraryApp.Domain.Interfaces;
using LibraryApp.Infrastructure.Data;

namespace LibraryApp.Infrastructure.Repositories;

public class MangaRepository : IMangaRepository
{
    private readonly LibraryAppContext _context;

    // Appel du constructeur dans le conteneur d'injection de dépendances, qui va initialiser le contexte (étant donné qu'il fait partie de son registre)
    public MangaRepository(LibraryAppContext context)
    {
        _context = context;
    }

    public void Add(Manga manga)
    {
        _context.Manga.Add(manga);
        _context.SaveChanges();
    }

    public void Update(Manga manga)
    {
        _context.Manga.Update(manga);
        _context.SaveChanges();
    }

    public void Delete(Manga manga)
    {
        _context.Manga.Remove(manga);
        _context.SaveChanges();
    }

    public Manga GetById(int id)
    {
        return _context.Manga.Find(id);
    }
}