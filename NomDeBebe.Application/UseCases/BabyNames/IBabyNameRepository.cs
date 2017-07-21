using System;
using System.Collections.Generic;
using System.Text;

namespace NomDeBebe.Application.UseCases.BabyNames
{
    public interface IBabyNameRepository
    {
        BabyName GetBabyNameWithYearData(string babyName);

        void ImportBabyNames(List<BabyName>);
    }
}
