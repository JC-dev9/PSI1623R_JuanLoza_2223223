using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BeLightBible.Services
{
    public class ApiBibleService
    {
        private readonly HttpClient _httpClient;

        public ApiBibleService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<dynamic> BuscarVersiculo(string livro, int capitulo)
        {
            string url = $"https://bible-api.com/{livro}+{capitulo}?translation=almeida";

            try
            {
                HttpResponseMessage responde = await _httpClient.GetAsync(url);

                if (!responde.IsSuccessStatusCode)
                {
                    return null;
                }

                string json = await responde.Content.ReadAsStringAsync();
                dynamic data = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
                return data;
            }
            catch (Exception ex)
            {
                // Tratar exceção (log, mensagem de erro, etc.)
                Console.WriteLine($"Erro ao buscar versículo: {ex.Message}");
                return null;
            }
        }
    }
}
