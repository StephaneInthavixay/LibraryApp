namespace LibraryApp.Domain.Entities;

public class Manga
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int NumberOfVolumesVO { get; set; }
    public int NumberOfVolumesVF { get; set; }
    public int CategoryId { get; set; }
    public int AuthorId { get; set; }
    public int EditorId { get; set; }
    public int StatusId { get; set; }
    public int Stock { get; set; }
    
    // Propriétés de navigation représentant la relation entre la table Manga et les autres tables
    public Category Category { get; set; }
    public Author Author { get; set; }
    public Editor Editor { get; set; }
    public Status Status { get; set; }
}