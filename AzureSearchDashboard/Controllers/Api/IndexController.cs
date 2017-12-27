using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Search;

namespace AzureSearchDashboard.Controllers.Api
{
    [Route("api/index"), Authorize]
    public class IndexController : Controller
    {
        private readonly ISearchServiceClient _client;

        public IndexController(ISearchServiceClient client)
        {
            _client = client;
        }

        [HttpGet("list-names")]
        public async Task<IActionResult> ListIndexes()
        {
            var indexNames = await _client.Indexes.ListNamesAsync();
            return Ok(indexNames);
        }

        [HttpGet("{indexName}/metadata")]
        public async Task<IActionResult> LoadIndexMetadata(string indexName)
        {
            var metadata = await _client.Indexes.GetAsync(indexName);
            return Ok(metadata);
        }

        [HttpGet("{indexName}/search")]
        public async Task<IActionResult> SearchIndex(string indexName, [FromQuery] string query)
        {
            var indexClient = _client.Indexes.GetClient(indexName);
            var data = await indexClient.Documents.SearchAsync(query);

            return Ok(data);
        }
    }
}
