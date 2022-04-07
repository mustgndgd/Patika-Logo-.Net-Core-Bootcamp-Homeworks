using System;
using System.Collections.Generic;
using System.Text;
using First.App.Domain.Entities;

namespace First.App.Business.Abstract
{
    public interface IUserService
    {
        List<User> GetAllUser();
        User getUser(string UserName);
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(User user);
    }
}
