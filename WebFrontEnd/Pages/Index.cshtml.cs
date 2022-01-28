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
                //request.RequestUri = new Uri("http://localhost:32316/weatherforecast");
                request.RequestUri = new Uri("http://mywebapi:32316/weatherforecast");
                var response = await client.GetAsync(request.RequestUri);
                ViewData["Message"] += " and " + await response.Content.ReadAsStringAsync();
            }
        }
    }
}
