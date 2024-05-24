using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace LibraryApp.Domain.Entities;

public class Editor
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public int YearOfBirth { get; set; }
    
    // Propriétés de navigation représentant la relation entre la table Editor et Manga
    public Collection<Manga> Mangas { get; set; }
}