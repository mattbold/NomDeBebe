using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NomDeBebe.Data.Entities
{
    public class YearEntry
    {
        [key]
        public int Id { get; set; }

        [Required]
        public int Year { get; set; }
        [Required]
        public int NumberInYear { get; set; }
        [Required]
        public int RankInYear { get; set; }

      
        public int BabyNameId { get; set; }

        [ForeignKey("BabyNameId")]
        public BabyName BabyName { get; set; }
    }
}
