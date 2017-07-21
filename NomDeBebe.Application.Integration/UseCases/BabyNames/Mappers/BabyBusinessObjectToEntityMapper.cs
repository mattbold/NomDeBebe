using System;
using System.Collections.Generic;
using System.Text;
using NomDeBebe.Data.Entities;
using NomDeBebe.Application.UseCases.BabyNames;

namespace NomDeBebe.Integration.UseCases.BabyNames.Mappers
{
    public static class BabyBusinessObjectToEntityMapper
    {
        public static Data.Entities.BabyName ConvertFromBusinessObject(Application.UseCases.BabyNames.BabyName bo)
        {
            return new Data.Entities.BabyName
            {
                Id = bo.BabyNameId,
                Name = bo.Name,
                Gender = bo.Gender
            };
        }

        public static IList<YearEntry> ConvertYearEntriesFromEntities(IEnumerable<Data.Entities.YearEntry> yearEntryEntities)
        {
            List<YearEntry> yearEntryList = new List<YearEntry>();

            foreach (var yearEntryEntity in yearEntryEntities)
            {
                yearEntryList.Add(ConvertYearEntryEntityToYearEntryBusinessObject(yearEntryEntity));
            }

            return yearEntryList;
        }

        public static YearEntry ConvertYearEntryEntityToYearEntryBusinessObject(Data.Entities.YearEntry yearEntryEntity)
        {
            var yearEntry = new YearEntry();

            yearEntry.Year = yearEntryEntity.Year;
            yearEntry.NumberInYear = yearEntryEntity.NumberInYear;
            yearEntry.RankInYear = yearEntryEntity.RankInYear;

            return yearEntry;
        }
    }
}
