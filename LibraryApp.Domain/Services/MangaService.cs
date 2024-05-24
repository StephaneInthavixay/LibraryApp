using LibraryApp.Domain.Entities;

namespace LibraryApp.Domain.Services;

// Implémentation de l'interface de la logique métier
public class MangaService : IMangaService
{
    public bool CanBeBorrowed(Manga manga)
    {
        return manga.Stock > 0;
    }

    public void IsBorrowed(Manga manga)
    {
        manga.Stock--;
    }

    public void IsReturned(Manga manga)
    {
        manga.Stock++;
    }
}