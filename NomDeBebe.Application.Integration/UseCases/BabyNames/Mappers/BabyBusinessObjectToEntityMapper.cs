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

        public static IList<Application.UseCases.BabyNames.YearEntry> ConvertYearEntriesFromEntities(IEnumerable<Data.Entities.YearEntry> yearEntryEntities)
        {
            List<Application.UseCases.BabyNames.YearEntry> yearEntryList = new List<Application.UseCases.BabyNames.YearEntry>();

            foreach (var yearEntryEntity in yearEntryEntities)
            {
                yearEntryList.Add(ConvertYearEntryEntityToYearEntryBusinessObject(yearEntryEntity));
            }

            return yearEntryList;
        }

        public static Application.UseCases.BabyNames.YearEntry ConvertYearEntryEntityToYearEntryBusinessObject(Data.Entities.YearEntry yearEntryEntity)
        {
            var yearEntry = new Application.UseCases.BabyNames.YearEntry();

            yearEntry.Year = yearEntryEntity.Year;
            yearEntry.NumberInYear = yearEntryEntity.NumberInYear;
            yearEntry.RankInYear = yearEntryEntity.RankInYear;

            return yearEntry;
        }
    }
}
