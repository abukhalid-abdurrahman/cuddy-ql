using FamilyBusiness.DataAccess.Repositories;
using FamilyBusiness.Types;
using GraphQL.Types;

namespace FamilyBusiness.Queries
{
    public class FamilyQuery : ObjectGraphType
    {
        public FamilyQuery(IFamilyRepository familyRepository)
        {
            Field<ListGraphType<FamilyType>>(
                "families",
                resolve: c => familyRepository.GetAll());
        }
    }
}