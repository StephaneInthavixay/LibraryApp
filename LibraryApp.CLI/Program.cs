using LibraryApp.Application.Services;
using LibraryApp.Domain.Interfaces;
using LibraryApp.Domain.Services;
using LibraryApp.Infrastructure.Data;
using LibraryApp.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace LibraryApp.CLI;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Hello");
        var serviceProvider = BuildServiceProvider();
        
        /*
         * Les injections de dépendances de l'objet de type LibraryAppService sont gérées automatiquement par le conteneur d'injection de dépendances (DI Container) lorsque la méthode GetService<ILibraryAppService> est appelée.
         * De ce fait, ses champs ne seront pas nuls, même si aucun constructeur explicite n'a été appelé pour les initialiser directement.
         * A l'appel de la méthode, le DI Container recherche une implémentation appropriée de ILibraryAppService dans son registre.
         * Lorsqu'il trouve une implémentation, il l'instancie automatiquement et résout toutes ses dépendances, en injectant les instances appropriées.
         * Dans le cas ici, LibraryAppService est l'implémentation de ILibraryAppService et donc, quand la méthode GetService<ILibraryAppService> est appelée, le DI Container va créer une nouvelle instance de LibraryAppService.
         * Pour créer cette instance, le DI Container va examiner le constructeur de LibraryAppService pour voir quelles dépendances doivent être fournies.
         * Il remarque que LibraryAppService nécessite plusieurs dépendances : IUserRepository, IMangaRepository, IUserService et IMangaService.
         * Ensuite, le DI Container va rechercher dans son registre les implémentations appropriées de ces interfaces (UserRepository, MangaRepository, UserService et MangaService), les instancier, si nécessaire, et les injecter dans le constructeur de LibraryAppService, lors de sa création.
         * Donc, lorsque la méthode GetService<ILibraryAppService>() est appelée, le DI Container s'occupe automatiquement de l'initialisation de LibraryAppService en injectant ses dépendances requises, ce qui fait que ses champs ne seront pas nuls lors de l'utilisation de libraryAppService.
         * Si plusieurs constructeurs sont définis, le DI Container utilisera généralement celui avec le plus grand nombre de paramètres pour lesquels il peut résoudre des dépendances.
         */
        var libraryAppService = serviceProvider.GetService<ILibraryAppService>();
        
        libraryAppService.BorrowManga(1, 1);
        Console.WriteLine("Salut");
    }

    private static IServiceProvider BuildServiceProvider()
    {
        var services = new ServiceCollection();

        // Enregistrement des services de l'application
        services.AddDbContext<LibraryAppContext>(options => 
            options.UseSqlite("Data Source=/Users/stayfan/Library/DBeaverData/workspace6/.metadata/sample-database-sqlite-1/Chinook.db"));
        
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IMangaRepository, MangaRepository>();
        services.AddScoped<IAuthorRepository, AuthorRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IEditorRepository, EditorRepository>();
        services.AddScoped<IStatusRepository, StatusRepository>();
        
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IMangaService, MangaService>();
        services.AddScoped<ILibraryAppService, LibraryAppService>();
        
        // Constructeur du conteneur d'injection de dépendances
        return services.BuildServiceProvider();
    }
}