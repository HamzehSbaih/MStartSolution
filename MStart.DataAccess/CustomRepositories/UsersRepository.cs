using MStart.Common.DTO_s;
using MStart.DataAccess.Entities;
using MStart.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStart.DataAccess.CustomRepositories
{
    public class UsersRepository : Repository<User>
    {
        public UsersRepository(UnitOfWork uow) : base(uow) { }
        public bool AddUser(UserDTO dto)
        {
            try
            {
                var record = new User()
                {
                    Address = dto.Address,
                    Address_AR = dto.Address_AR,
                    DateTime_UTC = dto.DateTime_UTC,
                    First_Name = dto.First_Name,
                    Last_Name = dto.Last_Name,
                    Last_Name_AR = dto.Last_Name_AR,
                    First_Name_AR = dto.First_Name_AR,
                    Mobile_Number = dto.Mobile_Number,
                    Gender = dto.Gender,
                    Server_Date_Time = dto.Server_Date_Time,
                    Update_DateTime_UTC = dto.Update_DateTime_UTC,
                    Email = dto.Email,
                    PhotoId = dto.PhotoId,

                };

                Create(record);
                _uow.Save();
                return true;
            }
            catch (Exception ex)
            {
                ex.Data.Add("AddEmployee", "An error occurred while trying to  AddEmployee Record - DAL");
                
                _uow.Rollback();
                return false;
            }
        }
        public bool EditUser(UserDTO dto)
        {
            try
            {
                var record = GetQuerable(x => x.ID == dto.ID).FirstOrDefault();

                record.Address = dto.Address;
                record.Address_AR = dto.Address_AR;
                record.DateTime_UTC = dto.DateTime_UTC;
                record.First_Name = dto.First_Name;
                record.Last_Name = dto.Last_Name;
                record.Last_Name_AR = dto.Last_Name_AR;
                record.First_Name_AR = dto.First_Name_AR;
                record.Mobile_Number = dto.Mobile_Number;
                record.Gender = dto.Gender;
                record.Server_Date_Time = dto.Server_Date_Time;
                record.Update_DateTime_UTC = dto.Update_DateTime_UTC;
                record.Email = dto.Email;
                Update(record);
                _uow.Save();
                return true;
            }
            catch (Exception ex)
            {
                ex.Data.Add("EditEmployee", "An error occurred while trying to Edit Employee Record - DAL");
               
                _uow.Rollback();
                return false;
            }
        }
        public bool DeleteUser(int EmployeeId)
        {
            try
            {
                var record = GetQuerable(x => x.ID == EmployeeId).FirstOrDefault();

                if (record != null)
                {
                    Delete(record);
                    _uow.Save();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                ex.Data.Add("DeleteEmployee", "An error occurred while trying to Delete Employee Record - DAL");
                
                _uow.Rollback();
                return false;
            }
        }
        public bool DeleteUsers(int[] emplyees)
        {
            try
            {
               
                List<User> getempids = new List<User>();
                getempids = _db.Users.Where(x => emplyees.Contains(x.ID)).ToList();

                foreach (var s in getempids)
                {
                    _db.Users.Remove(s);

                }
                _uow.Save();
                return true;

            }
            catch (Exception ex)
            {
                ex.Data.Add("DeleteEmployees", "An error occurred while trying to Delete Employees Records - DAL");
               
                _uow.Rollback();
                return false;
            }
        }
        public UserDTO GetUser(int EmployeeId)
        {
            try
            {
                var record = GetQuerable(x => x.ID == EmployeeId).Select(u => new UserDTO()
                {
                    ID = u.ID,
                    Address = u.Address,
                    Address_AR = u.Address_AR,
                    DateTime_UTC = u.DateTime_UTC,
                    First_Name = u.First_Name,
                    Last_Name = u.Last_Name,
                    Last_Name_AR = u.Last_Name_AR,
                    First_Name_AR = u.First_Name_AR,
                    Mobile_Number = u.Mobile_Number,
                    Gender = u.Gender,
                    Server_Date_Time = u.Server_Date_Time,
                    Update_DateTime_UTC = u.Update_DateTime_UTC,
                    Email = u.Email,
                    PhotoId = u.PhotoId,
                }).FirstOrDefault();

                return record;
            }
            catch (Exception ex)
            {
                ex.Data.Add("GetEmployee ", "An error occurred while trying to GetEmployee record  in DAL ");
               
                _uow.Rollback();
                return null;
            }
        }
        public UserImageDTO GetUserImage(int EmployeeId)
        {

            var record = GetQuerable(x => x.ID == EmployeeId).Include(x => x.UserImage).Select(u => new UserImageDTO()
            {
                EmployeeId = u.ID,
                file_stream = u.UserImage.file_stream,
                Id = u.UserImage.Id,
                ContentType = u.UserImage.file_type,
                FileNameWithExtension = u.UserImage.file_name
            }).Distinct().FirstOrDefault();


            return record;

        }
        public List<UserDTO> GetUsers()
        {
            try
            {
                var record = GetQuerable(x => x.ID > 0).Select(u => new UserDTO()
                {
                    ID = u.ID,
                    Address = u.Address,
                    Address_AR = u.Address_AR,
                    DateTime_UTC = u.DateTime_UTC,
                    First_Name = u.First_Name,
                    Last_Name = u.Last_Name,
                    Last_Name_AR = u.Last_Name_AR,
                    First_Name_AR = u.First_Name_AR,
                    Mobile_Number = u.Mobile_Number,
                    Gender = u.Gender,
                    Server_Date_Time = u.Server_Date_Time,
                    Update_DateTime_UTC = u.Update_DateTime_UTC,
                    Email = u.Email,
                    PhotoId = u.PhotoId,
                    //image = new EmployeeImageDTO()
                    //{
                    //    EmployeeId = u.ID,
                    //    file_stream = u.EmployeeImage.file_stream,
                    //    Id = u.EmployeeImage.Id,
                    //    ContentType = u.EmployeeImage.file_type,
                    //    FileNameWithExtension = u.EmployeeImage.file_name
                    //},
                }).ToList();
                if (record != null && record.Count > 0)
                {
                    return record;
                }
                return null;
            }
            catch (Exception ex)
            {
                ex.Data.Add("GetEmployees ", "An error occurred while trying to GetEmployees records  in DAL ");
               
                _uow.Rollback();
                return null;
            }
        }
        public bool AddUserImage(int ImageId, int EmployeeId)
        {
            try
            {
                var employee = GetQuerable(x => x.ID == EmployeeId).FirstOrDefault();
                employee.PhotoId = ImageId;

                Update(employee);
                _uow.Save();
                return true;
            }
            catch (Exception ex)
            {
                ex.Data.Add("EditEmployee", "An error occurred while trying to Edit Employee Record - DAL");
            
                _uow.Rollback();
                return false;
            }


        }

        public List<UserDDLDTO> GetAccountDDL()
        {
            try
            {
                var record = GetQuerable(x => x.ID > 0).Select(u => new UserDDLDTO()
                {
                    Value = u.First_Name + u.Last_Name,
                    ValueAr = u.Last_Name_AR + u.Last_Name_AR,
                    ID = u.ID
                }).ToList();

                return record;
            }
            catch (Exception ex)
            {
                ex.Data.Add("GetAccountDDL ", "An error occurred while trying to GetDepartments records  in DAL ");
                _uow.Rollback();
                return null;
            }
        }


    }
}
