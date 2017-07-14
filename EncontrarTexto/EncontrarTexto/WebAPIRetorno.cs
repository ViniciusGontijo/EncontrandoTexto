using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace EncontrarTexto
{
    public static class WebAPIRetorno
    {
        public static string Retorno { get; set; }

        public static async Task AcessarServico(string texto)
        {
            try
            {
                using (var cliente = new HttpClient())
                {
                    cliente.BaseAddress = new Uri("https://programmerchallenge.herokuapp.com/");
                    cliente.DefaultRequestHeaders.Accept.Clear();
                    HttpResponseMessage resposta;

                    //post
                    resposta = await cliente.PostAsync("challenge/run_task/", new StringContent(texto));

                    if (resposta.IsSuccessStatusCode)
                        Retorno = await resposta.Content.ReadAsStringAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
