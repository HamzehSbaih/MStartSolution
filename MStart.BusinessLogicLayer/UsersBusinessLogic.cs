using MStart.Common.DTO_s;
using MStart.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStart.BusinessLogicLayer
{
    public class UsersBusinessLogic
    {
        public List<string> GetRolesByUserName(string userName)
        {
            List<string> roles;

            using (var uow = new UnitOfWork())
            {
                roles = uow.Roles.GetRolesByUserName(userName);
                return roles;
            }
        }
        public string GetUserIdByUserName(string UserName)
        {

            using (var uow = new UnitOfWork())
            {
                string UserId = uow.AspNetUser.GetUserIdByUserName(UserName);
                return UserId;
            }

        }

        public int AddImages(UserImageDTO dto)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                try
                {
                    var EmployeeImageAdded = uow.Images.AddImages(dto);
                    if (EmployeeImageAdded > 0)
                    {
                        bool isAdded = uow.Users.AddUserImage(EmployeeImageAdded, dto.EmployeeId);
                        if (isAdded == true)
                        {
                            return dto.EmployeeId;
                        }
                        else
                        {
                            return 0;
                        }
                    }
                    else
                    {
                        return 0;
                    }
                }
                catch (Exception ex)
                {
                    ex.Data.Add("AddImages", "An error occurred while trying to create Employee Image Record - BLL");
                    uow.Rollback();
                    return 0;
                }
            }

        }
        public bool AddUser(UserDTO dto)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                try
                {
                    var EmployeeAdded = uow.Users.AddUser(dto);
                    if (EmployeeAdded != false)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    ex.Data.Add("AddEmployee", "An error occurred while trying to create AddEmployee Record - BLL");
                    uow.Rollback();
                    return false;
                }
            }
        }
        public bool EditUser(UserDTO dto)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                try
                {
                    var EmployeeUpdated = uow.Users.EditUser(dto);
                    if (EmployeeUpdated != false)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    ex.Data.Add("EditEmployee", "An error occurred while trying to create EditEmployee Record - BLL");
                    uow.Rollback();
                    return false;
                }
            }
        }
        public bool DeleteUser(int EmployeeId)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                try
                {
                    var DeletedEmployee = uow.Users.DeleteUser(EmployeeId);
                    if (DeletedEmployee != false)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    ex.Data.Add("DeleteEmployee", "An error occurred while trying to create DeleteEmployee Record - BLL");
                    uow.Rollback();
                    return false;
                }
            }
        }
        public bool DeleteUsers(int[] emplyees)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                try
                {
                    var BaseQuestionAdded = uow.Users.DeleteUsers(emplyees);
                    if (BaseQuestionAdded != false)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    ex.Data.Add("DeleteEmployees", "An error occurred while trying to create DeleteEmployees Record - BLL");
                    uow.Rollback();
                    return false;
                }
            }
        }
        public UserDTO GetUser(int EmployeeId)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                try
                {
                    var employee = uow.Users.GetUser(EmployeeId);
                    if (employee != null)
                    {
                        return employee;
                    }
                    else
                    {
                        return employee;
                    }
                }
                catch (Exception ex)
                {
                    ex.Data.Add("GetEmployee", "An error occurred while trying to create GetEmployee Record - BLL");
                    uow.Rollback();
                    return null;
                }
            }
        }
        public List<UserDTO> GetUsers(out int totalRecords, int page = 1, int pageSize = 10)
        {
            totalRecords = 0;
            List<UserDTO> emps = new List<UserDTO>();
            using (UnitOfWork uow = new UnitOfWork())
            {
                try
                {
                    var users = uow.Users.GetUsers();
                    if (users != null)
                    {
                        foreach (var emp in users)
                        {
                            if (emp.PhotoId > 0)
                            {
                                var imgs = uow.Users.GetUserImage(emp.ID);
                                if (imgs != null)
                                {
                                    string img = Convert.ToBase64String(imgs.file_stream);
                                    emp.UserImage = string.Format("data:image/gif;base64,{0}", img);
                                }
                            }
                        }
                        totalRecords = users.Count();

                        users = users.OrderByDescending(x => x.ID)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize).ToList();


                        return users.ToList();
                    }
                    else
                    {
                        return users;
                    }
                }
                catch (Exception ex)
                {
                    ex.Data.Add("GetEmployees", "An error occurred while trying to create GetEmployees Record - BLL");
                    uow.Rollback();
                    return emps;
                }
            }
        }

    }
}
