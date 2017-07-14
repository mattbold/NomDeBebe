using System;
using System.Collections.Generic;
using System.Text;

namespace NomDeBebe.Application.UseCases.BabyNames
{
    public class BabyName
    {
        public int BabyNameId { get; set; }

        public string Name { get; set; }

        public ICollection<YearEntry> YearEntries { get; set; }
    }
}
