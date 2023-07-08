using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace InsuranceWeb.Pages
{
    public class IndexModel : PageModel
    {


        private readonly IHttpClientFactory _clientFactory;

        public IndexModel(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }


        public async Task OnGet()
        {
            var client = _clientFactory.CreateClient();
            var result = await client.GetStringAsync("https://localhost:7103/api/Insurance/Averages");

            var averages = JsonSerializer.Deserialize<MyViewModel>(result);

            ViewData["Message"] = averages.Average;
            
        }
    }


    public record MyViewModel(
        [property: JsonPropertyName("average")] double Average,
        [property: JsonPropertyName("sumOfValues")] double SumOfValues,
        [property: JsonPropertyName("numberOfElements")] int NumberOfElements
    );


  
}