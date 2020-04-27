using CS321_W4D2_ExerciseLogAPI.Core.Models;
using CS321_W4D2_ExerciseLogAPI.Core.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS321_W4D2_ExerciseLogAPI.Infrastructure.Data
{
    public class ActivityRepository : IActivityRepository
    {
        private readonly AppDbContext _dbContext;

        public ActivityRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Activity Add(Activity addActivity)
        {
            Activity activity = addActivity;
            if (activity != null)
            {
                _dbContext.Activities.Add(activity);
                _dbContext.SaveChanges();
                return activity;
            }
            return null;
        }

        public Activity Get(int id)
        {
            Activity activity = _dbContext.Activities
                .Include(x => x.User)
                .Include(x=>x.ActivityType)
                .FirstOrDefault(x => x.Id == id);
            if (activity != null)
            {
                return activity;
            }
            return null;
        }

        public IEnumerable<Activity> GetAll()
        {
            var activity = _dbContext.Activities.Include(x => x.User).Include(x => x.ActivityType).ToList();
            if (activity != null)
            {
                return activity;
            }
            return null;
        }

        public void Remove(Activity deleteActivity)
        {
            Activity activity = _dbContext.Activities.FirstOrDefault(x => x.Id == deleteActivity.Id);
            if (activity != null)
            {
                _dbContext.Remove(activity);
                _dbContext.SaveChanges();
            }
        }

        public Activity Update(Activity updateActivity)
        {
            Activity activity = _dbContext.Activities.FirstOrDefault(x => x.Id == updateActivity.Id);
            if (activity != null)
            {
                _dbContext.Entry(activity)
                    .CurrentValues
                    .SetValues(updateActivity);
                _dbContext.Update(activity);
                _dbContext.SaveChanges();
                return activity;
            }
            return null;
        }
    }
}
