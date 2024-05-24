using LibraryApp.Domain.Entities;

namespace LibraryApp.Application.Services;

public interface ILibrayAppService
{
    public void BorrowManga(int userId, int mangaId);
    public void ReturnManga(int userId, int mangaId);
}