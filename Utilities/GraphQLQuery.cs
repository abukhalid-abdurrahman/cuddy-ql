using Newtonsoft.Json.Linq;

namespace FamilyBusiness.Utilities
{
    public class GraphQlQuery
    {
        public string OperationName { get; set; }
        public string Query { get; set; }
        public JObject Variables { get; set; }
    }
}