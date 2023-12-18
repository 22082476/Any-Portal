using System.Text.Json;

public interface IResearchApiService 
{
   Task<bool?> GetFromResearchApi (string id);
}

public class ResearchApiService : IResearchApiService
{
    public async Task<bool?> GetFromResearchApi (string id)
    {
        using (HttpClient client = new HttpClient())
        {
            try
            {
                // Voeg eventuele headers toe (optioneel)
                client.DefaultRequestHeaders.Add("Cookie", id);

                string apiUrl = "https://localhost:3004/"; //aanvullen

                HttpResponseMessage response = await client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();

                    return JsonSerializer.Deserialize<bool>(responseBody);
                }
                else
                {
                    Console.WriteLine("Fout: " + response.StatusCode);
                    return null;
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("Er is een fout opgetreden bij het uitvoeren van het HTTP-verzoek: " + e.Message);
                return null;
            }
        }
    }
}