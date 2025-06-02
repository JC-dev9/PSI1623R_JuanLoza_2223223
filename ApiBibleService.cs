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
        private readonly Dictionary<string, int> livros;    

        public ApiBibleService()
        {
            _httpClient = new HttpClient();
            livros = new Dictionary<string, int>
            {
                { "Gênesis", 50 },
                { "Êxodo", 40 },
                { "Levítico", 27 },
                { "Números", 36 },
                { "Deuteronômio", 34 },
                { "Josué", 24 },
                { "Juízes", 21 },
                { "Rute", 4 },
                { "1 Samuel", 31 },
                { "2 Samuel", 24 },
                { "1 Reis", 22 },
                { "2 Reis", 25 },
                { "1 Crônicas", 29 },
                { "2 Crônicas", 36 },
                { "Esdras", 10 },
                { "Neemias", 13 },
                { "Ester", 10 },
                { "Jó", 42 },
                { "Salmos", 150 },
                { "Provérbios", 31 },
                { "Eclesiastes", 12 },
                { "Cânticos", 8 },
                { "Isaías", 66 },
                { "Jeremias", 52 },
                { "Lamentações", 5 },
                { "Ezequiel", 48 },
                { "Daniel", 12 },
                { "Oseias", 14 },
                { "Joel", 3 },
                { "Amós", 9 },
                { "Obadias", 1 },
                { "Jonas", 4 },
                { "Miquéias", 7 },
                { "Naum", 3 },
                { "Habacuque", 3 },
                { "Sofonias", 3 },
                { "Ageu", 2 },
                { "Zacarias", 14 },
                { "Malaquias", 4 },
                { "Mateus", 28 },
                { "Marcos", 16 },
                { "Lucas", 24 },
                { "João", 21 },
                { "Atos", 28 },
                { "Romanos", 16 },
                { "1 Coríntios", 16 },
                { "2 Coríntios", 13 },
                { "Gálatas", 6 },
                { "Efésios", 6 },
                { "Filipenses", 4 },
                { "Colossenses", 4 },
                { "1 Tessalonicenses", 5 },
                { "2 Tessalonicenses", 3 },
                { "1 Timóteo", 6 },
                { "2 Timóteo", 4 },
                { "Tito", 3 },
                { "Filemom", 1 },
                { "Hebreus", 13 },
                { "Tiago", 5 },
                { "1 Pedro", 5 },
                { "2 Pedro", 3 },
                { "1 João", 5 },
                { "2 João", 1 },
                { "3 João", 1 },
                { "Judas", 1 },
                { "Apocalipse", 22 }
            };
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

        public async Task<dynamic> BuscarVersiculoAleatorio()
        {
            Random rand = new Random();

            var livrosLista = new List<string>(livros.Keys);
            string livroAleatorio = livrosLista[rand.Next(livrosLista.Count)];
            int capituloAleatorio = rand.Next(1, livros[livroAleatorio] + 1);

            var data = await BuscarVersiculo(livroAleatorio, capituloAleatorio);

            if (data != null && data.verses != null)
            {
                var versiculos = data.verses;
                int index = rand.Next(versiculos.Count);
                return versiculos[index];
            }

            return null;
        }
    }
}

