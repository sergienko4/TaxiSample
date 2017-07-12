using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using cTaxi2.Models;
using Newtonsoft.Json;

namespace cTaxi2.Init
{
    public static class InitData
    {
        private static List<int> _ids = new List<int>();
        private static List<DriverModel> _driversList = new List<DriverModel>();
        private static readonly string _dataPath = $"{AppDomain.CurrentDomain.GetData("DataDirectory")}\\Drivers.json";

        internal static void CreateData()
        {
            if (!_driversList.Any())
                if (!File.Exists(_dataPath))
                {
                    #region init drivers list 

                    _driversList.Add(new DriverModel()
                    {
                        LicenceID = GetId(),
                        FirstName = "Cinnamon Club 1",
                        LastName = "Cinnamon 1",
                        PhoneNumber = "0546465520",
                        LastEyeCheck = DateTime.Now.AddMonths(-7),
                        BeginJob = new DateTime(2017, 06, 06),
                        Adress = "Tel Aviv",
                        Email = "david@gmail.com"
                    });

                    _driversList.Add(new DriverModel()
                    {
                        LicenceID = GetId(),
                        FirstName = "Cinnamon Club 1",
                        LastName = "Cinnamon 1",
                        PhoneNumber = "0546465520",
                        LastEyeCheck = DateTime.Now.AddMonths(-5),
                        BeginJob = new DateTime(1990, 01, 10),
                        Adress = "Tel Aviv",
                        Email = "david@gmail.com"
                    });
                    _driversList.Add(new DriverModel()
                    {
                        LicenceID = GetId(),
                        FirstName = "Cinnamon Club 1",
                        LastName = "Cinnamon 1",
                        PhoneNumber = "0546465520",
                        LastEyeCheck = DateTime.Now.AddMonths(-6),
                        BeginJob = new DateTime(2017, 01, 05),
                        Adress = "Tel Aviv",
                        Email = "david@gmail.com"
                    });
                    _driversList.Add(new DriverModel()
                    {
                        LicenceID = GetId(),
                        FirstName = "Cinnamon Club 1",
                        LastName = "Cinnamon 1",
                        PhoneNumber = "0546465520",
                        LastEyeCheck = DateTime.Now.AddMonths(-3),
                        BeginJob = new DateTime(2017, 05, 05),
                        Adress = "Tel Aviv",
                        Email = "david@gmail.com"
                    });

                    #endregion

                    WriteToFile();
                }
                else
                {
                    var json = File.ReadAllText(_dataPath);
                    _driversList = JsonConvert.DeserializeObject<List<DriverModel>>(json);
                }

        }

        private static void WriteToFile()
        {
            var json = JsonConvert.SerializeObject(_driversList);
            File.WriteAllText(_dataPath, json);
        }

        private static int GetId()
        {
            Random rnd = new Random();
            var isUnique = false;
            int id = 0;
            while (!isUnique)
            {
                id = rnd.Next(0, 100001);
                if (!_ids.Contains(id))
                {
                    _ids.Add(id);
                    isUnique = true;
                }
            }
            return id;
        }

        public static List<DriverModel> GetDrivers()
        {
            if (_driversList.Count == 0)
                CreateData();
            return _driversList;
        }

        public static DriverModel GetDriversByID(int LicenceID)
        {
            return _driversList.Single(x => x.LicenceID == LicenceID);
        }
        public static void DeleteByID(int LicenceID)
        {
            var driver = _driversList.Single(x => x.LicenceID == LicenceID);
            if (driver != null)
            {
                _driversList.Remove(driver);
                WriteToFile();
            }
        }

        public static void UpdateDriver(DriverModel model)
        {
            DeleteByID(model.LicenceID);
            AddRecors(model);
        }

        public static void AddRecors(DriverModel driver)
        {
            _driversList.Add(driver);
            WriteToFile();
        }
    }
}