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

        public string[] linesOfFile { get; set; }

        public FileImporter(string rootFolder, int year, string fileName)
        {
            this.fileName = fileName;
            this.year = year;
        }

        public bool FindAndImportFile()
        {
            LoadFileContents();
            ConvertCSVtoEntities();
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
                
            }

        }
    }
}
