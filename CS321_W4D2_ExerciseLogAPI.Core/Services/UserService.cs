using CS321_W4D2_ExerciseLogAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CS321_W4D2_ExerciseLogAPI.Core.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepo;

        public UserService(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }
        public User Add(User addUser)
        {
            _userRepo.Add(addUser);
            return addUser;
        }

        public User Get(int id)
        {
            return _userRepo.Get(id);
        }

        public IEnumerable<User> GetAll()
        {
            return _userRepo.GetAll();
        }

        public void Remove(User deleteUser)
        {
            _userRepo.Remove(deleteUser);
        }

        public User Update(User updateUser)
        {
            User User = _userRepo.Update(updateUser);
            return User;
        }
    }
}
