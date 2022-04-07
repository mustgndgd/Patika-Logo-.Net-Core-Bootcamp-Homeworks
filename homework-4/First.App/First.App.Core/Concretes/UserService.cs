using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using First.App.Business.Abstract;
using First.App.Business.DTOs;
using First.App.DataAccess.EntityFramework.Repository.Abstracts;
using First.App.Domain.Entities;

namespace First.App.Business.Concretes
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> repository;
        private readonly IUnitOfWork unitOfWork;
        public UserService(IRepository<User> repository, IUnitOfWork unitOfWork)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
        }

        public List<User> GetAllUser()
        {
            return repository.Get().ToList();
        }

        public User getUser(string UserName)
        {
            return repository.Get().Where(u=>u.Username==UserName).First();
        }

        public void AddUser(User user)
        {
            repository.Add(user);
            unitOfWork.Commit();
        }

        public void UpdateUser(User user)
        {
            repository.Update(user);
            unitOfWork.Commit();
        }

        public void DeleteUser(User user)
        {
            repository.Delete(user);
            unitOfWork.Commit();
        }
    } 
   
}
