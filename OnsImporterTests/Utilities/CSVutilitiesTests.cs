using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OnsImporterTests.Utilities
{
    [TestClass]
    public class CSVutilitiesTests
    {
        [TestMethod]
        public void SplitLineOfCSVWorksCorrectlyWithCommaInNumber()
        {
            // Arrange
            string testLine = "1, OLIVER,\"6,941\"";

            // Act
            var result = ONSDataImporter.Utilities.CSVutilities.SplitLineOfCSV(testLine);

            // Assert
            Assert.AreEqual("1", result[0]);
            Assert.AreEqual("OLIVER", result[1]);
            Assert.AreEqual("6941", result[2]);
        }

        [TestMethod]
        [Ignore]
        public void SplitLineOfCSVWorksCorrectlyWithoutCommaInNumber()
        {
            // Arrange
            string testLine = "1, OLIVER,\"6941\"";

            // Act
            var result = ONSDataImporter.Utilities.CSVutilities.SplitLineOfCSV(testLine);

            // Assert
            Assert.AreEqual("1", result[0]);
            Assert.AreEqual("OLIVER", result[1]);
            Assert.AreEqual("6941", result[2]);
        }
    }
}
