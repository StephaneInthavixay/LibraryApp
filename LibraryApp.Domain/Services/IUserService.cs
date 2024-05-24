using LibraryApp.Domain.Entities;

namespace LibraryApp.Domain.Services;

// Implémentation de la logique métier
public interface IUserService
{
    public bool CanBorrow(User user);
    public void BorrowManga(User user, Manga manga);
    public void ReturnManga(User user, Manga manga);
}