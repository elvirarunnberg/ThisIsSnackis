using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using ThisIsSnackis.Models;

namespace ThisIsSnackis.Pages
{
    public class MittApiModel : PageModel
    {
        public List<MyPost> Posts { get; private set; }

        //Hämtar data asynkront från mitt alldeles egna API
        public async Task OnGetAsync()
        {
            string responseContent = await GetContent("https://horsenetapi.azurewebsites.net/api/values");
            if (responseContent != null)
            {
                Posts = JsonSerializer.Deserialize<List<MyPost>>(responseContent);
            }
            else
            {
                Posts = new List<MyPost>();
            }
        }


        public static async Task<string> GetContent(string uri)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    return null;
                }
            }
        }
    }
}