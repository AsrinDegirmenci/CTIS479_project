#nullable disable
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
    public class ReviewerModel: RecordBase
    {
        #region Entity Properties
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(50, ErrorMessage = "{0} must be maximum {1} characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [StringLength(50, ErrorMessage = "{0} must be maximum {1} characters")]
        public string Surname { get; set; }

        [DisplayName("Release Date")]
        public DateTime? ReleaseDate { get; set; }

        [DisplayName("Active")]
        public bool IsReviewing { get; set; } // if user is using the system or not

		[Required(ErrorMessage = "{0} is required")]
		[Range(0, 100, ErrorMessage = "{0} must be between {1} and {2}!")]
        public decimal? Score { get; set; } // score for their reviews
        #endregion

        #region Extra Properties
        [DisplayName("Hobbies")]
        public List<int> HobbyIdsInput { get; set; }

        [DisplayName("Release Date")]
        public string ReleaseDateOutput { get; set; } // "2020/04/21"

        [DisplayName("Active")]
        public string IsReviewingOutput { get; set; } // "active" or "not active"

        [DisplayName("Score")]
        public  string ScoreOutput { get; set; } // "1.2532"

        [DisplayName("Full Name")]
        public string FullNameOutput { get; set; } // "Asrin Degirmenci"

		[DisplayName("Hobby Names")]
		public string HobbyNamesOutput { get; set; }
        #endregion
    }
}
