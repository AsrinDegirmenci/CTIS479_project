using Business.Models;
using Business.Services;
using Business.Services.Bases;
using DataAccess.Contexts;
using DataAccess.Entities;
using DataAccess.Results;
using DataAccess.Results.Bases;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace Business.Services
{
    public interface IReviewerService
    {
        IQueryable<ReviewerModel> Query();
        Result Add(ReviewerModel model);
        Result Update(ReviewerModel model);
        Result Delete(int id);
        List<ReviewerModel> GetList();

        ReviewerModel GetItem(int id);
    }
}

public class ReviewerService : ServiceBase, IReviewerService
{
    public ReviewerService(Db db) : base(db)
    {

    }

    public IQueryable<ReviewerModel> Query() // list, details, edit
    {
        return _db.Reviewers.Include(r => r.HobbiesReviewers).ThenInclude(hr => hr.Hobby)
            .OrderByDescending(x => x.IsReviewing).ThenBy(x => x.ReleaseDate).ThenBy(x => x.Name).ThenBy(x => x.Surname)
            .Select(x => new ReviewerModel()
            {
                ReleaseDate = x.ReleaseDate,
                Id = x.Id,
                IsReviewing = x.IsReviewing,
                Name = x.Name,
                Score = x.Score,
                Surname = x.Surname,

                ReleaseDateOutput = x.ReleaseDate.HasValue ? x.ReleaseDate.Value.ToString("MM/dd/yyyy") : string.Empty,
                IsReviewingOutput = x.IsReviewing ? "Active" : "Not Active",
                ScoreOutput = x.Score.ToString("N1"),
                FullNameOutput = x.Name + " " + x.Surname,

                HobbyIdsInput = x.HobbiesReviewers.Select(po => po.HobbyId).ToList(), // for edit operation
                HobbyNamesOutput = string.Join("<br />", x.HobbiesReviewers.Select(hr => hr.Hobby.Name).ToList())
            });
    }

    public Result Add(ReviewerModel model)
    {
        if (_db.Reviewers.Any(r => r.Name.ToLower() == model.Name.ToLower().Trim() && r.Surname.ToLower() == model.Surname.ToLower().Trim()))
            return new ErrorResult("Reviewer with the same name and surname exists");
        var entity = new Reviewer()
        {
            ReleaseDate = model.ReleaseDate,
            IsReviewing = model.IsReviewing,
            Name = model.Name.Trim(),
            Score = model.Score.Value,
            Surname = model.Surname.Trim(),

            HobbiesReviewers = model.HobbyIdsInput?.Select(hobbyid => new HobbiesReviewer()
            {
                HobbyId = hobbyid
            }).ToList()
        };
        _db.Reviewers.Add(entity);
        _db.SaveChanges();
        model.Id = entity.Id;
        return new SuccessResult("Reviewer Successfully Added!");
    }

    public Result Update(ReviewerModel model)
    {
		if (_db.Reviewers.Any(r => r.Id != model.Id && r.Name.ToLower() == model.Name.ToLower().Trim() && r.Surname.ToLower() == model.Surname.ToLower().Trim()))
			return new ErrorResult("Reviewer with the same name and surname exists");
        var entity = _db.Reviewers.Include(r => r.HobbiesReviewers).SingleOrDefault(r => r.Id == model.Id);
        if (entity == null)
			return new ErrorResult("Reviewer not found!");
        _db.HobbiesReviewers.RemoveRange(entity.HobbiesReviewers);
        entity.ReleaseDate = model.ReleaseDate;
        entity.IsReviewing = model.IsReviewing;
        entity.Name = model.Name.Trim();
        entity.Score = model.Score.Value;
        entity.Surname = model.Surname.Trim();

        entity.HobbiesReviewers = model.HobbyIdsInput?.Select(hobbyid => new HobbiesReviewer()
        {
            HobbyId = hobbyid
        }).ToList();
        _db.Reviewers.Update(entity);
        _db.SaveChanges();
        return new SuccessResult("Reviewer updated successfuly!");
	}

	public Result Delete(int id)
    {
        var entity = _db.Reviewers.Include(r => r.HobbiesReviewers).SingleOrDefault(r => r.Id == id);
        if(entity is null)
            return new ErrorResult("Reviewer not found!");
        _db.HobbiesReviewers.RemoveRange(entity.HobbiesReviewers);
        _db.Reviewers.Remove(entity);
        _db.SaveChanges();
        return new SuccessResult("Reviewer deleted Successfuly!");
    }

    public List<ReviewerModel> GetList() => Query().ToList();


    public ReviewerModel GetItem(int id) => Query().SingleOrDefault(x => x.Id == id);

}
