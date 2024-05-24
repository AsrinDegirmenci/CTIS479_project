using DataAccess.Enums;
using DataAccess.Records.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable

namespace DataAccess.Entities
{
    public class Hobby : RecordBase
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public Genre Genre { get; set; }
        public DateTime releaseDate { get; set; }
        public bool IsPlayed { get; set; }
        public decimal? PlayTime { get; set; }
        public decimal? WatchTime { get; set; }
        public int GamesId { get; set; } // foreign key
        public Games Games { get; set; }

        public List<HobbiesReviewer> HobbiesReviewers { get; set; }
    }
}
