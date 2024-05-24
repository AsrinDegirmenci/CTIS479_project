using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Contexts
{
    public class Db : DbContext
    {
        public DbSet<Hobby> Hobbies { get; set; }
        public DbSet<Games> Games { get; set; }

        public DbSet<Reviewer> Reviewers { get; set; }

        public DbSet<HobbiesReviewer> HobbiesReviewers { get; set; }


        public Db(DbContextOptions options) : base(options)
        {

        }

    }
}
