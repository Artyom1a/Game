using CoreLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLibrary.Services;
using CoreLibrary.Controller;

namespace CoreLibrary.Controller
{
    public class UserController
    {
        private UserService userscontroller = new UserService();
        //+
        public (bool, User) AddUserController()
        {
            Console.WriteLine("To create a user?  1- Yes, 2-No, enter Name, Email, Password step by step. " +
                "We will check if there is such a name and email in the system. ");
            string chooseplayer = Console.ReadLine();
            if (!string.IsNullOrEmpty(chooseplayer) && chooseplayer.Equals("1"))
            {
                Console.WriteLine("Continue!");
                Console.WriteLine("Please write your name");
                string name = Console.ReadLine();
                Console.WriteLine("Please write your email");
                string email = Console.ReadLine();
                Console.WriteLine("Please write your password");
                string password = Console.ReadLine();

                if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
                {
                    User newuser = userscontroller.AddUser(name, email, password);
                    if (newuser != null)
                    {
                        Console.WriteLine("You registrated");
                        return (true, newuser);
                    }
                }
            }
            return (false, null);
        }
        //+
        public (bool, User) Login()
        {
            Console.WriteLine("Do you want to get into your account? 1- Yes, 2-No");
            if (Console.ReadLine() == "1")
            {
                Console.Write("Write your Email: ");
                string email = Console.ReadLine();
                Console.Write("Write your Name: ");
                string name = Console.ReadLine();
                Console.Write("Enter Password: ");
                string password = Console.ReadLine();
                if (!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(password))
                {
                    User userlogin = userscontroller.Login(name, email, password);
                    if (userlogin != null)
                    {
                        Console.WriteLine($"Welcome {name}");
                        return (true, userlogin);
                    }
                }
            }
            return (false, null);

        }
        public (bool, User) Update(User user)
        {
            if (user == null)
            {
                return (false, null);
            }
            Console.WriteLine("Do you want to change your password?  1- Yes, 2-No");
            string chooseplayer = Console.ReadLine();
            if (!string.IsNullOrEmpty(chooseplayer) && chooseplayer.Equals("1"))
            {
                Console.Write("Write new Password: ");
                string password = Console.ReadLine();
                if (!string.IsNullOrEmpty(password))
                {
                    User cloneUser = user.Clone() as User;
                    cloneUser = userscontroller.Update(cloneUser, password);
                    if (cloneUser != null)
                    {
                        Console.WriteLine("You update password");
                        return (true, cloneUser);
                    }
                }
            }
            return (true, null);
        }
        public (bool, User) Delete()
        {

            Console.WriteLine("Do you want to delete your account?  1- Yes, 2-No");
            string chooseplayer = Console.ReadLine();
            if (chooseplayer.Equals("1"))
            {
                Console.WriteLine("Warning, you are deleting your account!");
                Console.Write("Write your Email: ");
                string email = Console.ReadLine();
                Console.Write("Write your Name: ");
                string name = Console.ReadLine();
                if (userscontroller.Delete(email, name))
                {
                    Console.WriteLine("You deleted your account");
                    return (false, null);
                }
            }
            return (false, null);
        }

    }

}