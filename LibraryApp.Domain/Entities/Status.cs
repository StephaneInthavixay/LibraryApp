using System.Collections.ObjectModel;

namespace LibraryApp.Domain.Entities;

public class Status
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    // Propriétés de navigation représentant la relation entre la table Status et Manga
    public Collection<Manga> Mangas { get; set; }
}