using MStart.BusinessLogicLayer;
using MStart.Common.DTO_s;
using MStart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MStart.Mapper
{
    public class UsersMapper
    {
        private LookupsBusinessLogic _LookupsBusinessLogic;
        public UsersMapper()
        {
            _LookupsBusinessLogic = new LookupsBusinessLogic();
        }
        #region User Mapper
        public List<UsersViewModel> ConvertUsersToWeb(List<UserDTO> employeesDto)
        {
            List<UsersViewModel> EmployeesList = new List<UsersViewModel>();
            if (employeesDto == null)
            {
                return EmployeesList;
            }
            foreach (var employee in employeesDto)
            {
                var newemployee = new UsersViewModel()
                {
                    image = employee.image,
                    Address = employee.Address,
                    Address_AR = employee.Address_AR,
                    DateTime_UTC = employee.DateTime_UTC,
                    Email = employee.Email,
                    First_Name = employee.First_Name,
                    First_Name_AR = employee.First_Name_AR,
                    Gender = _LookupsBusinessLogic.GetLookupByID(employee.Gender).Value,
                    Last_Name = employee.Last_Name,
                    Last_Name_AR = employee.Last_Name_AR,
                    Mobile_Number = employee.Mobile_Number,
                    Server_Date_Time = employee.Server_Date_Time,
                    Update_DateTime_UTC = employee.Update_DateTime_UTC,
                    AspNetUserId = employee.AspNetUserId,
                    ID = employee.ID,
                    PhotoId = employee.PhotoId,
                    EmployeeImage = employee.UserImage,
                };
                EmployeesList.Add(newemployee);
            }
            return EmployeesList;




        }
        public UsersViewModel ConvertUserToWeb(UserDTO employee)
        {
            UsersViewModel Employees = new UsersViewModel();
            if (employee == null)
            {
                return Employees;
            }
            Employees = new UsersViewModel()
            {
                Address = employee.Address,
                Address_AR = employee.Address_AR,
                DateTime_UTC = employee.DateTime_UTC,
                Email = employee.Email,
                First_Name = employee.First_Name,
                First_Name_AR = employee.First_Name_AR,
                Gender = _LookupsBusinessLogic.GetLookupByID(employee.Gender).Value,
                Last_Name = employee.Last_Name,
                Last_Name_AR = employee.Last_Name_AR,
                Mobile_Number = employee.Mobile_Number,
                Server_Date_Time = employee.Server_Date_Time,
                Update_DateTime_UTC = employee.Update_DateTime_UTC,
                AspNetUserId = employee.AspNetUserId,
                ID = employee.ID,
                PhotoId = employee.PhotoId,
            };

            return Employees;
        }
        public UserDTO ConvertUserToBLL(UsersViewModel model)
        {
            UserDTO Employees = new UserDTO();
            if (model == null)
            {
                return Employees;
            }
            Employees = new UserDTO()
            {
                Address = model.Address,
                Address_AR = model.Address_AR,
                DateTime_UTC = DateTime.UtcNow,
                Email = model.Email,
                First_Name = model.First_Name,
                First_Name_AR = model.First_Name_AR,
                Gender = model.GenderId,
                Last_Name = model.Last_Name,
                Last_Name_AR = model.Last_Name_AR,
                Mobile_Number = model.Mobile_Number,
                Server_Date_Time = DateTime.Now,
                Update_DateTime_UTC = DateTime.UtcNow,
                AspNetUserId = model.AspNetUserId,
                ID = model.ID,
                PhotoId = model.PhotoId,
            };
            return Employees;
        }
        public List<UserDTO> ConvertUserToBLL(List<UsersViewModel> model)
        {
            List<UserDTO> EmployeesList = new List<UserDTO>();
            if (model == null)
            {
                return EmployeesList;
            }
            foreach (var employee in model)
            {
                var newemployee = new UserDTO()
                {
                    Address = employee.Address,
                    Address_AR = employee.Address_AR,
                    DateTime_UTC = employee.DateTime_UTC,
                    Email = employee.Email,
                    First_Name = employee.First_Name,
                    First_Name_AR = employee.First_Name_AR,
                    Gender = employee.GenderId,
                    Last_Name = employee.Last_Name,
                    Last_Name_AR = employee.Last_Name_AR,
                    Mobile_Number = employee.Mobile_Number,
                    Server_Date_Time = employee.Server_Date_Time,
                    Update_DateTime_UTC = employee.Update_DateTime_UTC,
                    AspNetUserId = employee.AspNetUserId,
                    ID = employee.ID,
                    PhotoId = employee.PhotoId
                };
                EmployeesList.Add(newemployee);
            }
            return EmployeesList;
        }
        #endregion



    }
}