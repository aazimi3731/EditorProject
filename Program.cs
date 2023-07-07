using EditorProject.Helpers;
using EditorProject.Interfaces;
using EditorProject.Models;
using EditorProject.Models.Interfaces;
using EditorProject.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace EditorProject
{
  internal static class Program
  {
    private const string myRelativePath = nameof(Program) + ".cs";
    private static string GetSourceFilePathName([CallerFilePath] string callerFilePath = null) => callerFilePath ?? "";
    private static string _rootDir;

    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);

      var serviceProvider = CreateHostBuilder(new string[] { }).Build().Services;
      
      var serviceScope = serviceProvider.CreateScope();
      DbInitializer.Seed(serviceScope);

      Application.Run(serviceProvider.GetRequiredService<TextEditorForm>());
    }

    static IHostBuilder CreateHostBuilder(string[] args)
    {
      var builder = Host.CreateDefaultBuilder();

      builder.ConfigureAppConfiguration((context, ConfigBuilder) =>
      {
        var pathName = GetSourceFilePathName();
        _rootDir = pathName.Substring(0, pathName.Length - myRelativePath.Length);

        ConfigBuilder
           .SetBasePath(_rootDir)
           .AddJsonFile("appsettings.json")
           .AddJsonFile($"appsettings.{context.HostingEnvironment.EnvironmentName}.json")
           .AddEnvironmentVariables()
           .SetFileLoadExceptionHandler(x =>
           {
             if (context.HostingEnvironment.IsDevelopment())
             {
               System.Console.WriteLine("an error occured.");
             }
           })
           .Build();
      });

      builder.ConfigureServices((context, services) => {
        services.AddTransient<PersonControl>();
        services.AddTransient<LoginForm>();
        services.AddSingleton<FileConfiguration>();
        services.AddTransient<IPersonRepository, PersonRepository>();
        services.AddTransient<IPersonService, PersonService>();
        services.AddTransient<IFileManipulation, FileManipulation>();
        services.AddTransient<IDocumentHelper, DocumentHelper>();
        services.AddTransient<IPrintManager, PrintManager>();
        services.AddTransient<TextEditorForm>();

        services.AddDbContext<EditorProjectDbContext>(options =>
        {
          options.UseSqlServer(
            context.Configuration.GetConnectionString("EditorProjectDbContextConnection"));
        });
      });

      return builder;
    }
  }
}
