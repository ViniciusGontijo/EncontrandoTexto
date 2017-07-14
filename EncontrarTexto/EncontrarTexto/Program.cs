using System;

namespace EncontrarTexto
{
    class Program
    {

        static void Main(string[] args)
        {
            try
            {
                EncontrarOTexto texto = new EncontrarOTexto();
                var t = texto.MontarTexto();
                Console.WriteLine(t);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro encontrado:" + ex.InnerException);
            }

            Console.ReadKey();

        }

        }
}
