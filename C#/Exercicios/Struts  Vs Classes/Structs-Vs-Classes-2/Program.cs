using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    static void Main()
    {
        ObjetoStruct ob1 = new ObjetoStruct { StructString = "txt1", StructInt = 1 };
        ObjetoStruct ob2 = ob1;
        ob2.StructString = "txt2";
        ob2.StructInt = 2;
        System.Console.WriteLine($"{ob1.StructInt} {ob1.StructString} | {ob2.StructInt} {ob2.StructString}");
        System.Console.WriteLine("classes:");
        ObjetoClasse ob3 = new ObjetoClasse { ClasseString = "txt3", ClasseInt = 3 };
        ObjetoClasse ob4 = ob3;
        ob4.ClasseString = "txt4";
        ob4.ClasseInt = 4;
        System.Console.WriteLine($"{ob3.ClasseInt} {ob3.ClasseString} | {ob4.ClasseInt} {ob4.ClasseString}");
        
    }

    struct ObjetoStruct
    {
        public string StructString;
        public int StructInt;
    }

    class ObjetoClasse
    {
        public string ClasseString = "Essa é Uma String Da Classe";
        public int ClasseInt = 2;
    }
}