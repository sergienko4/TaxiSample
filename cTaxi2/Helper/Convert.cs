using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using cTaxi2.Models;
using cTaxi2.ViewModel;

namespace cTaxi2.Helper
{
    public class Convert
    {
        public static DriverViewModel GetDriverViewModel(DriverModel driver)
        {
            var days = System.Convert.ToInt16((DateTime.Now - driver.BeginJob).TotalDays);
            return new DriverViewModel()
            {
                BeginJob = days,
                FullName = $"{driver.FirstName} {driver.LastName}",
                Email = driver.Email,
                Adress = driver.Adress,
                LicenceID = driver.LicenceID,
                PhoneNumber = driver.PhoneNumber,
                LastEyeCheck = driver.LastEyeCheck
            };
        }

        public static List<DriverViewModel> GetDriverViewListModel(List<DriverModel> drivers)
        {
            List<DriverViewModel> list = new List<DriverViewModel>();
            foreach (var driver in drivers)
            {
                list.Add(GetDriverViewModel(driver));
            }
            return list;
        }


        public static DriverModel ToDriverModel(DriverViewModel driver)
        {
            string last = string.Empty;
            var fullName = driver.FullName.Split(' ');
            var begin = DateTime.Now.AddDays(-driver.BeginJob);

            if (fullName.Length > 1)
                last = fullName[1];
            else
                last = fullName[0];


            return new DriverModel()
            {
                Adress = driver.Adress,
                Email = driver.Email,
                FirstName = fullName[0],
                LastName = last,
                BeginJob = begin,
                LicenceID = driver.LicenceID,
                PhoneNumber = driver.PhoneNumber,
                LastEyeCheck = driver.LastEyeCheck

            };

        }

    }
}