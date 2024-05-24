using LibraryApp.Domain.Entities;
using LibraryApp.Domain.Interfaces;
using LibraryApp.Infrastructure.Data;

namespace LibraryApp.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly LibraryAppContext _context;

    // Appel du constructeur dans le conteneur d'injection de dépendances, qui va initialiser le contexte (étant donné qu'il fait partie de son registre)
    public UserRepository(LibraryAppContext context)
    {
        _context = context;
    }

    public void Add(User user)
    {
        _context.User.Add(user);
        _context.SaveChanges();
    }

    public void Update(User user)
    {
        _context.User.Update(user);
        _context.SaveChanges();
    }

    public void Delete(User user)
    {
        _context.User.Remove(user);
        _context.SaveChanges();
    }

    public User GetById(int id)
    {
        return _context.User.Find(id);
    }
}