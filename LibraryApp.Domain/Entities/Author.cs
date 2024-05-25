using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApp.Domain.Entities;

[Table("Author")]
public class Author
{
    [Key]
    public int Id;
    public string? Firstname { get; set; }
    public string? Lastname { get; set; }
    public string? Surname { get; set; }
    public string? DateOfBirth { get; set; }
    
    // Propriétés de navigation représentant la relation entre la table Author et Manga
    public Collection<Manga> Mangas { get; set; }
}