#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models
{
    public class FavoriteModel
    {
        public int GameId { get; set; }

        [DisplayName("User Name")]
        public string UserName { get; set; }

        [DisplayName("Game Name")]
        public string GameName { get; set; }

        public decimal? Playtime { get; set; }

        [DisplayName("Total Play Time")]
        public string PlaytimeOutput { get; set; }
    }
}

