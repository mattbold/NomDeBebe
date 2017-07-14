using System;
using System.Collections.Generic;
using System.Text;

namespace ONSDataImporter
{
    public class FileImporter
    {
        private string rootFolder { get; set; }

        public FileImporter(string rootFolder)
        {
            this.rootFolder = rootFolder;
        }

        public bool ImportFile()
        {
            return true;
        }
    }
}
