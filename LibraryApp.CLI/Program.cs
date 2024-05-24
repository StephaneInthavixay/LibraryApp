using LibraryApp.Infrastructure.Data;
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
        // Classe ServiceCollection = enregistrement des services de l'application
        var services = new ServiceCollection();

        services.AddDbContext<LibraryAppContext>(options => options.UseSqlite("/Users/stayfan/Library/DBeaverData/workspace6/.metadata/sample-database-sqlite-1/Chinook.db"));
        
        // Constructeur du conteneur d'injection de dépendances
        return services.BuildServiceProvider();
    }
}