using CS321_W4D2_ExerciseLogAPI.Core.Models;
using System.Collections.Generic;

namespace CS321_W4D2_ExerciseLogAPI.Core.Services
{
    public interface IUserService
    {
        User Add(User addUser);
        User Get(int id);
        IEnumerable<User> GetAll();
        void Remove(User deleteUser);
        User Update(User updateUser);
    }
}