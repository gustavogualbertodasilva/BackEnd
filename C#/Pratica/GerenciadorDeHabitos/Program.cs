using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    static Dictionary<string, int> Habitos = new Dictionary<string, int>();
    static void Main()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.White;
        System.Console.WriteLine("Bem vindo ao seu gerenciador de Hábitos");
        Apresentar();
    }

    static void Apresentar()
    {
        System.Console.WriteLine(" ");
        MostrarHabitos(0, true);
        System.Console.WriteLine(" ");
        Console.ForegroundColor = ConsoleColor.White;
        System.Console.WriteLine("Você deseja:");
        System.Console.WriteLine("1 - Sair");
        System.Console.WriteLine("2 - Adicionar Hábito");
        System.Console.WriteLine("3 - Começar Hábito");
        System.Console.WriteLine("4 - Concluir Hábito");
        int resposta = int.Parse(Console.ReadLine());
        
        System.Console.WriteLine(" ");
        GerenciarResposta(resposta);
        
    }
    static void MostrarHabitos(int n, bool CwAll)
    {
        if (CwAll)
        {
            int contador = 1;
            foreach (var x in Habitos)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write($"{contador} - ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"{x.Key}");
                if (x.Value == 2)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($" (✅)");
                }
                else if (x.Value == 1)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($" (🟡)");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine($" (❌)");
                }
                contador++;
            }
        }
        else
        {
            int contador = 1;
            foreach (var x in Habitos)
            {
                if (contador == n + 1)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write($"{contador} - ");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write($"{x.Key}");
                    if (x.Value == 2)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine($" (✅)");
                    }
                    else if (x.Value == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine($" (🟡)");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine($" (❌)");
                    }

                }
                contador++;
            }
        }
    }
    static void AdicionarHabito(string i)
    {
        Habitos.Add(i, 0);
    }
    static void MudarHabito(string i, int valor)
    {
        if (Habitos.ContainsKey(i) && valor >= 0 && valor <= 2)
        {
            Habitos[i] = valor;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine("Erro: Metodo: MudarHabito");
        }
    }
    static void GerenciarResposta(int i)
    {
        switch (i)
        {
            case 1:
                System.Console.WriteLine("Saindo...");
                Thread.Sleep(1200);
                Console.Clear();
                break;

            case 2:
                Console.ForegroundColor = ConsoleColor.White;
                System.Console.WriteLine("Digite o Hábito Que Deseja Adicionar");
                Console.ForegroundColor = ConsoleColor.Gray;
                AdicionarHabito(Console.ReadLine());
                Apresentar();
                break;

            case 3:
                Console.ForegroundColor = ConsoleColor.White;
                System.Console.WriteLine("Que Hábito Deseja Começar? (Escreva o nome do hábito.)");
                Console.ForegroundColor = ConsoleColor.Gray;
                MudarHabito(Console.ReadLine(), 1);
                Apresentar();
                break;

            case 4:
                Console.ForegroundColor = ConsoleColor.White;
                System.Console.WriteLine("Que Hábito Deseja Concluir? (Escreva o nome do hábito.)");
                Console.ForegroundColor = ConsoleColor.Gray;
                MudarHabito(Console.ReadLine(), 2);
                Apresentar();
                break;

            default:
                Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine("Erro: Metodo: GerenciarResposta");
                break;
        }
    }

}