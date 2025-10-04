using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Você deseja multiplicar? Y/N");
        if (Console.ReadLine() == "N")
        {
            Console.WriteLine("Cancelado");
        }
        else
        {
            Console.WriteLine("Digite o multiplicando");
            var multiplicando = double.Parse(Console.ReadLine());

            Console.WriteLine("Digite o multiplicador");
            var multiplicador = double.Parse(Console.ReadLine());

            Console.WriteLine("Você quer saber o resultado? Y/N");
            if (Console.ReadLine() == "N")
            {
                Console.WriteLine("OPERAÇÃO CANCELADA");
            }
            else
            {
                Console.WriteLine($"O resultado é {multiplicando * multiplicador}");
            }
        }
    }
}
