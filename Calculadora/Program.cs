using System;
using System.Collections.Generic;

namespace Calculadora
{
    class Program
    {
        private static List<string> historico = new List<string>();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Calculadora\n");
                Console.WriteLine("1. Soma");
                Console.WriteLine("2. Subtração");
                Console.WriteLine("3. Multiplicação");
                Console.WriteLine("4. Divisão");
                Console.WriteLine("5. Histórico");
                Console.WriteLine("6. Sair");

                var escolha = Console.ReadKey().KeyChar;

                int num1, num2;
                string resultado = "";

                switch (escolha)
                {
                    case '1':
                        (num1, num2) = LerNumeros();
                        resultado = $"{num1} + {num2} = {num1 + num2}";
                        break;
                    case '2':
                        (num1, num2) = LerNumeros();
                        resultado = $"{num1} - {num2} = {num1 - num2}";
                        break;
                    case '3':
                        (num1, num2) = LerNumeros();
                        resultado = $"{num1} * {num2} = {num1 * num2}";
                        break;
                    case '4':
                        (num1, num2) = LerNumeros();
                        while (num2 == 0)
                        {
                            Console.WriteLine("Digite um divisor diferente de zero:");
                            num2 = Convert.ToInt32(Console.ReadLine());
                        }
                        resultado = $"{num1} / {num2} = {num1 / num2}";
                        break;
                    case '5':
                        MostrarHistorico();
                        continue;
                    case '6':
                        return;
                }

                if (!string.IsNullOrEmpty(resultado))
                {
                    AdicionarAoHistorico(resultado);
                    Console.WriteLine(resultado);
                }

                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }

        static (int, int) LerNumeros()
        {
            Console.WriteLine("\nDigite o primeiro número:");
            int num1 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Digite o segundo número:");
            int num2 = Convert.ToInt32(Console.ReadLine());

            return (num1, num2);
        }

        static void AdicionarAoHistorico(string operacao)
        {
            if (historico.Count == 3)
                historico.RemoveAt(0);

            historico.Add(operacao);
        }

        static void MostrarHistorico()
        {
            Console.WriteLine("\nHistórico:");
            foreach (var operacao in historico)
            {
                Console.WriteLine(operacao);
            }
            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
    }
}
