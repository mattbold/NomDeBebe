using System;
using System.Collections.Generic;
using System.Text;
using NomDeBebe.Application;
using NomDeBebe.Application.UseCases.BabyNames;
using NomDeBebe.Data;
using System.Linq;

namespace NomDeBebe.Integration.UseCases.BabyNames
{
    public class BabyNameRepository : IBabyNameRepository
    {
        private readonly BebeContext context;

        public BabyNameRepository(BebeContext context)
        {
            this.context = context;
        }

        public BabyName GetBabyNameWithYearData(string babyName)
        {
            var returnedName = context.BabyNames.FirstOrDefault(b => b.Name == babyName);

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
            if(context.BabyNames.Count(b => b.Name == babyName) > 1)
            {
                return true;
            }

            return false;
        }

        public void InsertNewYearData(BabyName babyName)
        {
            throw new NotImplementedException();
        }

        public void InsertBabyName(BabyName babyName)
        {
            var entity = Integration.UseCases.BabyNames.Mappers.BabyBusinessObjectToEntityMapper.ConvertFromBusinessObject(babyName);
            this.context.BabyNames.Add(entity);
            this.context.SaveChanges();
        }
    }
}
