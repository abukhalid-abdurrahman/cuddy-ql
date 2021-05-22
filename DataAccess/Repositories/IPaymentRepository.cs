using System.Collections;
using System.Collections.Generic;
using FamilyBusiness.Database.Models;

namespace FamilyBusiness.DataAccess.Repositories
{
    public interface IPaymentRepository
    {
        IEnumerable<Payment> GetAll();
    }
}