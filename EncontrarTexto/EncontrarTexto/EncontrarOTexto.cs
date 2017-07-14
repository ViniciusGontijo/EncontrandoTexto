using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncontrarTexto
{
    public class EncontrarOTexto
    {
        private string BaseDoTexto;

        
        public string MontarTexto()
        {
            string caracteres, retorno;
            string texto = String.Empty;
            int tamanho = 0;
            caracteres = ".,!?aeiouAEIOUbcdfghjklmnpqrstvwxyzBCDFGHJKLMNPQRSTVWXYZ\'\"áéêíóàêãàõç:;123456789@#$%&()+=[]{}°ª";

            TamanhoDoTexto(texto,tamanho);//chama o método para descobrir o tamanho do texto e montar a base
            retorno = BaseDoTexto;

            try
            {
                char[] caracter = caracteres.ToCharArray();
                var i = 0;

                do
                {
                    retorno = retorno.Replace('-', caracter[i]).Replace('*', caracter[i]); //substitui caracteres (-,*) por um caractere do texto
                    WebAPIRetorno.AcessarServico(retorno).Wait(); //acessa o serviço e preenche a varia Retorno da classe WebAPIRetorno
                    retorno = WebAPIRetorno.Retorno;
                    i++;
                }
                while (retorno.Contains("*") || retorno.Contains("-"));//condição de saída quando não houver mais * ou  -

                return retorno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //Método recursivo, buscando o tamanho da frase para montar a base
        private void TamanhoDoTexto(string texto, int tamanho)
        {
            try
            {
                if (texto.Length < tamanho) //verifica se a quantidade de caracteres(espaço) ultrapassaram o tamanho do texto
                    BaseDoTexto = texto;

                else
                {
                    tamanho += 50;
                    texto = "";
                    for (int i = 0; i < tamanho; i++) //gera quantidade de caracteres conforma a variável tamanho
                        texto += " ";

                    WebAPIRetorno.AcessarServico(texto).Wait();
                    texto = WebAPIRetorno.Retorno;
                    TamanhoDoTexto(texto,tamanho); //chama novamente o método passando o texto e o tamanho
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
