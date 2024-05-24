using LibraryApp.Domain.Entities;

namespace LibraryApp.Domain.Services;

// Implémentation de l'interface logique métier
public class UserService : IUserService
{
    public bool CanBorrow(User user)
    {
        return user.Mangas.Count <= 10;
    }

    public void BorrowManga(User user, Manga manga)
    {
        user.Mangas.Add(manga);
    }

    public void ReturnManga(User user, Manga manga)
    {
        user.Mangas.Remove(manga);
    }
}