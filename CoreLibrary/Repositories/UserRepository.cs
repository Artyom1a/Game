using CoreLibrary.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using CoreLibrary.Services;

namespace CoreLibrary.Repositories
{
    public class UserRepository : BaseRepository<User>
    {
        protected override string Path => "C:\\Code Main\\users.txt"; //возвращает каталог, из которого был загружен текущий домен приложения.



        public User Add(User adduser) //создаём нового пользователя
        {

            List<User>? usersvse = GetAll();
            UserService userService = new UserService();

            if (userService.AddUser(usersvse, adduser))
            {
                adduser.Id = NextId();
                usersvse.Add(adduser);
                OverWritingFile(usersvse);
                Console.WriteLine($"{adduser.Name} {adduser.Email}  done registration");
            }
            return adduser;
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