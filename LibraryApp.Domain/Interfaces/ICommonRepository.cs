namespace LibraryApp.Domain.Interfaces;

public interface ICommonRepository <T> where T : class
{
    void Add(T manga);
    void Update(T manga);
    void Delete(T manga);

    T GetById(int id);
}