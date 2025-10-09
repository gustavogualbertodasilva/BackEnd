using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    static void Main()
    {
        (string a, int b, bool c) pessoa = CadastrarPessoa("joao", 17);
        System.Console.WriteLine($"Nome: {pessoa.a}, Idade: {pessoa.b}, Maior? = {pessoa.c} ");
    }

    public static (string nome,int idade, bool maiorDeIdade) CadastrarPessoa(string a, int b)
    {
        bool c;
        if (b >= 18)
        {
            c = true;
        }
        else
        {
            c = false;
        }
        return (a, b, c);
    }
}