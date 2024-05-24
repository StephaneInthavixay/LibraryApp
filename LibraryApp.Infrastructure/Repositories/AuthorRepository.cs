using LibraryApp.Domain.Entities;
using LibraryApp.Domain.Interfaces;
using LibraryApp.Infrastructure.Data;

namespace LibraryApp.Infrastructure.Repositories;

public class AuthorRepository : IAuthorRepository
{
    private readonly LibraryAppContext _context;

    // Appel du constructeur dans le conteneur d'injection de dépendances, qui va initialiser le contexte (étant donné qu'il fait partie de son registre)
    public AuthorRepository(LibraryAppContext context)
    {
        _context = context;
    }

    public void Add(Author author)
    {
        _context.Authors.Add(author);
        _context.SaveChanges();
    }

    public void Update(Author author)
    {
        _context.Authors.Update(author);
        _context.SaveChanges();
    }

    public void Delete(Author author)
    {
        _context.Authors.Remove(author);
        _context.SaveChanges();
    }

    public Author GetById(int id)
    {
        return _context.Authors.Find(id);
    }
}