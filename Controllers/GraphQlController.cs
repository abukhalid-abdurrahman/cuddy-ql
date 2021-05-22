using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FamilyBusiness.Utilities;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Mvc;

namespace FamilyBusiness.Controllers
{
    [Route("[controller]")]
    public class GraphQlController : Controller
    {
        private readonly ISchema _schema;
        private readonly IDocumentExecuter _documentExecuter;
        
        public GraphQlController(ISchema schema, IDocumentExecuter documentExecuter)
        {
            _schema = schema;
            _documentExecuter = documentExecuter;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GraphQlQuery query)
        {
            if(query == null) throw new ArgumentNullException();
            var inputs = query.Variables?.ToInputs();
            var executionOptions = new ExecutionOptions()
            {
                Schema = _schema,
                Query = query.Query,
                Inputs = inputs
            };
            var result = await _documentExecuter.ExecuteAsync(executionOptions);
            if (result.Errors?.Count > 0)
                return BadRequest(result);
            return Ok(result);
        }
    }
}