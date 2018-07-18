using Binary_Project_Structure_BLL.Interfaces;
using Binary_Project_Structure_Shared.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Binary_Project_Structure_BLL.Services
{
    public class ParceService : IParceService
    {
        private static List<CrewByApiDto> Crews;
        
        public async Task<List<CrewByApiDto>> GetCrews()
        {
            if(Crews == null)
            {
                string path = @"http://5b128555d50a5c0014ef1204.mockapi.io/crew";
                string responseBody;
                using (var client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(path);
                    response.EnsureSuccessStatusCode();
                    responseBody = await response.Content.ReadAsStringAsync();
                }
                Crews = JsonConvert.DeserializeObject<List<CrewByApiDto>>(responseBody);
            }
            return Crews.GetRange(0, 10);
        }
    }
}
