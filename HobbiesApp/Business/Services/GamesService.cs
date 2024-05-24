using Business.Models;
using Business.Services.Bases;
using DataAccess.Contexts;
using DataAccess.Entities;
using DataAccess.Results;
using DataAccess.Results.Bases;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public interface IGamesService 
    {
        IQueryable<GamesModel> Query();
        Result Add(GamesModel model);
        Result Update(GamesModel model);
        Result Delete(int id);
    }
    public class GamesService : ServiceBase, IGamesService
    {
        public GamesService(Db db) : base(db)
        {

        }

        // Read
        public IQueryable<GamesModel> Query() // ToList,SingleOrDefault,FirstOfDefault, Where, Any,etc.
        {
            return _db.Games.Include(g => g.Hobbies).OrderBy(g => g.Name).Select(g => new GamesModel()
            {
                Id = g.Id,
                Name = g.Name,

                GameCountOutput = g.Hobbies.Count,
                GameNamesOutput = string.Join("<br />", g.Hobbies.OrderByDescending(h => h.IsPlayed).ThenByDescending(h => h.releaseDate).ThenBy(h => h.Name).Select(h => h.Name)),
            });
        }

        // Create
        public Result Add(GamesModel model)
        {
            if (_db.Games.Any(g => g.Name.ToLower() == model.Name.ToLower().Trim())) // Action = action (case sensitive)
                return new ErrorResult("Games with the same name alredy exists!");
            Games entity = new Games()
            {
                Name = model.Name.Trim()
            };
            _db.Games.Add(entity);
            _db.SaveChanges();
            return new SuccessResult("Games added successfully!");
        }

        // Update
        public Result Update(GamesModel model)
        {
            if (_db.Games.Any(g => g.Id != model.Id && g.Name.ToLower() == model.Name.ToLower().Trim())) 
                return new ErrorResult("Games with the same name alredy exists!");
            // Way 1
            // Games entity = _db.Games.SingleOrDefault(g => g.Id == model.Id);
            Games entity = _db.Games.Find( model.Id);
            if (entity == null)
                return new ErrorResult("Games not found!");
            entity.Name = model.Name.Trim();
            _db.Games.Update(entity);
            _db.SaveChanges();
            return new SuccessResult("Games updated successfully!");
        }

        // Delete
        public Result Delete(int id)
        {
            Games entity = _db.Games.Include(g => g.Hobbies).SingleOrDefault(g => g.Id == id);
            if (entity == null)
                return new ErrorResult("Games not found");

            if (entity.Hobbies is not null && entity.Hobbies.Any()) // if (entity.Hobbies is not null && entity.Hobbies.Count > 0)
                return new ErrorResult("Games cannot be deleted because it has relational games!");

            _db.Games.Remove(entity);
            _db.SaveChanges();
            return new SuccessResult("Games deleted successfully!");
        }
    }
}
