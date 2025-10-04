using System;

class Program
{
    public static int Coluna;
    public static int Linha;
    public static bool RepeatCol = true;
    public static bool RepeatLin = true;
    public static bool RepeatAcess = false;
    public static bool RepeatMain = false;
    public static bool MatrizAcess;

    public static int[,] matriz = new int[3, 3]
    {
        {1, 2, 3},
        {4, 5, 6},
        {7, 8, 9}
    };

    static void Main()
    {
        RepeatCol = true;
        RepeatLin = true;
        if(RepeatMain == false)
        {
            Console.WriteLine($"         {matriz[0,0]}  {matriz[0,1]}  {matriz[0,2]}");
            Console.WriteLine($"         {matriz[1,0]}  {matriz[1,1]}  {matriz[1,2]}");
            Console.WriteLine($"         {matriz[2,0]}  {matriz[2,1]}  {matriz[2,2]}");
        }
        Console.WriteLine("Você quer acessar a Matriz 3x3 S/N");
        string inputAcess = Console.ReadLine();

        if (inputAcess == "S")
        {
            while (RepeatCol)
            {
                Console.WriteLine("Digite a Coluna Que Você Quer Acessar 1 2 3");
                string input = Console.ReadLine();

                if (input == "1")
                {
                    Coluna = 1;
                    RepeatCol = false;
                }
                else if (input == "2")
                {
                    Coluna = 2;
                    RepeatCol = false;
                }
                else if (input == "3")
                {
                    Coluna = 3;
                    RepeatCol = false;
                }
                else
                {
                    Console.WriteLine("DIGITE UM NUMERO VALIDO");
                }
            }

            while (RepeatLin)
            {
                Console.WriteLine("Digite a Linha Que Você Quer Acessar 1 2 3");
                string input = Console.ReadLine();

                if (input == "1")
                {
                    Linha = 1;
                    RepeatLin = false;
                }
                else if (input == "2")
                {
                    Linha = 2;
                    RepeatLin = false;
                }
                else if (input == "3")
                {
                    Linha = 3;
                    RepeatLin = false;
                }
                else
                {
                    Console.WriteLine("DIGITE UM NUMERO VALIDO");
                }
            }
            Console.WriteLine("ACESSANDO MATRIZ");
            Thread.Sleep(1000);
            Console.WriteLine(".");
            Thread.Sleep(1000);
            Console.WriteLine(".");
            Thread.Sleep(1000);
            Console.WriteLine(".");
            Thread.Sleep(1000);
            Console.WriteLine($"VOCÊ ACESSOU O VALOR: {matriz[Linha -1, Coluna -1]} Localizado Em: C{Coluna} L{Linha}");
            Console.WriteLine($"Você quer modificar o valor? S/N");
            string ModValue = Console.ReadLine();
            if (ModValue == "S")
            {
                bool RepeatMod = true;
                while(RepeatMod)
                {
                    Console.WriteLine($"Para Qual Valor Deseja Modificar? 0 - 9");
                string NumeroMod = Console.ReadLine();
                if (NumeroMod == "0" || NumeroMod == "1" || NumeroMod == "2" || NumeroMod == "3" || NumeroMod == "4" || NumeroMod == "5" || NumeroMod == "6" || NumeroMod == "7" || NumeroMod == "8" || NumeroMod == "9")
                {
                    int numero = int.Parse(NumeroMod);
                    matriz[Linha -1, Coluna - 1] = numero;
                    Thread.Sleep(500);
                    Console.WriteLine("Moficando Valor");
                    Console.WriteLine(".");
                    Thread.Sleep(1000);
                    Console.WriteLine(".");
                    Thread.Sleep(1000);
                    Console.WriteLine(".");
                    Thread.Sleep(1000);
                    Console.WriteLine($"Numero Modificado Para {numero}");
                    Thread.Sleep(1000);
                    Console.WriteLine($"         {matriz[0,0]}  {matriz[0,1]}  {matriz[0,2]}");
                    Thread.Sleep(1000);
                    Console.WriteLine($"         {matriz[1,0]}  {matriz[1,1]}  {matriz[1,2]}");
                    Thread.Sleep(1000);
                    Console.WriteLine($"         {matriz[2,0]}  {matriz[2,1]}  {matriz[2,2]}");
                    Thread.Sleep(500);
                    Console.WriteLine("");
                    Thread.Sleep(500);
                    Console.WriteLine("Saindo Do Acesso A matriz");
                    
                    RepeatMod = false;
                    RepeatMain = true;
                    Main();
                }else
                {
                    Console.WriteLine("Digite um numero valido");
                }
                }
                
            }
            else
            {
                Console.WriteLine("Digite Uma Resposta Valida");
            }
        }
        else if (inputAcess == "N")
        {
            Console.WriteLine("Acesso Cancelado");
        }
        else
        {
            Console.WriteLine("ACESSO NEGADO, DIGITE UM VALOR VALIDO");
        }
    }
}

