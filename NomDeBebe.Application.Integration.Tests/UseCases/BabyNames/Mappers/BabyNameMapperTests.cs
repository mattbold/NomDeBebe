using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using NomDeBebe.Integration.UseCases.BabyNames.Mappers;
using NomDeBebe.Data;
using NomDeBebe.Application;
using NomDeBebe.Data.Entities;

namespace NomDeBebe.IntegrationTests.UseCases.BabyNames
{
    [TestClass]
    public class BabyNameMapperTests
    {
        [TestMethod]
        public void AssertThatBabyNameEntityMapsToBabyNameBusinessObject()
        {
            // Arrange
            var babyNameEntity = GetBabyEntity();

            // Act
            var result = BabyNameEntityToBusinessObjectMapper.ConvertFromEntity(babyNameEntity);

            // Assert
            Assert.AreEqual("Seth", result.Name);
            Assert.AreEqual("M", result.Gender);
            Assert.AreEqual(1, result.BabyNameId);
        }

        [TestMethod]
        public void AssertThatConvertYearEntryEntityToYearEntryBusinessObject()
        {
            // Arrange
            var yearEntryEntity = new YearEntry { BabyNameId = 1, Year = 2016, NumberInYear = 10, RankInYear = 1 };

            // Act
            var result = BabyNameEntityToBusinessObjectMapper.ConvertYearEntryEntityToYearEntryBusinessObject(yearEntryEntity);

            // Assert
            Assert.AreEqual(2016, result.Year);
            Assert.AreEqual(10, result.NumberInYear);
            Assert.AreEqual(1, result.RankInYear);
        }

        [TestMethod]
        public void AssertThatConvertYearEntriesFromEntitiesMapsToYearEntryBusinessObject()
        {
            // Arrange
            var yearEntryEntities = GetYearEntryEntities();

            // Act
            var result = BabyNameEntityToBusinessObjectMapper.ConvertYearEntriesFromEntities(yearEntryEntities);

            // Assert
            Assert.AreEqual(2, result.Count);

            Assert.AreEqual(2016, result[0].Year);
            Assert.AreEqual(10, result[0].NumberInYear);
            Assert.AreEqual(1, result[0].RankInYear);

            Assert.AreEqual(2015, result[1].Year);
            Assert.AreEqual(4, result[1].NumberInYear);
            Assert.AreEqual(2, result[1].RankInYear);
        }

        private BabyName GetBabyEntity()
        {
            return new BabyName { Name = "Seth", Gender = "M", Id = 1 };
        }

        private IEnumerable<YearEntry> GetYearEntryEntities()
        {
            List<YearEntry> yearEntryList = new List<YearEntry>();

            yearEntryList.Add(new YearEntry { BabyNameId = 1, Year = 2016, NumberInYear = 10, RankInYear = 1 });
            yearEntryList.Add(new YearEntry { BabyNameId = 1, Year = 2015, NumberInYear = 4, RankInYear = 2 });

            return yearEntryList;
        }
    }
}
