using LibraryApp.Domain.Entities;

namespace LibraryApp.Domain.Services;

// Implémentation de la logique métier
public interface IUserService
{
    public bool CanBorrow(User user);
}