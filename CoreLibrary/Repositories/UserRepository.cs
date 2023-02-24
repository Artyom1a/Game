using CoreLibrary.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using CoreLibrary.Services;
using CoreLibrary.Controller;
using CoreLibrary.Repositories;

namespace CoreLibrary.Repositories
{
    public class UserRepository : BaseRepository<User>
    {
        protected override string Path => "C:\\Code Main\\users.txt"; //возвращает каталог, из которого был загружен текущий домен приложения.

        // Controller – метод, принимающий данные. Принимает данные 
        // клиента
        // Service – метод проверки на то что с Repository вернулось 
        // значение
        // Repository – метод, симулирующая БД. Хранит массив данных.
        //  Взаимодействие с
        // этим массивом осуществляется только в Repository. 

        //public User Create(User adduser)
        //{
        //    List<User>? usersvse = GetAll();
        //    UserService userService = new UserService();
        //    adduser.Id = NextId();
        //    for (int i = 0; i < usersvse.Count; i++)
        //    {
        //        if (usersvse[i].Name == adduser.Name && usersvse[i].Email == adduser.Email)
        //        {
        //            Console.WriteLine("Name or Email are registrated yet");
        //            break;
        //        }
        //    }
        //    usersvse.Add(adduser);
        //    OverWritingFile(usersvse);
        //    Console.WriteLine($"{adduser.Name} {adduser.Email}  done registration");
        //    return adduser;
        //}
        public User GetByName(string name, string email) //переписать логику, чтобы по емайлу
        {
            var usersvse = GetAll();
            for (int i = 0; i < usersvse.Count(); i++)
            {
                User usersvseLogin = usersvse.ElementAt(i);
                if (usersvseLogin.Name.Equals(name) && usersvseLogin.Email.Equals(email))
                {
                    return usersvseLogin;
                }
            }
            return null;
        }
        public (bool,User) Exist(string email)
        {
            foreach (var user in GetAll())
            {
                if (user.Email.Equals(email))
                {
                    return (true, user);
                }
            }
            return (false,null);
        }

        //+
        public User AddUserRepository(User adduser)
        {

            List<User>? usersvse = GetAll();
           // UserService userService = new UserService();
           //метод exist вместо 
            for (int i = 0; i < usersvse.Count; i++)
            {
                if (usersvse[i].Name == adduser.Name && usersvse[i].Email == adduser.Email)
                {
                    Console.WriteLine("Name or Email are registrated yet");
                    break;
                }
            }
            adduser.Id = NextId();
            usersvse.Add(adduser);
            OverWritingFile(usersvse);
            Console.WriteLine($"{adduser.Name} {adduser.Email}  done registration");
            return adduser;
        }
        //+
        public User Update(User user)
        {
            List<User> userList = GetAll().ToList();
            int index = userList.FindIndex(x => x.Id == user.Id);
            if (index < 0)
            {
                return null;
            }
            userList[index] = user;
            OverWritingFile(userList);
            return user;
        }
    }
}














//public bool Exist(User user)
//{
//    List<User> users = GetAll(); 
//    for(int i=0; i<users.Count; i++) 
//    {
//        if (users[i].Name.Equals(user.Name))
//        {
//            return true;
//        }
//    }
//    return false;
//}






//БЛОК прописана логика с доставанием построчно информации из файла и проверки и записи в  файл
//bool can = true; 
//try
//{
//    StringBuilder stringBuilder = new StringBuilder();
//    using StreamReader sr1 = new StreamReader("C:\\Code Main\\OOP10.02Game\\CoreLibrary\\Repositories\\Users.txt");
//    string line = sr1.ReadLine();

//    while (line != null)
//    {
//        if (adduser.ToString().Equals(line)) // как это переписать можно, потому что это очень далеко от идеала
//        {
//            Console.WriteLine("This user was regisrated yet");
//            can= false;
//            break;
//        }
//        stringBuilder.Append(line);
//        line = sr1.ReadLine();
//    }
//    sr1.Close();
//}
//catch (Exception ex)
//{
//    Console.WriteLine(ex.Message);
//}
//if (can != false)
//{
//    StreamWriter sw1 = null;
//    try
//    {
//        sw1 = new StreamWriter("C:\\Code Main\\OOP10.02Game\\CoreLibrary\\Repositories\\Users.txt");
//        sw1.WriteLine(adduser.ToString());
//        sw1.Close();
//        Console.WriteLine($"{adduser.Name} {adduser.Email}  done registration");

//    }
//    catch (Exception ex)
//    {
//        Console.WriteLine(ex.Message);
//    }
//}
//БЛОК прописана логика с доставанием построчно информации из файла и проверки и записи в  файл