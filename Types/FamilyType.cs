using FamilyBusiness.Database.Models;
using GraphQL.Types;

namespace FamilyBusiness.Types
{
    public class FamilyType : ObjectGraphType<Family>
    {
        public FamilyType()
        {
            Field(x => x.Id);
            Field(x => x.Name);
        }
    }
}