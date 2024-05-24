#nullable disable
using DataAccess.Records.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class Reviewer : RecordBase // User Entity
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Surname { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public bool IsReviewing { get; set; } // if user is using the system or not

        public decimal Score { get; set; } // score for their reviews

        public List<HobbiesReviewer> HobbiesReviewers { get; set; }

    }
}
