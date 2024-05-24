using LibraryApp.Domain.Entities;

namespace LibraryApp.Domain.Services;

// Implémentation de la logique métier
public interface IMangaService
{
    public bool CanBeBorrowed(Manga manga);
}