using System.Collections.Generic;
using FamilyBusiness.Database;
using FamilyBusiness.Database.Models;

namespace FamilyBusiness.DataAccess.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly FamilyContext _db;

        public PaymentRepository(FamilyContext db)
        {
            _db = db;
        }

        public IEnumerable<Payment> GetAll()
        {
            return _db.Payments;
        }
    }
}