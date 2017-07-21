using System;
using NomDeBebe.Application.UseCases.BabyNames;
using NomDeBebe.Integration.UseCases.BabyNames;
using Microsoft.Extensions.DependencyInjection;

namespace ONSDataImporter
{
    class Program
    {
        public static int Year { get; set; }

        public static string Gender { get; set; }

        public static string fileName { get; set; }

        public static string folderRoot { get; set; }


        static void Main(string[] args)
        {
            //setup our DI
            var serviceProvider = new ServiceCollection()
                .AddLogging()
                .AddSingleton<IBabyNameRepository, BabyNameRepository>()
                .AddSingleton<IBabyNameInteractor, BabyNameInteractor>()
                .BuildServiceProvider();
            
            GetUserInputs();

            folderRoot = @"C:\Imports\";

            var interactor = serviceProvider.GetService<IBabyNameInteractor>();

            var fileImporter = new FileImporter(Year, Gender, fileName, interactor);

        }

        public static void GetUserInputs()
        {
            Console.WriteLine("Please enter the filename");
            fileName = Console.ReadLine();

            Console.WriteLine("Please enter the year for the file");
            Year = int.Parse(Console.ReadLine());

            Console.WriteLine("Please enter gender for the file");
            Gender = Console.ReadLine();
        }
    }
}