using Business.Models;
using Business.Services.Bases;
using DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
	public interface IHobbyService
	{
		IQueryable<HobbyModel> Query();
        HobbyModel GetItem(int id);

    }
    public class HobbyService : ServiceBase, IHobbyService
	{
		public HobbyService(Db db) : base(db)
		{
		}

        public HobbyModel GetItem(int id) => Query().SingleOrDefault(x => x.Id == id);


        public IQueryable<HobbyModel> Query()
		{
			return _db.Hobbies.Include(h => h.HobbiesReviewers).Include(h => h.Games).OrderBy(h => h.Name).Select(h => new HobbyModel()
			{
				releaseDate = h.releaseDate,
				Genre = h.Genre,
				Id = h.Id,
				IsPlayed = h.IsPlayed,
				Name = h.Name,
				GamesId = h.GamesId,
				PlayTime = h.PlayTime,
				WatchTime = h.WatchTime,
			});
		}
	}
}
