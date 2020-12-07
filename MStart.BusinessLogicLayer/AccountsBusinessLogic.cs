using MStart.Common;
using MStart.Common.DTO_s;
using MStart.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStart.BusinessLogicLayer
{
    public class AccountsBusinessLogic
    {
        public List<UserDDLDTO> GetAccountDDL(Enums.Culture cul)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                try
                {
                    var Departments = uow.Users.GetAccountDDL();

                    if (Departments != null)
                    {
                        if (cul == Enums.Culture.Arabic)
                        {
                            foreach (var i in Departments)
                            {
                                i.Value = i.ValueAr;
                                i.ValueAr = i.ValueAr;
                            }
                        }
                        else
                        {
                            foreach (var i in Departments)
                            {
                                i.Value = i.Value;
                                i.ValueAr = i.Value;
                            }
                        }


                        return Departments;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    ex.Data.Add("GetDepartments", "An error occurred while trying to create GetDepartments Record - BLL");
                    uow.Rollback();
                    return null;
                }
            }
        }
    }
}
