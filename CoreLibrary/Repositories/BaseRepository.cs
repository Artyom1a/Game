using CoreLibrary.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;




namespace CoreLibrary.Repositories
{
    public abstract class BaseRepository<T> where T : IData
    {
        protected abstract string Path { get; } //возвращает каталог, из которого был загружен текущий домен приложения.

        public List<T> GetAll() //GetAll который будет возвращать список всех доступных пользователей.
        {
            List<T> data = new List<T>();
            var serializeOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };
            try
            {
                using StreamReader sr1 = new StreamReader(Path);
                string result = sr1.ReadLine();

                while (result != null)
                {
                    var data1 = JsonSerializer.Deserialize<T>(result, serializeOptions);
                    data.Add(data1);
                    result = sr1.ReadLine();
                };
                sr1.Close();
                return data;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return new List<T>();

        }

        public int NextId()
        {
            List<T> data = GetAll();
            int lastID = data.LastOrDefault()?.Id ?? 0;
            return ++lastID;
        }


        public void OverWritingFile(List<T> usersvse)
        {
            try
            {
                var serializeOptions = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };
                StreamWriter sw1 = new StreamWriter(Path);
                for (int i = 0; i < usersvse.Count; i++)
                {
                    if (usersvse[i] != null)
                    {
                        string json = JsonSerializer.Serialize<T>(usersvse[i], serializeOptions);
                        sw1.WriteLine(json);
                    }
                }
                sw1.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        public void Delete(int id)
        {
            List<T> data = GetAll();
            data.RemoveAll(x => x.Id == id);
            //метод updata 
        }


    }
}

