using CS321_W4D2_ExerciseLogAPI.Core.Models;
using CS321_W4D2_ExerciseLogAPI.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS321_W4D2_ExerciseLogAPI.Infrastructure.Data
{
    public class ActivityTypeRepository : IActivityTypeRepository
    {
        private readonly AppDbContext _dbContext;

        public ActivityTypeRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ActivityType Add(ActivityType addActivityType)
        {
            ActivityType activityType = addActivityType;
            if (activityType != null)
            {
                _dbContext.Add(activityType);
                _dbContext.SaveChanges();
                return activityType;
            }
            return null;
        }

        public ActivityType Get(int id)
        {
            ActivityType activityType = _dbContext.ActivityTypes.FirstOrDefault(x => x.Id == id);
            if (activityType != null)
            {
                return activityType;
            }
            return null;
        }

        public IEnumerable<ActivityType> GetAll()
        {
            var activityType = _dbContext.ActivityTypes.ToList();
            if (activityType != null)
            {
                return activityType;
            }
            return null;
        }

        public void Remove(ActivityType deleteActivityType)
        {
            ActivityType activityType = _dbContext.ActivityTypes.FirstOrDefault(x => x.Id == deleteActivityType.Id);
            if (activityType != null)
            {
                _dbContext.ActivityTypes.Remove(activityType);
                _dbContext.SaveChanges();
            }
        }

        public ActivityType Update(ActivityType updateActivityType)
        {
            ActivityType activityType = _dbContext.ActivityTypes.FirstOrDefault(x => x.Id == updateActivityType.Id);
            if (activityType != null)
            {
                _dbContext.Entry(activityType)
                    .CurrentValues.SetValues(updateActivityType);
                _dbContext.Update(activityType);
                _dbContext.SaveChanges();
                return activityType;
            }
            return null;
        }
    }
}
