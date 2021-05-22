using System.Collections.Generic;
using FamilyBusiness.Database.Models;

namespace FamilyBusiness.DataAccess.Repositories
{
    public interface IFamilyRepository
    {
        IEnumerable<Family> GetAll();
    }
}