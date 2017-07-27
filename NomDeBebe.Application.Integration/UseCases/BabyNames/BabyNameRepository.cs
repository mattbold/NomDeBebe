using System;
using System.Collections.Generic;
using System.Text;
using NomDeBebe.Application;
using NomDeBebe.Application.UseCases.BabyNames;
using NomDeBebe.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace NomDeBebe.Integration.UseCases.BabyNames
{
    public class BabyNameRepository : IBabyNameRepository
    {
        private readonly BebeContext context;

        public BabyNameRepository(BebeContext context)
        {
            this.context = context
        }

        public BabyName GetBabyNameWithYearData(string babyName)
        {
            var returnedName = context.BabyNames
                .Include(b => b.YearEntries)
                .FirstOrDefault(b => b.Name == babyName);

            return Mappers.BabyNameEntityToBusinessObjectMapper.ConvertFromEntity(returnedName);
        }

        public void ImportBabyNames(List<BabyName> babyNames)
        {
            foreach (var babyName in babyNames)
            {
                if (BabyNameExistsInDatabaseAlready(babyName.Name))
                {
                    InsertNewYearData(babyName);
                }
                else
                {
                    InsertBabyName(babyName);
                }
            }
        }

        public bool BabyNameExistsInDatabaseAlready(string babyName)
        {
            if(context.BabyNames.Count(b => b.Name.ToLower() == babyName.ToLower()) > 0)
            {
                return true;
            }

            return false;
        }

        public void InsertNewYearData(BabyName babyName)
        {
            var babyNameEntity = context.BabyNames.FirstOrDefault(b => b.Name == babyName.Name);

            babyNameEntity.YearEntries.Add(new Data.Entities.YearEntry { Year = babyName.YearEntries[0].Year, NumberInYear = babyName.YearEntries[0].NumberInYear, RankInYear = babyName.YearEntries[0].RankInYear });

            this.context.Update(babyNameEntity);
            this.context.SaveChanges();
        }

        public void InsertBabyName(BabyName babyName)
        {
            var entity = Integration.UseCases.BabyNames.Mappers.BabyBusinessObjectToEntityMapper.ConvertFromBusinessObject(babyName);
            this.context.BabyNames.Add(entity);
            this.context.SaveChanges();
        }
    }
}
