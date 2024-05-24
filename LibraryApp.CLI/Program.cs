using LibraryApp.Domain.Interfaces;
using LibraryApp.Domain.Services;
using LibraryApp.Infrastructure.Data;
using LibraryApp.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.CLI;

public class Program
{
    public static void Main(string[] args)
    {
        var serviceProvider = BuildServiceProvider();
        
        Console.WriteLine("Salut");
    }

    private static IServiceProvider BuildServiceProvider()
    {
        var services = new ServiceCollection();

        // Enregistrement des services de l'application
        services.AddDbContext<LibraryAppContext>(options => options.UseSqlite("/Users/stayfan/Library/DBeaverData/workspace6/.metadata/sample-database-sqlite-1/Chinook.db"));
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IMangaRepository, MangaRepository>();
        services.AddScoped<IAuthorRepository, AuthorRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IEditorRepository, EditorRepository>();
        services.AddScoped<IStatusRepository, StatusRepository>();
        
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IMangaService, MangaService>();
        
        // Constructeur du conteneur d'injection de dépendances
        return services.BuildServiceProvider();
    }
}