using LibraryApp.Domain.Entities;
using LibraryApp.Domain.Interfaces;
using LibraryApp.Infrastructure.Data;

namespace LibraryApp.Infrastructure.Repositories;

public class StatusRepository : IStatusRepository
{
    private readonly LibraryAppContext _context;

    // Appel du constructeur dans le conteneur d'injection de dépendances, qui va initialiser le contexte (étant donné qu'il fait partie de son registre)
    public StatusRepository(LibraryAppContext context)
    {
        _context = context;
    }

    public void Add(Status status)
    {
        _context.Status.Add(status);
        _context.SaveChanges();
    }

    public void Update(Status status)
    {
        _context.Status.Update(status);
        _context.SaveChanges();
    }

    public void Delete(Status status)
    {
        _context.Status.Remove(status);
        _context.SaveChanges();
    }

    public Status GetById(int id)
    {
        return _context.Status.Find(id);
    }
}