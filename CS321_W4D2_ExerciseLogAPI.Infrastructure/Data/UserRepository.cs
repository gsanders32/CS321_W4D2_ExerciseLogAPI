using CS321_W4D2_ExerciseLogAPI.Core.Models;
using CS321_W4D2_ExerciseLogAPI.Core.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS321_W4D2_ExerciseLogAPI.Infrastructure.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _dbContext;

        public UserRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public User Add(User addUser)
        {
            _dbContext.Users.Add(addUser);
            _dbContext.SaveChanges();
            return addUser;
        }

        public User Get(int id)
        {
            User user = _dbContext.Users.Include(x => x.Activities).FirstOrDefault(x => x.Id == id);
            if (user != null)
            {
                return user;
            }
            return null;
        }

        public IEnumerable<User> GetAll()
        {
            //return _dbContext.Users.Include(x => x.Activities).ToList();
            return _dbContext.Users.ToList();
        }

        public void Remove(User deleteUser)
        {
            User user = _dbContext.Users.FirstOrDefault(x => x.Id == deleteUser.Id);
            if (user != null)
            {
                _dbContext.Users.Remove(user);
                _dbContext.SaveChanges();
            }
            Console.WriteLine();
            
        }

        public User Update(User updateUser)
        {
            User user = _dbContext.Users.FirstOrDefault(x => x.Id == updateUser.Id);
            if (user != null)
            {
                _dbContext.Entry(user)
                    .CurrentValues
                    .SetValues(updateUser);
                _dbContext.Update(user);
                _dbContext.SaveChanges();
                return user;
            }
            return null;
        }
    }
}
