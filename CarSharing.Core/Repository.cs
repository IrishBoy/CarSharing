using CarSharing.Core.Models;
using System.IO;
using System;
using System.Collections.Generic;
using System.Text;
using CarSharing.Core.Helpers;
using Newtonsoft.Json;
using System.Linq;

namespace CarSharing.Core
{
    public class Repository
    {
        public List<Model> Models { get; set; }
        public List<Car> Cars { get; set; }
        public List<Session> Sessions { get; set; }
        public List<User> Users { get; set; }

        public Repository()
        {
            try
            {
                Restore();
            }
            catch
            {
                DataInitiated();
                Save();
            }

        }

        private const string ModelsFileName = "models.json";
        private const string CarsFileName = "cars.json";
        private const string UsersFileName = "users.json";
        private const string SessionsFileName = "cars.json";

        public void AddUser(string name, string phoneNumber, string login, string password)
        {
            Users.Add(new User { Name = name, Phone = phoneNumber, Login = login, Password = password });
            Save();
        }

        public void Save()
        {
            SaveList(ModelsFileName, Models);
            SaveList(CarsFileName, Cars);
            SaveList(UsersFileName, Users);
            SaveList(UsersFileName, Sessions);
        }

        private void SaveList<T>(string fileName, List<T> list)
        {
            using (var sw = new StreamWriter(fileName))
            {
                using (var jsonWriter = new JsonTextWriter(sw))
                {
                    jsonWriter.Formatting = Formatting.Indented;

                    var serializer = new JsonSerializer();
                    serializer.Serialize(jsonWriter, list);
                }
            }
        }

        private void Restore()
        {
            Models = RestoreList<Model>(ModelsFileName);
            Cars = RestoreList<Car>(CarsFileName);
            Sessions = RestoreList<Session>(SessionsFileName);
            Users = RestoreList<User>(UsersFileName);
        }

        private List<T> RestoreList<T>(string fileName)
        {
            using (var sr = new StreamReader(fileName))
            {
                using (var jsonReader = new JsonTextReader(sr))
                {
                    var serializer = new JsonSerializer();
                    return serializer.Deserialize<List<T>>(jsonReader);
                }
            }
        }

        public List<Car> GetFreeCars()
        {
            var freeCars = new List<Car>();
            foreach (var car in Cars)
            {
                var firstIncompleteSession = Sessions.FirstOrDefault(s => s.Car == car && s.EndDt == null);

                /*var exm = from s in Sessions
                          where s.Car == car && s.EndDt == null
                          select s;*/

                if (firstIncompleteSession == null)
                    freeCars.Add(car);
            }
            return freeCars;
        }

        public List<Car> GetFreeCarsLINQOnly()
        {
            return Cars.Where(c => !Sessions.Any(s => s.Car == c && s.EndDt == null)).ToList();
        }

        private void DataInitiated()
        {
            Models = new List<Model>()
            {
                new Model()
                {
                    Id = 1,
                    Name = "Kia Rio",
                    Manufacturer = "Kia",
                    Rate = 7
                },
                new Model()
                {
                    Id = 7,
                    Name = "Lada Granta",
                    Manufacturer = "Lada",
                    Rate = 6
                }
            };

            Cars = new List<Car>()
            {
                new Car()
                {
                    Model = Models[0],
                    Location = new Location()
                    {
                        Latitude = 55.778700,
                        Longitude = 37.732240
                    },
                    FuelLeft = 56
                },
                new Car()
                {
                    Model = Models[1],
                    Location = new Location()
                    {
                        Latitude = 36.778700,
                        Longitude = 76.732240
                    },
                    FuelLeft = 48
                },
                new Car()
                {
                    Model = Models[0],
                    Location = new Location()
                    {
                        Latitude = 37.778700,
                        Longitude = 63.732240
                    },
                    FuelLeft = 65
                },
            };

            Users = new List<User>()
            {
                new User()
                {
                    Name = "John",
                    Login = "John",
                    Password = "JohnPass",
                    Phone = "89123456789"
                },
                new User()
                {
                    Name = "Mary",
                    Login = "Mary",
                    Password = "MaryPass",
                    Phone = "89098765432"
                }
            };

            Sessions = new List<Session>()
            {
                new Session()
                {
                    User = new User()
                    {
                        Name = "John",
                        Login = "John",
                        Password = "JohnPass",
                        Phone = "89123456789"
                    },
                    Car = new Car()
                    {
                        Model = Models[0],
                        Location = new Location()
                        {
                            Latitude = 55.778700,
                            Longitude = 37.732240
                        },
                        FuelLeft = 56
                    },
                    StartDt = new DateTime(2019, 11, 16),
                    EndDt = new DateTime(2019, 11, 17),
                    StartLocation = new Location()
                        {
                            Latitude = 55.778700,
                            Longitude = 37.732240
                        },
                    EndLocation = new Location()
                        {
                            Latitude = 55.779700,
                            Longitude = 37.732250
                        }
                }
            };
        }
    }
}
