using LibraryApp.Domain.Interfaces;
using LibraryApp.Domain.Services;

namespace LibraryApp.Application.Services;

public class LibraryAppService : ILibrayAppService
{
    private readonly IUserRepository _userRepository;
    private readonly IMangaRepository _mangaRepository;

    private readonly IUserService _userService;
    private readonly IMangaService _mangaService;

    // Appel du constructeur dans le conteneur d'injection de dépendances, qui va initialiser les champs (étant donné qu'il fait partie de son registre)
    public LibraryAppService(IUserRepository userRepository, IMangaRepository mangaRepository, IUserService userService, IMangaService mangaService)
    {
        _userRepository = userRepository;
        _mangaRepository = mangaRepository;
        _userService = userService;
        _mangaService = mangaService;
    }

    // Emprunt d'un manga
    public void BorrowManga(int userId, int mangaId)
    {
        var user = _userRepository.GetById(userId);
        if (user == null)
            throw new InvalidOperationException("The user doesn't exist.");

        if (!_userService.CanBorrow(user))
            throw new InvalidOperationException("The user cannot borrow books due to overdue items.");
        
        var manga = _mangaRepository.GetById(mangaId);
        if (manga == null)
            throw new InvalidOperationException("The manga doesn't exist.");

        if (!_mangaService.CanBeBorrowed(manga))
            throw new InvalidOperationException("The manga is not available for borrowing.");
        
        _userService.BorrowManga(user, manga);
        _mangaService.IsBorrowed(manga);
    }

    // Retour d'un manga
    public void ReturnManga(int userId, int mangaId)
    {
        var user = _userRepository.GetById(userId);
        if (user == null)
            throw new InvalidOperationException("The user doesn't exist.");
        
        var manga = _mangaRepository.GetById(mangaId);
        if (manga == null)
            throw new InvalidOperationException("The manga doesn't exist.");

        if (!user.Mangas.Contains(manga))
            throw new InvalidOperationException("The user didn't borrow this manga.");
        
        _userService.ReturnManga(user, manga);
        _mangaService.IsReturned(manga);
    }
}