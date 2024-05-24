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
    public class Games : RecordBase
    {
        [Required]
        [StringLength(40)]
        public string Name { get; set; }
        public List<Hobby> Hobbies { get; set; }
    }
}
