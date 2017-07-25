using System;
using System.Collections.Generic;
using System.Text;

namespace NomDeBebe.Application.UseCases.BabyNames
{
    public class BabyName
    {
        public int BabyNameId { get; set; }

        public string Name { get; set; }

        public string Gender { get; set; }

        public List<YearEntry> YearEntries { get; set; }

        public BabyName()
        {
            this.YearEntries = new List<YearEntry>();
        }
    }
}
