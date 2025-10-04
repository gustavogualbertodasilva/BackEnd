using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

class Program
{
    static void Main()
    {
        ProdutoStruct Produto1 = new ProdutoStruct();
        ProdutoClasse Produto2 = new ProdutoClasse();
        Produto1.Nome = "Software";
        Produto1.Price = 625.5m;
        Produto2.Nome = "Site";
        Produto2.Price = 340.0m;
        System.Console.WriteLine($"Produto 1 = {Produto1.Nome} {Produto1.Price}");
        System.Console.WriteLine($"Produto 2 = {Produto2.Nome} {Produto2.Price}");
        MudarSegundaVariavel(ref Produto2);
        System.Console.WriteLine("Mudando Produto 2");
        System.Console.WriteLine($"Produto 2 = {Produto2.Nome} {Produto2.Price}");
    }

    static void MudarSegundaVariavel(ref ProdutoClasse p)
    {
        p.Nome = "App";
        p.Price = 1200m;
    }

    struct ProdutoStruct
    {
        public string Nome;
        public decimal Price;
    }

    class ProdutoClasse
    {
        public string Nome;
        public decimal Price;
    }
}