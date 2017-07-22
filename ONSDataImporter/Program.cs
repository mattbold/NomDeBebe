using System;
using NomDeBebe.Application.UseCases.BabyNames;
using NomDeBebe.Integration.UseCases.BabyNames;
using Microsoft.Extensions.DependencyInjection;
using NomDeBebe.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace ONSDataImporter
{
    class Program
    {
        public static int Year { get; set; }

        public static string Gender { get; set; }

        public static string fileName { get; set; }

        public static string folderRoot { get; set; }

        public static IConfigurationRoot Configuration { get; set; }

        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
              .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("appsettings.json");

            Configuration = builder.Build();

            //setup our DI
            var serviceProvider = new ServiceCollection()
                .AddLogging()
                .AddDbContext<BebeContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("NomDeBebe.Data")))
                .AddSingleton<IBabyNameRepository, BabyNameRepository>()
                .AddSingleton<IBabyNameInteractor, BabyNameInteractor>()
                .BuildServiceProvider();
            
            GetUserInputs();

            folderRoot = @"C:\Imports\";

            var interactor = serviceProvider.GetService<IBabyNameInteractor>();

            var fileImporter = new FileImporter(Year, Gender, fileName, interactor);

            fileImporter.FindAndImportFile();

            Console.WriteLine("All done!");
            Console.ReadLine();
        }

        public static void GetUserInputs()
        {
            Console.WriteLine("Please enter the filename");
            fileName = Console.ReadLine();

            Console.WriteLine("Please enter the year for the file");
            Year = int.Parse(Console.ReadLine());

            Console.WriteLine("Please enter gender for the file");
            Gender = Console.ReadLine();

            Console.WriteLine("OK thanks, working on that now..");
        }
    }
}