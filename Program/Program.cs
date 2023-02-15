
using CoreLibrary.Menu;
using CoreLibrary.Models;
using CoreLibrary.Repositories;
//using CoreLibrary.Services;

namespace Programs;

public class Program
{
    private static void Main(string[] args)
    {
        User user = new User(1,"Artyom","artyom@gmail.com","12345");
        Console.WriteLine(user.ToString());
        UserRepository repository = new UserRepository();
        //var users = repository.GetAll();
        //Console.WriteLine(string.Join(",", users));
        repository.Add(new User(1, "Artyom", "artyom@gmail.com", "12345"));
        repository.Add(new User(2, "Test", "artyom@gmail.com", "12345"));
        repository.Add(new User(3, "Test2", "Test@gmail.com", "12345"));


    }
}

