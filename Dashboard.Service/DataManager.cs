using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Dashboard.Service
{
    public class DataManager : IDataManager
    {

        private string filePath = @"C:\Users\harsh_mahajan\Demo\Dashboard.Service\UserData.json";

        public bool AddUser(User user)
        {
            bool response = false;
            try
            {
                if (user != null)
                {
                    var data = File.ReadAllText(filePath);

                    if (!string.IsNullOrEmpty(data))
                    {
                        dynamic users = JsonConvert.DeserializeObject(data, typeof(List<User>));

                        List<User> usrs = users;

                        usrs.Add(user);

                        File.WriteAllText(filePath, JsonConvert.SerializeObject(usrs));

                        response = true;

                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
            return response;
        }

        public List<User> GetUsers()
        {
            return ReadUsers();
        }

        private List<User> ReadUsers()
        {
            List<User> user = new List<User>();

            try
            {
                var data = File.ReadAllText(filePath);

                if (!string.IsNullOrEmpty(data))
                {
                    dynamic users = JsonConvert.DeserializeObject(data, typeof(List<User>));

                    user = users;
                }
            }
            catch (Exception e)
            {

                throw;
            }
            return user;
        }

    }
}
