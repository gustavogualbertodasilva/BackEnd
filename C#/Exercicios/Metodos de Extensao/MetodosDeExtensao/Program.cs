using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    public static string Nome;
    static void Main()
    {
        Console.ForegroundColor = ConsoleColor.Gray;
        System.Console.WriteLine("Digite Seu Nome");
        Console.ForegroundColor = ConsoleColor.White;
        Nome = Console.ReadLine();
        System.Console.WriteLine($"Seu nome digitado corretamente: {Nome.Capitalizar()}");
    }


}

public static class ClasseInutil
{
    public static string Capitalizar(this string input)
    {
        string output = "";
        if(input == null || input == "")
        {
            return null;
        }
        
        for (int i = 0; i < input.Length; i++)
        {
            if (i == 0)
            {
                output += input.ToUpper()[i];
            }
            else
            {
                output += input.ToLower()[i];
            }
        }
        return output;
    }
}