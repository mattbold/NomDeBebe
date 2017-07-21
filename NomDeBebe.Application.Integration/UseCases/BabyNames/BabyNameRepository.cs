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

        
    }
}
