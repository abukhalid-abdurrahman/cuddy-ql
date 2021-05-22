using System;

namespace FamilyBusiness.Database.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public string TransactionId { get; set; }
        public int Amount { get; set; }
        public DateTime CreateAt { get; set; }
    }
}