using DataAccess.Records.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class HobbiesReviewer : RecordBase
    {
        public int HobbyId { get; set; }

        public Hobby Hobby { get; set; }

        public int ReviewerId { get; set; }

        public Reviewer Reviewer { get; set; }


    }
}
