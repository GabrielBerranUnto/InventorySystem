using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using InventorySystem.Data;
using InventorySystem;
using System.Windows;

public partial class App : Application
{
    private readonly ServiceProvider _serviceProvider;

    public App()
    {
        var services = new ServiceCollection();

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer("YourConnectionStringHere"));

        _serviceProvider = services.BuildServiceProvider();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        using (var scope = _serviceProvider.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            DbInitializer.Seed(db);

            var login = new LoginWindow(db);
            login.Show();
        }

        base.OnStartup(e);
    }
}
