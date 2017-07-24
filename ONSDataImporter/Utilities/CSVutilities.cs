using System;
using System.Collections.Generic;
using System.Text;

namespace ONSDataImporter.Utilities
{
    public static class CSVutilities
    {
        public static string[] SplitLineOfCSV(string inputLine)
        {
            if (inputLine.Contains("\""))
            {
                int positionOfCommaToRemove = inputLine.LastIndexOf(",");
                inputLine = inputLine.Remove(positionOfCommaToRemove, 1);
               
            }

            inputLine = inputLine.Replace(" ", "");
            inputLine = inputLine.Replace("\"", "");

            return inputLine.Split(',');
        }
    }
}
