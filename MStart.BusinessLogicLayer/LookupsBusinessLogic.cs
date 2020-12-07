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
   public class LookupsBusinessLogic
    {
        public IEnumerable<LookupsDTO> GetLookupsByLookupCategoryCode(string lookupCategoryCode, Enums.Culture cul)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                var repo = uow.LookupCategory;
                var lookup = repo.GetLookupsByLookupCategoryCode(lookupCategoryCode, cul);
                if (lookup == null)
                {
                    return null;
                }
                else
                {
                    return lookup;
                }
            }
        }
        public int GetLookupIDByCode(string code)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                var repo = uow.Lookups;
                var lookupID = repo.GetLookupIDByCode(code);

                if (lookupID == -1)
                {
                    return -1;
                }

                return lookupID;
            }
        }
        public LookupsDTO GetLookupValueAndIDByCode(string code, Enums.CultureID culture)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                var repo = uow.Lookups;
                var lookup = repo.GetLookupValueAndIDByCode(code);


                if (lookup == null)
                {
                    return null;
                }

                return lookup;
            }
        }
        public LookupsDTO GetLookupByLookupCategoryCode(string code, Enums.CultureID culture)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                var repo = uow.Lookups;
                var lookup = repo.GetLookupValueAndIDByCode(code);
                if (culture == Enums.CultureID.Ar)
                {
                    lookup = new LookupsDTO()
                    {
                        Id = lookup.Id,
                        Value = lookup.ValueAr
                    };
                }
                else
                {
                    lookup = new LookupsDTO()
                    {
                        Id = lookup.Id,
                        Value = lookup.ValueEn
                    };
                }
                if (lookup == null)
                {
                    return null;
                }

                return lookup;
            }
        }
        public LookupsDTO GetLookupByID(int LookupID)
        {
            using (UnitOfWork uow = new UnitOfWork())
            {
                var repo = uow.Lookups;
                var lookup = repo.GetLookupByID(LookupID);
                if (String.IsNullOrEmpty(lookup.ValueAr))
                {
                    lookup.Value = lookup.ValueAr;
                }
                else
                {
                    lookup.Value = lookup.ValueEn;
                }

                if (lookup == null)
                {
                    return null;
                }

                return lookup;
            }
        }
    }
}
