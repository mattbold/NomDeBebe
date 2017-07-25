using NomDeBebe.Application.UseCases.BabyNames;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NomDeBebe.Integration.UseCases.BabyNames.Mappers
{
    public static class BabyNameEntityToBusinessObjectMapper
    {
        public static BabyName ConvertFromEntity(Data.Entities.BabyName entity)
        {
            return new BabyName
            {
                BabyNameId = entity.Id,
                Name = entity.Name,
                Gender = entity.Gender,
                YearEntries = ConvertYearEntriesFromEntities(entity.YearEntries)
            };
        }

        public static List<YearEntry> ConvertYearEntriesFromEntities(ICollection<Data.Entities.YearEntry> yearEntryEntities)
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
