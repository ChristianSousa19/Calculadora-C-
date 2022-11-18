using System;
using System.IO;
namespace CURSOCHARP
{
    internal class CURSOCHARP
    {
        
        public static double DoOperation(double num1, double num2, string op)
        {
            double result = double.NaN; // O valor padrão é "not-a-number", que usamos se uma operação, como divisão, puder resultar em um erro.
                switch (op)
            {
                case "a":
                    result = num1 + num2;
                    break;
                case "s":
                    result = num1 - num2;
                    break;
                case "m":
                    result = num1 * num2;
                    break;
                case "d":
                    // Pedindo ao usuário para inserir um divisor diferente de zero.
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                    }
                    break;
                // Retornar para o texto se houver uma  entrada com opção incorreta.
                default:
                    break;
            }
            return result;
        }
    }

    class Programa
    {
        static void Main(string[] args)
        {
            bool endApp = false;
            // Titulo 
            Console.WriteLine(" Calculadora em C#\r");
            Console.WriteLine("------------------------\n");

            while (!endApp)
            {
                // Declarando variáveis de valor vazio.
                string numInput1 = "";
                string numInput2 = "";
                double result = 0;

                // Pedindo ao usuário para digitar o primeiro número.
                Console.WriteLine("Digite o valor do primeiro numero: ");
                numInput1 = Console.ReadLine();

                double cleanNum1 = 0;
                while (!double.TryParse(numInput1, out cleanNum1))
                {
                    Console.WriteLine("Esta não é uma entrada válida. Insira um valor: ");
                    numInput1 = Console.ReadLine();
                }

                // Pedindo ao usuário para digitar o segundo número.
                Console.WriteLine("Digite o valor do segundo numero: ");
                numInput2 = Console.ReadLine();

                double cleanNum2 = 0;
                while (!double.TryParse(numInput2, out cleanNum2))
                {
                    Console.WriteLine("Esta não é uma entrada válida. Insira um valor:: ");
                    numInput2 = Console.ReadLine();
                }

                // Pedindo ao usuário pra fazer uma escolha.
                Console.WriteLine("Escolha uma opção da lista:");
                Console.WriteLine("\ta - Adição");
                Console.WriteLine("\ts - Subtração");
                Console.WriteLine("\tm - Multiplicação");
                Console.WriteLine("\td - Divisão");
                Console.Write("Sua opção? ");

                string op = Console.ReadLine();

                try//Tratamento de exceção(Erros)
                {
                    result = CURSOCHARP.DoOperation(cleanNum1, cleanNum2, op);
                    if (double.IsNaN(result))
                    {
                        Console.WriteLine("Esta operação resultará em um erro.\n");
                    }
                    else Console.WriteLine(" Resultado: {0:0.##}\n", result);
                }
                catch (Exception e)
                {
                    Console.WriteLine("ERRO!!!!.n - Detalhes: " + e.Message);
                }

                Console.WriteLine("------------------------\n");

                // Esperando a resposta do usuário para fechar o programa.
                Console.Write("Pressione 'n' e Enter para fechar o programa, ou pressione qualquer outra tecla e Enter para continuar: ");
                if (Console.ReadLine() == "n") endApp = true;

                Console.WriteLine("\n"); // Apenas um alinhamento.
            }
            return;
        }
    }
}