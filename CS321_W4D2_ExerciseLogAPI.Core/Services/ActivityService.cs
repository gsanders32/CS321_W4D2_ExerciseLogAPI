using CS321_W4D2_ExerciseLogAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CS321_W4D2_ExerciseLogAPI.Core.Services
{
    public class ActivityService : IActivityService
    {
        private IActivityRepository _activityRepo;

        public ActivityService(IActivityRepository activityRepo)
        {
            _activityRepo = activityRepo;
        }
        public Activity Add(Activity addActivity)
        {
            return _activityRepo.Add(addActivity);
        }

        public Activity Get(int id)
        {
            return _activityRepo.Get(id);
        }

        public IEnumerable<Activity> GetAll()
        {
            return _activityRepo.GetAll();
        }

        public void Remove(Activity deleteActivity)
        {
            _activityRepo.Remove(deleteActivity);
        }

        public Activity Update(Activity updateActivity)
        {
            Activity activity = _activityRepo.Update(updateActivity);
            return activity;
        }
    }
}
