using CS321_W4D2_ExerciseLogAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CS321_W4D2_ExerciseLogAPI.Core.Services
{
    public class ActivityTypeService : IActivityTypeService
    {
        private IActivityTypeRepository _activityTypeRepo;

        public ActivityTypeService(IActivityTypeRepository activityTypeRepo)
        {
            _activityTypeRepo = activityTypeRepo;
        }

        public ActivityType Add(ActivityType addActivityType)
        {
            _activityTypeRepo.Add(addActivityType);
            return addActivityType;
        }

        public ActivityType Get(int id)
        {
            return _activityTypeRepo.Get(id);
        }

        public IEnumerable<ActivityType> GetAll()
        {
            return _activityTypeRepo.GetAll();
        }

        public void Remove(ActivityType deleteActivityType)
        {
            _activityTypeRepo.Remove(deleteActivityType);
        }

        public ActivityType Update(ActivityType updateActivityType)
        {
            ActivityType activityType = _activityTypeRepo.Update(updateActivityType);
            return activityType;
        }
    }
}
