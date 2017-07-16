using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OnsImporterTests.FileImporter
{
    [TestClass]
    public class FileImporterTests
    {
        [TestMethod]
        public void ImportFileLoadsFile()
        {
            // Arrange
            var importer = new ONSDataImporter.FileImporter("",2015, @"C:\Temp\boys 2015.csv");

            // Act
            var result = importer.FindAndImportFile();

            // Assert
            Assert.AreEqual("Rank", importer.fileContents.Substring(0,4));
        }
    }
}
