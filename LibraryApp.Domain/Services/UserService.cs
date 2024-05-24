using LibraryApp.Domain.Entities;

namespace LibraryApp.Domain.Services;

// Implémentation de l'interface logique métier
public class UserService : IUserService
{
    public bool CanBorrow(User user)
    {
        return user.Mangas.Count <= 10;
    }
}