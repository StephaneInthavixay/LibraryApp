using LibraryApp.Domain.Entities;

namespace LibraryApp.Domain.Services;

// Implémentation de la logique métier
public interface IMangaService
{
    public bool CanBeBorrowed(Manga manga);
    public void IsBorrowed(Manga manga);
    public void IsReturned(Manga manga);
}