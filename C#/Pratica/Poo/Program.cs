/*
    ulong CopiaDoID = ulong.Parse(ID);
        int[] VerificarID = new int[5];


        VerificarID[0] = (int)(CopiaDoID % 10000UL);
        CopiaDoID -= (ulong)VerificarID[0];
        CopiaDoID = CopiaDoID / 10000;

        VerificarID[1] = (int)(CopiaDoID % 10UL);
        CopiaDoID -= (ulong)VerificarID[1];
        CopiaDoID = CopiaDoID / 10;

        VerificarID[2] = (int)(CopiaDoID % 100UL);
        CopiaDoID -= (ulong)VerificarID[2];
        CopiaDoID = CopiaDoID / 100;

        if (CopiaDoID.ToString().Length > 5)
        {
            VerificarID[3] = (int)(CopiaDoID % 100000UL);
            CopiaDoID -= (ulong)VerificarID[3];
            CopiaDoID = CopiaDoID / 100000;
        }
        else if (CopiaDoID.ToString().Length == 5)
        {
            VerificarID[3] = (int)(CopiaDoID % 10000UL);
            CopiaDoID -= (ulong)VerificarID[3];
            CopiaDoID = CopiaDoID / 10000;
        }
        VerificarID[4] = (int)CopiaDoID;
*/

using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

class Program
{

    public static void Main()
    {
        ContaBancaria P1 = new ContaBancaria();
        P1.Saldo = 1250.9M;
        P1.Usuario = "Gustavo Gualberto da Silva";
        string SaldoString = P1.Saldo.ToString();
        P1.MoedaType = 1;
        P1.IdConta = GerarIdAleatorio(P1.MoedaType);
        Apresentacao(P1, SaldoString, P1.Usuario);
        
    }

    public class ContaBancaria
    {

        private decimal _saldo;
        public decimal Saldo
        {
            get
            {
                return _saldo;
            }
            set
            {
                _saldo = value;
            }
        }
        private string _IdConta;
        public string IdConta
        {
            get
            {
                return _IdConta;
            }
            set
            {
                
                _IdConta = value;
            }
        }
        private string _Usuario;
        public string Usuario
        {
            get
            {
                return _Usuario;
            }
            set
            {
                _Usuario = value;
            }
        }

        private int _MoedaType;
        public int MoedaType
        {
            get
            {
                return _MoedaType;
            }
            set
            {
                if (value <= 10)
                {
                    _MoedaType = value;
                }
            }
        }

    }



    /*----------------------------------------++METODOS++----------------------------------------*/



    public static string GerarIdAleatorio(int MoedaTypeCopy)
    {
        int[] Number = new int[6];
        int TipoDeId;
        
        Random random = new Random();
        char RandomLetra = (char)random.Next(65, 123);
        Number[0] = MoedaTypeCopy;
        TipoDeId = Number[0];
        string ID = TipoDeId.ToString();
        
        Number[1] = GerarNumeroAleatorio(1000, 9999);
        Number[2] = GerarNumeroAleatorio(10, 9);
        Number[3] = GerarNumeroAleatorio(10, 99);
        Number[4] = Number[1] * Number[2] - Number[3];
        ID += Number[4];
        ID += Number[3];
        ID += Number[2];
        ID += Number[1];
        ID += RandomLetra;
        return ID;

    }


    public static int GerarNumeroAleatorio(int n1, int n2)
    {
        Random random = new Random();
        return random.Next(n1, n2 + 1);
    }










    /*----------------------------------++METODOS SEM RETORNO++----------------------------------*/

    public static void Apresentacao(ContaBancaria conta, string saldo, string user)
    {
        Console.Clear();
        Console.WriteLine(" ");
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.Write("________________________| ");
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.Write("Seja Bem Vindo Ao GusBank");
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine(" |________________________ ");
        
        Console.WriteLine($"|                                                                           |");
        Console.Write("|");
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.Write("  SALDO = ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write($"R$:{saldo}");
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        for (int i = 0; i < (61 - saldo.Length); i++)
        {
            Console.Write(" ");
        }
        Console.WriteLine(" |");
        Console.Write("|");
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.Write("  USUARIO = ");
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.Write($"{user}");
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        for (int i = 0; i < (62 - user.Length); i++)
        {
            Console.Write(" ");
        }
        Console.WriteLine(" |");
        Console.Write("|");
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.Write("  ID DE TRANSFERENCIA = ");
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.Write($"{conta.IdConta}");
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        for (int i = 0; i < (50 - conta.IdConta.Length); i++)
        {
            Console.Write(" ");
        }
        Console.WriteLine(" |");

        Console.WriteLine($"|                                                                           |");
        Console.WriteLine($"|                                                                           |");
        Console.WriteLine($"|___________________________________________________________________________|");
    }
}
