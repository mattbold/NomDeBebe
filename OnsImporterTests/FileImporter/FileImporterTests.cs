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
        public void ImportFileReturnsTrue()
        {
            // Arrange
            var importer = new ONSDataImporter.FileImporter("");

            // Act
            var result = importer.ImportFile();

            // Assert
            Assert.AreEqual(true, result);
        }
    }
}
