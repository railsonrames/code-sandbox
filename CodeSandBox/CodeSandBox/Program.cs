using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;

namespace CodeSandBox
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // ~~~~~~~> FROM TEMPLATE
            //CreateHostBuilder(args).Build().Run();

            string[] simuladorEntrada = { "3", "[4,2,3,1,6]", "[10,12,14,11,15]", "[12032,12030,12031,12034,12036,12035]" };

            foreach (var entrada in simuladorEntrada)
            {
                Console.WriteLine("Robô: " + entrada);
                if (entrada.Length < 2)
                    continue;
                Console.WriteLine("Entrada recebida: " + ProcessInput(entrada));
            }
        }

        public static string ProcessInput(string input)
        {
            //Aqui é onde você deve desenvolver o seu algoritmo que irá processar a entrada e então retorna-la.
            var entrada = input.Substring(1, input.IndexOf(']') - 1);
            Console.WriteLine("Entrada: " + entrada);
            var lista = entrada.Split(',');
            Array.Sort(lista);
            int[] listaInteiros = new int[lista.Length];
            int counter = 0;
            int resultado = 0;
            int anterior = 0;

            foreach (var item in lista)
            {
                int intItem = int.Parse(item);
                listaInteiros[counter] = intItem;
                if (intItem != anterior + 1)
                {
                    resultado = anterior + 1;
                }
                Console.WriteLine(counter + ": " + intItem);
                counter++;
                anterior = intItem;
            }
            Console.WriteLine("Resultado: " + resultado);
            return input;
        }

        // ~~~~~~~> FROM TEMPLATE
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
