using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NomDeBebe.Data.Entities
{
    public class BabyName
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Gender { get; set; }

        public ICollection<YearEntry> YearEntries { get; set; } = new List<YearEntry>();
    }
}
