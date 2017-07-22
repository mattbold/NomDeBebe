using System;
using System.Collections.Generic;
using System.Text;

namespace ONSDataImporter.Utilities
{
    public static class CSVutilities
    {
        public static string[] SplitLineOfCSV(string inputLine)
        {
            inputLine = inputLine.Replace(" ", "");

            return inputLine.Split(',');
        }
    }
}
