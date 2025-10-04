using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    static class ClienteDados
    {
        public static string Nome = "Gustavo";
        public static decimal Saldo = 1328.1m;
        public static List<produtos> Carrinho = new List<produtos>();
    }

    enum CUPOM { ABERTURA = 50, FÉRIAS = 30, YOUTUBER15 = 15 };

    public static List<produtos> Estoque = new List<produtos>
    {
        new produtos {preco = 459.79m, nome = "Celular"},
        new produtos {preco = 1197.99m, nome = "Notebook-ASUS"},
        new produtos {preco = 4899.00m, nome = "PC-GAMER"}
    };

    public class produtos { public decimal preco; public string nome; }



    static void Main()
    {
        Console.Clear();
        System.Console.WriteLine(" ");
        int contador = 1;
        Console.ForegroundColor = ConsoleColor.DarkGray;
        System.Console.WriteLine($"Temos os seguintes produtos em nosso estoque:");
        foreach (var x in Estoque)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write($"{contador} - ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"{x.nome}: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"R$:{x.preco}");
            contador += 1;
        }
        Console.ForegroundColor = ConsoleColor.DarkGray;
        System.Console.WriteLine("Deseja comprar algum item? (S/N)");
        Console.ForegroundColor = ConsoleColor.White;
        string resposta = Console.ReadLine().ToUpper();
        if (resposta == "S" || resposta == "N")
        {
            if (resposta == "S")
            {
                Comprar();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                System.Console.WriteLine("ENCERRANDO...");
                Thread.Sleep(2000);
            }
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine("ENCERRANDO....");
            Thread.Sleep(2000);
        }
    }

    public static void Comprar()
    {
        Console.ForegroundColor = ConsoleColor.DarkGray;
        System.Console.WriteLine("Que item deseja adicionar ao carrinho? (DIGITE UM NUMERO)");
        Console.ForegroundColor = ConsoleColor.White;
        int InputBuy = int.Parse(Console.ReadLine());
        Console.ForegroundColor = ConsoleColor.DarkGray;
        int contador = 1;
        foreach (var x in Estoque)
        {
            if (contador == InputBuy)
            {
                ClienteDados.Carrinho.Add(x);
            }
            contador++;
        }
        System.Console.WriteLine("Deseja Adicionar Mais Um item No carrinho? (S/N)");
        Console.ForegroundColor = ConsoleColor.White;
        if (Console.ReadLine().ToUpper() == "S")
        {
            Comprar();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            System.Console.WriteLine($"Deseja comprar os itens do carrinho? ({ClienteDados.Carrinho.Count} ITENS) (S/N)");
        }
        if (Console.ReadLine().ToUpper() == "S")
        {
            decimal PrecoFinal = 0;
            foreach (var x in ClienteDados.Carrinho)
            {
                PrecoFinal += x.preco;
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            System.Console.WriteLine($"O preço final é de {PrecoFinal}");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            System.Console.WriteLine("Deseja adicionar algum cupom de desconto?");
            Console.ForegroundColor = ConsoleColor.Yellow;
            System.Console.WriteLine("Digite o cupom ou N para cancelar");
            string Input2 = Console.ReadLine().ToUpper();
            if (Input2 == "N")
            {
                if (PrecoFinal < ClienteDados.Saldo)
                {
                    ClienteDados.Saldo -= PrecoFinal;
                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                    System.Console.WriteLine($"{ClienteDados.Carrinho.Count} Itens Comprados por R$:{PrecoFinal}");
                }

            }
            else
            {
                string CupomInput;
                CupomInput = Input2;
                decimal valor = Enum.TryParse(CupomInput, out CUPOM cupom) ? (int)cupom : -1;
                PrecoFinal = PrecoFinal * (valor * 0.01m);
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                System.Console.WriteLine($"{ClienteDados.Carrinho.Count} Itens Comprados por R$:{PrecoFinal}");

            }
            

        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            System.Console.WriteLine("ENCERRANDO...");
            Thread.Sleep(2000);
        }
        
    }
}