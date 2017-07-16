using System;
using System.Collections.Generic;
using System.Text;

namespace ONSDataImporter
{
    public class FileImporter
    {
        private string rootFolder { get; set; }

        public string fileName { get; set; }

        public int year { get; set; }

        public string fileContents { get; set; }

        private IList<>

        public FileImporter(string rootFolder, int year, string fileName)
        {
            this.fileName = fileName;
            this.year = year;
        }

        public bool FindAndImportFile()
        {
            LoadFileContents();
            ConvertCSVtoEntities()
();
            return true;
        }

        private void LoadFileContents()
        {
            fileContents = System.IO.File.ReadAllText(fileName);
        }

        private void ConvertCSVtoEntities()
        {

        }
    }
}
