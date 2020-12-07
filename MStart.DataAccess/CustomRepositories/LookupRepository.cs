using MStart.Common.DTO_s;
using MStart.DataAccess.Entities;
using MStart.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MStart.DataAccess.CustomRepositories
{
    public class LookupRepository : Repository<Lookup>
    {
        public LookupRepository(UnitOfWork uow) : base(uow) { }
        public int GetLookupIDByCode(string code)
        {

            var record = GetQuerable(l => l.LookupCode == code).Select(x => new { x.Id }).SingleOrDefault();

            if (record == null)
            {
                return -1;
            }

            return record.Id;
        }

        public LookupsDTO GetLookupValueAndIDByCode(string code)
        {
            var arabicCultureLookupID = GetLookupIDByCode(code);
            var englishCultureLookupID = GetLookupIDByCode(code);

            var query = from look in _db.Lookups
                        join lookCul in _db.LookupCultures
                        on look.Id equals lookCul.LookupID
                        where look.LookupCode == code
                        select new LookupsDTO()
                        {
                            Id = look.Id,
                            ValueAr = look.LookupCultures.Where(x => x.LookupID == arabicCultureLookupID).FirstOrDefault().Value,
                            ValueEn = look.LookupCultures.Where(x => x.LookupID == englishCultureLookupID).FirstOrDefault().Value,

                        };

            var result = query.FirstOrDefault();

            return result;

        }

        public LookupsDTO GetLookupByID(int ID)
        {
            var query = from look in _db.Lookups
                        join lookCul in _db.LookupCultures
                        on look.Id equals lookCul.LookupID
                        where look.Id == ID
                        select new LookupsDTO()
                        {
                            Id = look.Id,
                            ValueAr = look.LookupCultures.Where(x => x.LookupID == ID).FirstOrDefault().Value,
                            ValueEn = look.LookupCultures.Where(x => x.LookupID == ID).FirstOrDefault().Value,
                        };

            var result = query.FirstOrDefault();

            return result;

        }




    }
}
