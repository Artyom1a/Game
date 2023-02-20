using CoreLibrary.Models;
using CoreLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using CoreLibrary.Repositories;

namespace CoreLibrary.Services
{
    public class UserService
    {

        UserRepository userRepsitory = new UserRepository();
        public User Login(string name, string email, string password)
        {
            User user = userRepsitory.GetByName(name, email);
            if (user != null && user.Password.Equals(password))
            {
                return user;
            }
            return null;
        }
        public User AddUser(string name, string email, string password)
        {
            try
            {
                if (!userRepsitory.Exist(name,email))
                {
                    User newUser = new User(name, email, password);
                    return userRepsitory.AddUserRepository(newUser);

                }
                Console.WriteLine("Error");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
        public User? Update(User user, string password)
        {

            if (user == null) throw new ArgumentNullException(nameof(user));
            try
            {
                user.Password = password;
                return userRepsitory.Update(user);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
        public bool Delete(string email,string name)
        {
            try
            {
                if (!userRepsitory.Exist(name, email) )
                {
                    User delUser = new User(name, email);
                     userRepsitory.Delete(delUser.Id);
                    return true;

                }
                Console.WriteLine("This account does not exist.");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }




            //if (user == null) throw new ArgumentNullException(nameof(user));
            //try
            //{
            //    userRepsitory.Delete(user.Id);
            //    return true;
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex);
            //    return false;
            //}
        }
    }

}











//public User? Update(User user, string password)
//{

//    if (user == null) throw new ArgumentNullException(nameof(user));
//    try
//    {
//        user.Password = password;
//        return _UserRepsitory.Update(user);
//    }
//    catch (Exception ex)
//    {
//        Console.WriteLine(ex);
//        return null;
//    }
//}
//public bool Delete(User user)
//{
//    if (user == null) throw new ArgumentNullException(nameof(user));
//    try
//    {
//        _UserRepsitory.Delete(user.Id);
//        return true;
//    }
//    catch (Exception ex)
//    {
//        Console.WriteLine(ex);
//        return false;
//    }
//}