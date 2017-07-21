using System;
using System.Collections.Generic;
using System.Text;
using NomDeBebe.Application.UseCases.BabyNames;

namespace ONSDataImporter
{
    public class FileImporter
    {
        private IBabyNameInteractor babyNameInteractor;

        const int rankColumnIndex = 0;

        const int nameColumnIndex = 1;

        const int numberColumnIndex = 2;


        private string rootFolder { get; set; }

        public string fileName { get; set; }

        public int year { get; set; }

        public string gender { get; set; }

        public string[] linesOfFile { get; set; }

        public List<BabyName> babyNamesForImport = new List<BabyName>();

        public FileImporter(int year, string gender, string fileName, IBabyNameInteractor babyNameInteractor)
        {
            this.fileName = fileName;
            this.year = year;
            this.gender = gender;
            this.babyNameInteractor = babyNameInteractor;
        }

        public bool FindAndImportFile()
        {
            LoadFileContents();
            ConvertCSVtoEntities();
            SaveData();
            return true;
        }

        private void LoadFileContents()
        {
            //Think we want to open this file and read into streamreader really.
            var linesOfFile = System.IO.File.ReadAllLines(fileName);
        }

        private void ConvertCSVtoEntities()
        {
            const int startOnLine = 1;

            for(int i = startOnLine; i < linesOfFile.Length; i++)
            {
                var babyName = new BabyName();

                string[] lineContent = linesOfFile[i].Split(',');

                babyName.Name = lineContent[nameColumnIndex];
                babyName.Gender = this.gender;

                YearEntry newYearEntry = new YearEntry();
                newYearEntry.Year = this.year;
                newYearEntry.RankInYear = lineContent[rankColumnIndex];
                newYearEntry.NumberInYear = lineContent[numberColumnIndex];

                babyName.YearEntries.Add(newYearEntry);

                babyNamesForImport.Add(babyName);
            }

        }
    }
}
