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

        public static IList<Data.Entities.YearEntry> ConvertYearEntriesBusinessObjectsToEntities(IEnumerable<Application.UseCases.BabyNames.YearEntry> yearEntryBos)
        {
            List<Data.Entities.YearEntry> yearEntryList = new List<Data.Entities.YearEntry>();

            foreach (var yearEntryBo in yearEntryBos)
            {
                yearEntryList.Add(ConvertYearEntryBusinessObjectToEntity(yearEntryBo));
            }

            return yearEntryList;
        }

        public static Data.Entities.YearEntry ConvertYearEntryBusinessObjectToEntity(Application.UseCases.BabyNames.YearEntry yearEntryBo)
        {
            var yearEntryEntity = new Data.Entities.YearEntry();

            yearEntryEntity.Year = yearEntryBo.Year;
            yearEntryEntity.NumberInYear = yearEntryBo.NumberInYear;
            yearEntryEntity.RankInYear = yearEntryBo.RankInYear;

            return yearEntryEntity;
        }
    }
}
