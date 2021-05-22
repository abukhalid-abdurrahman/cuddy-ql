using System.Collections.Generic;

namespace FamilyBusiness.Database.Models
{
    public class Family
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Payment> Payments { get; set; }
    }
}