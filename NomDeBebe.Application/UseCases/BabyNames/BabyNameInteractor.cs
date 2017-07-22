using System;
using System.Collections.Generic;
using System.Text;

namespace NomDeBebe.Application.UseCases.BabyNames
{
    public class BabyNameInteractor : IBabyNameInteractor
    {

        private readonly IBabyNameRepository babyNameRepository;

        public BabyNameInteractor(IBabyNameRepository babyNameRepository)
        {
            this.babyNameRepository = babyNameRepository;
        }

        public GetNameSearchResponse NameSearch(string name)
        {
            GetNameSearchResponse response = new GetNameSearchResponse();

            response.BabyName = this.babyNameRepository.GetBabyNameWithYearData(name);

            return response;
        }

        public void ImportNames(List<BabyName> babyNames)
        {
            this.babyNameRepository.ImportBabyNames(babyNames);
        }
    }
}
