using System;
using System.Collections.Generic;
using System.Text;

namespace NomDeBebe.Application.UseCases.BabyNames
{
    public interface IBabyNameInteractor
    {
        GetNameSearchResponse NameSearch(string name);

        bool ImportNames(List<BabyName> babyNames);
    }
}
