using System.Collections.Generic;
using FamilyBusiness.Database;
using FamilyBusiness.Database.Models;

namespace FamilyBusiness.DataAccess.Repositories
{
    public class FamilyRepository : IFamilyRepository
    {
        private readonly FamilyContext _db;

        public FamilyRepository(FamilyContext db)
        {
            _db = db;
        }
        
        public IEnumerable<Family> GetAll()
        {
            return _db.Families;
        }
    }
}