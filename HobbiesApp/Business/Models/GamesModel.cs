using DataAccess.Records.Bases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#nullable disable

namespace Business.Models
{
    public class GamesModel : RecordBase
    {
        #region Entity Properties
        [Required(ErrorMessage = "{0} is required")]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "{0} must be minimum {2} and maximum {1} characters")]
        [DisplayName("Games Name")]
        public string Name { get; set; }
        #endregion

        #region Extra Properties
        [DisplayName("Game Count")]
        public int GameCountOutput { get; set; }

        [DisplayName ("Game Names")]
        public string GameNamesOutput { get; set; }
        #endregion
    }
}
