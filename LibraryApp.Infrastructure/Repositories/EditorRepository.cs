using LibraryApp.Domain.Entities;
using LibraryApp.Domain.Interfaces;
using LibraryApp.Infrastructure.Data;

namespace LibraryApp.Infrastructure.Repositories;

public class EditorRepository : IEditorRepository
{
    private readonly LibraryAppContext _context;

    // Appel du constructeur dans le conteneur d'injection de dépendances, qui va initialiser le contexte (étant donné qu'il fait partie de son registre)
    public EditorRepository(LibraryAppContext context)
    {
        _context = context;
    }

    public void Add(Editor editor)
    {
        _context.Editors.Add(editor);
        _context.SaveChanges();
    }

    public void Update(Editor editor)
    {
        _context.Editors.Update(editor);
        _context.SaveChanges();
    }

    public void Delete(Editor editor)
    {
        _context.Editors.Remove(editor);
        _context.SaveChanges();
    }

    public Editor GetById(int id)
    {
        return _context.Editors.Find(id);
    }
}