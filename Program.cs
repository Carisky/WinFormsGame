using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WinFormsGame.db;
using WinFormsGame.db.models;
using WinFormsGame.db.repositories;
using WinFormsGame.db.services;

namespace WinFormsGame
{
    internal static class Program
    {
        public static ServiceProvider ServiceProvider { get; private set; }
        public static User CurrentUser { get; set; }
        [STAThread]
        static void Main()
        {
            var services = new ServiceCollection();

            // Register the AppDbContext with a connection string
            services.AddDbContext<AppDbContext>(options =>
                options.UseMySql("Server=localhost;Database=game;User=myuser;Password=rootpassword;", ServerVersion.AutoDetect("Server=localhost;Database=game;User=myuser;Password=rootpassword;"))
            );

            // Register other services
            services.AddScoped<UserRepository>();
            services.AddScoped<UserService>();
            services.AddScoped<Form1>();
            services.AddScoped<Form2>();
            services.AddScoped<Form3>();
            // Build the service provider
            ServiceProvider = services.BuildServiceProvider();

            // Start the application with Form2
            ApplicationConfiguration.Initialize();
            var form2 = ServiceProvider.GetRequiredService<Form2>();
            Application.Run(form2);
        }
    }
}
