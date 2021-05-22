using System;
using System.Collections.Generic;
using System.Linq;
using FamilyBusiness.Database.Models;

namespace FamilyBusiness.Database
{
    public static class FamilySeed
    {
        private static IEnumerable<Family> GetFamilies()
        {
            var families = new List<Family>
            {
                new Family()
                {
                    Name = "Faridun's Family",
                    Payments = new List<Payment>()
                    {
                        new Payment()
                        {
                            Amount = 2000,
                            CreateAt = DateTime.Now,
                            TransactionId = Guid.NewGuid().ToString()
                        }
                    }
                },
                new Family()
                {
                    Name = "Ali's Family",
                    Payments = new List<Payment>()
                    {
                        new Payment()
                        {
                            Amount = 2000,
                            CreateAt = DateTime.Now,
                            TransactionId = Guid.NewGuid().ToString()
                        },
                        new Payment()
                        {
                            Amount = 3000,
                            CreateAt = DateTime.Now,
                            TransactionId = Guid.NewGuid().ToString()
                        },                      
                        new Payment()
                        {
                            Amount = 9000,
                            CreateAt = DateTime.Now,
                            TransactionId = Guid.NewGuid().ToString()
                        }
                    }
                }
            };
            return families;
        }

        public static void EnsureSeedData(this FamilyContext db)
        {
            if (db.Families.Any() && db.Payments.Any()) return;
            db.Families.AddRange(GetFamilies());
            db.SaveChanges();
        }
    }
}