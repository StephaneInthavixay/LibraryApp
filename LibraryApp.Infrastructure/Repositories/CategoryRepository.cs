using LibraryApp.Domain.Entities;
using LibraryApp.Domain.Interfaces;
using LibraryApp.Infrastructure.Data;

namespace LibraryApp.Infrastructure.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly LibraryAppContext _context;

    // Appel du constructeur dans le conteneur d'injection de dépendances, qui va initialiser le contexte (étant donné qu'il fait partie de son registre)
    public CategoryRepository(LibraryAppContext context)
    {
        _context = context;
    }

    public void Add(Category category)
    {
        _context.Category.Add(category);
        _context.SaveChanges();
    }

    public void Update(Category category)
    {
        _context.Category.Update(category);
        _context.SaveChanges();
    }

    public void Delete(Category category)
    {
        _context.Category.Remove(category);
        _context.SaveChanges();
    }

    public Category GetById(int id)
    {
        return _context.Category.Find(id);
    }
}