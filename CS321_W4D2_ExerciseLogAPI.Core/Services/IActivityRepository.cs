﻿using CS321_W4D2_ExerciseLogAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CS321_W4D2_ExerciseLogAPI.Core.Services
{
    public interface IActivityRepository
    {
        // Create
        Activity Add(Activity addActivity);
        // Read
        Activity Get(int id);
        // Update
        Activity Update(Activity updateActivity);
        // Delete
        void Remove(Activity deleteActivity);
        // List
        IEnumerable<Activity> GetAll();
    }
}
