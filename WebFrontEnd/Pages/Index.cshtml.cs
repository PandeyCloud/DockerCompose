using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebFrontEnd.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public async Task OnGet()
        {
            ViewData["Message"] = "Hello from webfrontend";

            using (var client = new System.Net.Http.HttpClient())
            {
                // Call *mywebapi*, and display its response in the page
                var request = new System.Net.Http.HttpRequestMessage();
                // To use in localhost and port of API
                //request.RequestUri = new Uri("http://localhost:32316/weatherforecast");
                // To use in Docker comopose via service name of API.
                request.RequestUri = new Uri("http://mywebapi:80/weatherforecast");
                var response = await client.GetAsync(request.RequestUri);
                ViewData["Message"] += " and " + await response.Content.ReadAsStringAsync();
            }
        }
    }
}
