using DataAccess.Enums;
using DataAccess.Records.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
	public class HobbyModel : RecordBase
	{
		#region Entity Properties
		[Required]
		[StringLength(50)]
		public string Name { get; set; }
		public Genre Genre { get; set; }
		public DateTime releaseDate { get; set; }
		public bool IsPlayed { get; set; }
		public decimal? PlayTime { get; set; }
		public decimal? WatchTime { get; set; }
		public int GamesId { get; set; }

        [DisplayName("Play Time Output")]
        public string? PlayTimeOutput { get; set; } // "2020/04/21"
        #endregion
    }
}
