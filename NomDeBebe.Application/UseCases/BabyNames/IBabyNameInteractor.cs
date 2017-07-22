using System;
using System.Collections.Generic;
using System.Text;

namespace NomDeBebe.Application.UseCases.BabyNames
{
    public interface IBabyNameInteractor
    {
        GetNameSearchResponse NameSearch(string name);

        void ImportNames(List<BabyName> babyNames);
    }
}
