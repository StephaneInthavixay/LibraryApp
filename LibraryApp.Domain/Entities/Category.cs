using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace LibraryApp.Domain.Entities;

public class Category
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    
    // Propriétés de navigation représentant la relation entre la table Category et Manga
    public Collection<Manga> Mangas { get; set; }
}