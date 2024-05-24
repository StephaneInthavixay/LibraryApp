using System.Collections.ObjectModel;

namespace LibraryApp.Domain.Entities;

public class User
{
    public int Id { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    
    // Clé étrangère
    public int MangaId { get; set; }
    
    // Propriétés de navigation représentant la relation entre la table User et Manga
    public Collection<Manga> Mangas { get; set; }
}