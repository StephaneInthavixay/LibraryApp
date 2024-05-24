using System.Collections.ObjectModel;

namespace LibraryApp.Domain.Entities;

public class Author
{
    public int Id;
    public string? Firstname { get; set; }
    public string? Lastname { get; set; }
    public string? Surname { get; set; }
    public string? DateOfBirth { get; set; }
    
    // Propriétés de navigation représentant la relation entre la table Author et Manga
    public Collection<Manga> Mangas { get; set; }
}