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

        public bool AddUser(List<User> usersvse, User adduser)
        {
            try
            {
                User adduser1 = new User(adduser.Id, adduser.Name, adduser.Email, adduser.Password);
                if (string.IsNullOrEmpty(adduser.Name) || string.IsNullOrEmpty(adduser.Email) || string.IsNullOrEmpty(adduser.Password))
                {
                    System.Console.WriteLine("error input");
                    return false;
                }
                for (int i = 0; i < usersvse.Count; i++)
                {

                    if (usersvse[i].Name == adduser1.Name && usersvse[i].Email == adduser1.Email)
                    {
                        Console.WriteLine("Name or Email are registrated yet");
                        return false;
                    }

                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}


//for (int i = 0; i < uservse.Count; i++)
//{
//    if (adduser.Email == email)//isnull
//    {
//        System.Console.WriteLine("This email not available");
//        return false;
//    }
//}