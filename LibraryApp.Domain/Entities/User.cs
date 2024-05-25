using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApp.Domain.Entities;

[Table("User")]
public class User
{
    [Key]
    public int Id { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    
    // Clé étrangère
    public int MangaId { get; set; }
    
    // Propriétés de navigation représentant la relation entre la table User et Manga
    public Collection<Manga> Mangas { get; set; }
}