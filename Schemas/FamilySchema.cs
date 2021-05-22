using FamilyBusiness.Queries;
using GraphQL;

namespace FamilyBusiness.Schemas
{
    public class FamilySchema : GraphQL.Types.Schema
    {
        public FamilySchema(IDependencyResolver dependencyResolver)
            : base(dependencyResolver)
        {
            Query = dependencyResolver.Resolve<FamilyQuery>();
        }
    }
}