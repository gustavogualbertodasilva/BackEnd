﻿using System;
using System.Collections.Generic;
using System.Threading;

class Usuario
{
    public string Username { get; set; }
    public string Senha { get; set; }

    public Usuario(string username, string senha)
    {
        Username = username;
        Senha = senha;
    }
}

class Program
{
    public static bool IsLog = false;   //VERIFICA SE O USUARIO ESTÁ LOGADO
    public static bool UserExiste = false; //VERIFICA SE O NOME DE USUARIO EXISTE, PARA PROSSEGUIR NO CADASTRO
    public static bool RepeatCadOurLog = true; //REPEAT O LAÇO PARA REPETIR CADASTRAR OU LOGAR
    public static bool RepeatCad = true; //SE ALGO DE ERRADO ACONTECER, O CADASTRO RESETA
    public static bool RepeatCadSenha = true; //SE A SENHA ESTIVER DE ALGUMA MANEIRA INCORRETA OU INAPROPRIADA PARA CONTINUAÇÃO, REPETE A PERGUNTA
    public static string NewUsarname = "";  //GUARDA O USUARIO A SER CADASTRADO
    public static string NewSenha = "";     // GUARDA A SENHA DO USUARIO A SER CADASTRADO
    public static string AcesssUsername = ""; // GUARDA O NOME DE USUARIO DIGITADO NA OPÇÃO DE LOGIN PARA VERIFICAR SE ALGO ESTA ERRADO
    public static string AcessSenha = ""; //GUARDA A SENHA DO USUARIO NA OPÇÃO PARA VERIFICAR SE ALGO DE ERRADO  
    public static string LogOptions = ""; //GUARDA O VALOR DIGITADO PELO USUARIO NA OPÇÃO DE OPÇÕES DE LOGIN
    public static bool RepeatLogOptions = true; //SE O VALOR DIGITADO PELO USUARIO FOR DE ALGUMA FORMA INCORRETA OU INAPROPRIADO, REPETE A LogOptions
    public static string TrocarSenhaAtual; //GUARDA A SENHA DIGITADA PELO USUARIO PARA VERIFICAR SE A MESMA É IGUAL A SENHA DO USUARIO NO MENU DE TROCAR SENHA 
    public static string TrocarSenha; //GUARDA A NOVA SENHA QUE O USUARIO DIGITOU PARA VERIFICAR SE ALGO ESTA ERRADO E TROCAR A SENHA DEFINITIVAMENTE
    public static string CriptografiaOptions; //GUARDA O VALOR DIGITADO PELO USUARIO NA OPÇÃO DE CRIPTOGRADAR
    public static string DsCriOptions;  // GUARDA O VALOR DIGITADO PELO USUARIO NA OPÇÃO DESCRIPTOGRAFAR
    public static bool RepeatDsCriOptions = true; //VERIFICA SE O VALOR DIGITADO É APROPRIADO, SE NÃO FOR, REPETE A  DsCriOptions
    public static bool RepeatLogSenha = true; //VERIFICA SE A SENHA É INCORRETA E RODA O LOOP DE SENHA
    public static bool RepeatUsername = true; //VERIFICA SE O NOME DE USUARIO EXISTE E SE NÃO EXISTIR REPETE A PERGUNTA (LOG)
    public static bool RepeatTrocarSenha = false; //REPETE A VERIFICAÇÃO DE SENHA ATUAL ANTES DE TROCAR A SENHA
    public static bool TrocarSenhaVSA = true; //VERIFICA SE O USUARIO JA PASSOU DA PARTE DE DIGITAR SENHA ATUAL

    //CODIGO EXECUTADO LOGO NO INICIO DO SISTEMA

    static void Main()
    {
        List<Usuario> usuarios = new List<Usuario>();  
        usuarios.Add(new Usuario("a", "s"));
        Console.Clear();
        Console.WriteLine(" ");
        Console.WriteLine(" ");
        Console.WriteLine(" ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Bem Vindo Ao Sistema De Criptografia De Textos");

        while (RepeatCadOurLog)
        {
            Thread.Sleep(1500);
            Console.WriteLine(" ");
            Thread.Sleep(150);
            Console.WriteLine(" ");
            Thread.Sleep(150);
            Console.WriteLine(" ");
            RepeatCad = true;
            RepeatCadSenha = true;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Seu Cadastro Não Fica Salvo, Isso é Um Sistema Feito Para Pratica (SEM BANCO DE DADOS)");
            Thread.Sleep(500);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Você quer Fazer Login Ou Cadastrar L/C");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            string CadOurLog = Console.ReadLine().ToUpper();
            if (CadOurLog == "L")
            {   
                RepeatLogSenha = true;
                RepeatUsername = true;
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("Para Fazer Seu Login, Siga Os Seguintes Passos:");
                Thread.Sleep(500);
                while(RepeatUsername == true)
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("Digite Seu Nome De Usuario.");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    AcesssUsername = Console.ReadLine();
                    bool usuarioEncontrado = false;

                    foreach (var Usuar in usuarios)
                    {
                        if (Usuar.Username == AcesssUsername)
                        {
                            RepeatLogSenha = true;
                            usuarioEncontrado = true;
                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                            while(RepeatLogSenha == true)
                            {
                                Console.WriteLine("Digite Sua Senha");
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                AcessSenha = Console.ReadLine();
                                
                                if (Usuar.Senha == AcessSenha)
                                {
                                    RepeatLogSenha = false;
                                    RepeatUsername = false;
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Thread.Sleep(400);
                                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                                    Console.WriteLine($"Usuario {AcesssUsername} Logado Com Sucesso");

                                    // Opções após login
                                    Console.WriteLine("");
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.WriteLine("O Que Deseja Fazer?");
                                    Console.ForegroundColor = ConsoleColor.DarkGray;
                                    Thread.Sleep(500);
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.Write("1- Ir para Seção de ");
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine("CRIPTOGRAFIA");
                                    Console.ForegroundColor = ConsoleColor.DarkGray;
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Thread.Sleep(500);
                                    Console.Write("2- ");
                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine("Descriptografar");
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Thread.Sleep(500);
                                    Console.Write("3- Mudar ");
                                    Console.ForegroundColor = ConsoleColor.Gray;
                                    Console.WriteLine("Senha");
                                    Console.ForegroundColor = ConsoleColor.DarkGray;
                                    Thread.Sleep(500);
                                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                                    Console.Write("4- ");
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Deslogar");
                                    Console.ForegroundColor = ConsoleColor.DarkGray;
                                    LogOptions = Console.ReadLine();
                                    
                                    if (LogOptions == "1" || LogOptions == "2" || LogOptions == "3" || LogOptions == "4")
                                    {
                                        if (LogOptions == "1")
                                        {
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Console.WriteLine("Que Criptografia Você Quer Usar?");
                                            Thread.Sleep(500);
                                            Console.ForegroundColor = ConsoleColor.Cyan;
                                            Console.WriteLine("1- Cifra de Substituição Simples.");
                                            Thread.Sleep(500);
                                            Console.WriteLine("2- Codigo Binario.");
                                            Thread.Sleep(500);
                                            Console.WriteLine("3- Codigo Morse.");
                                            Console.ForegroundColor = ConsoleColor.Gray;
                                            CriptografiaOptions = Console.ReadLine();

                                            if (CriptografiaOptions == "1")
                                            {
                                                css();
                                            }
                                            else if (CriptografiaOptions == "2")
                                            {
                                                CodBin();
                                            }
                                            else if (CriptografiaOptions == "3")
                                            {
                                                CodMorse();
                                            }
                                        }
                                        else if (LogOptions == "2")
                                        {
                                            RepeatDsCriOptions = true;
                                            while (RepeatDsCriOptions == true)
                                            {
                                                Console.ForegroundColor = ConsoleColor.Yellow;
                                                Console.WriteLine("Que Criptografia Você Deseja Traduzir?");
                                                Thread.Sleep(500);
                                                Console.ForegroundColor = ConsoleColor.Yellow;
                                                Console.Write("1- ");
                                                Console.ForegroundColor = ConsoleColor.Green;
                                                Console.WriteLine("Cifra De Substituição Simples");
                                                Thread.Sleep(500);
                                                Console.ForegroundColor = ConsoleColor.Yellow;
                                                Console.Write("2- ");
                                                Console.ForegroundColor = ConsoleColor.Green;
                                                Console.WriteLine("Codigo Binario");
                                                Thread.Sleep(500);
                                                Console.ForegroundColor = ConsoleColor.Yellow;
                                                Console.Write("3- ");
                                                Console.ForegroundColor = ConsoleColor.Green;
                                                Console.WriteLine("Codigo Morse");
                                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                                DsCriOptions = Console.ReadLine();
                                                RepeatDsCriOptions = true;
                                                if (DsCriOptions == "1")
                                                {
                                                    DsCriCss();
                                                    RepeatCadOurLog = false;
                                                }
                                                else if (DsCriOptions == "2")
                                                {
                                                    DsCriBinario();
                                                    RepeatCadOurLog = false;
                                                }

                                                else if (DsCriOptions == "3")
                                                {
                                                    DsCriMorse();
                                                    RepeatCadOurLog = false;
                                                }
                                                else
                                                {
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("Digite Um Valor Valido");
                                                    Console.WriteLine(" ");
                                                    RepeatDsCriOptions = true;
                                                }
                                            }          
                                        }
                                        else if (LogOptions == "3")
                                        {
                                            RepeatTrocarSenha = true;
                                            Console.ForegroundColor = ConsoleColor.Gray;
                                            Console.WriteLine("Para Mudar Sua Senha");
                                            Thread.Sleep(400);
                                            Console.WriteLine(" ");

                                            while(RepeatTrocarSenha == true)
                                            {
                                                if(TrocarSenhaVSA == true)
                                                {
                                                Console.ForegroundColor = ConsoleColor.White;
                                                Console.WriteLine("Digite Sua Senha Atual");
                                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                                TrocarSenhaAtual = Console.ReadLine();
                                                }

                                                foreach (var NewSenhaUser in usuarios)
                                                {
                                                    if (NewSenhaUser.Username == AcesssUsername)
                                                    {
                                                        if (TrocarSenhaAtual == NewSenhaUser.Senha)
                                                        {
                                                            TrocarSenhaVSA = true;
                                                            RepeatTrocarSenha = false;
                                                            Console.ForegroundColor = ConsoleColor.White;
                                                            Console.WriteLine("Digite Sua Nova Senha 7-20 Caracteres");
                                                            Console.ForegroundColor = ConsoleColor.DarkGray;
                                                            TrocarSenha = Console.ReadLine();
                                                            if (TrocarSenha.Length >= 7 && TrocarSenha.Length <= 20)
                                                            {
                                                                if (NewSenhaUser.Senha == TrocarSenha)
                                                                {
                                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                                    Console.WriteLine("Você Não Pode Trocar Sua Senha Para Ela Mesma...");
                                                                    RepeatTrocarSenha = true;
                                                                }
                                                                else
                                                                {
                                                                    Thread.Sleep(1000);
                                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                                    Console.WriteLine("Senha Alterada Com Sucesso!");
                                                                    NewSenhaUser.Senha = TrocarSenha;
                                                                    RepeatTrocarSenha = false;
                                                                    IsLog = true;
                                                                    RepeatCadOurLog = true;
                                                                    RepeatLogOptions = true;
                                                                }
                                                            }
                                                            else
                                                            {
                                                                Console.ForegroundColor = ConsoleColor.Red;
                                                                Console.WriteLine("A senha deve ter entre 7 e 20 caracteres!");
                                                                RepeatTrocarSenha = true;
                                                                TrocarSenhaVSA = false;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            Console.ForegroundColor = ConsoleColor.Red;
                                                            Console.Write("ERRO 001 Diz: ");
                                                            Console.ForegroundColor = ConsoleColor.DarkRed;
                                                            Console.WriteLine("Senha Incorreta");
                                                            RepeatTrocarSenha = true;
                                                            TrocarSenhaVSA = true;
                                                        }
                                                        
                                                    }
                                                }
                                            }
                                        }
                                        else if (LogOptions == "4")
                                        {
                                            Console.Write("Saindo");
                                            Thread.Sleep(300);
                                            Console.Write(".");
                                            Thread.Sleep(300);
                                            Console.Write(".");
                                            Thread.Sleep(300);
                                            Console.Write(".");
                                            Thread.Sleep(300);
                                            Console.Write("\b \b");
                                            Thread.Sleep(300);
                                            Console.Write("\b \b");
                                            Thread.Sleep(300);
                                            Console.Write("\b \b");
                                            Thread.Sleep(300);
                                            Console.WriteLine(".");
                                            Thread.Sleep(200);
                                            IsLog = false;
                                            RepeatCadOurLog = true;
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Digite Um Numero Valido");
                                        Thread.Sleep(1500);
                                    }
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("SENHA INCORRETA");
                                    Thread.Sleep(1500);
                                }
                            }
                        }
                    }

                    if (!usuarioEncontrado)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("Esse Usuario Não Existe. Tente Novamente");
                        Thread.Sleep(750);
                        Console.Write(".");
                        Thread.Sleep(750);
                        Console.Write(".");
                        Thread.Sleep(750);
                        Console.WriteLine(".");
                        Thread.Sleep(300);
                        RepeatUsername = true;
                    }

                }
            }
            else if (CadOurLog == "C")
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Para Fazer Seu Cadastro, Siga Os Seguintes Passos:");

                while (RepeatCad)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine("\nDigite Um Nome De Usuario (4 - 15 Caracteres)");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    NewUsarname = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Green;

                    if (NewUsarname.Length >= 4 && NewUsarname.Length <= 15)
                    {
                        bool usuarioExiste = usuarios.Exists(u => u.Username == NewUsarname);

                        if (usuarioExiste)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Já Existe Um Usuário Com Esse Nome");
                        }
                        else
                        {
                            RepeatCad = false;
                            while (RepeatCadSenha)
                            {
                                Console.WriteLine("Digite Sua Senha (Entre 7 - 20 Caracteres)");
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                NewSenha = Console.ReadLine();
                                Console.ForegroundColor = ConsoleColor.Green;

                                if (NewSenha.Length >= 7 && NewSenha.Length <= 20)
                                {
                                    usuarios.Add(new Usuario(NewUsarname, NewSenha));
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.WriteLine(".");
                                    Thread.Sleep(1000);
                                    Console.WriteLine(".");
                                    Thread.Sleep(1000);
                                    Console.WriteLine(".");
                                    Thread.Sleep(1000);
                                    Console.ForegroundColor = ConsoleColor.DarkMagenta;
                                    Console.WriteLine($"Usuário {NewUsarname} cadastrado com sucesso!");
                                    RepeatCadSenha = false;
                                    Console.ResetColor();
                                    Thread.Sleep(3000);
                                   
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("A senha deve ter entre 7 e 20 caracteres!");
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Digite um nome que tenha entre 4 - 15 caracteres");
                    }
                }
            }
            else
            {
                Console.WriteLine("Digite um valor válido");
            }
        }
    }

    public static void css()
    {
        Dictionary<char, int> CodLetras = new Dictionary<char, int>();
        CodLetras.Add('A', 1);   CodLetras.Add('G', 7);   CodLetras.Add('M', 13);  CodLetras.Add('S', 19);
        CodLetras.Add('B', 2);   CodLetras.Add('H', 8);   CodLetras.Add('N', 14);  CodLetras.Add('T', 20);
        CodLetras.Add('C', 3);   CodLetras.Add('I', 9);   CodLetras.Add('O', 15);  CodLetras.Add('U', 21);
        CodLetras.Add('D', 4);   CodLetras.Add('J', 10);  CodLetras.Add('P', 16);  CodLetras.Add('V', 22);
        CodLetras.Add('E', 5);   CodLetras.Add('K', 11);  CodLetras.Add('Q', 17);  CodLetras.Add('W', 23);
        CodLetras.Add('F', 6);   CodLetras.Add('L', 12);  CodLetras.Add('R', 18);  CodLetras.Add('X', 24);
        CodLetras.Add('Y', 25);  CodLetras.Add('Z', 26);  CodLetras.Add(' ', 0);

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("ESSE TIPO DE CRIPTGRAFIA NÃO ACEITA ACENTUAÇÃO OU CARACTERES ESPECIAIS");
        Thread.Sleep(500);
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Digite Um Texto Que Deseja Criptografar:");
        Console.ForegroundColor = ConsoleColor.Gray;
        string palavra = Console.ReadLine().ToUpper();
        char[] CodAcriptografar = palavra.ToCharArray();
        string result = "";
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write($"Texto Criptografado: ");
        
        foreach (var letras in CodAcriptografar)
        {
            if (CodLetras.ContainsKey(letras))
            {
                Console.Write("\u001b[38;2;0;204;0m");
                Console.Write($"{CodLetras[letras]}" + " ");
                Thread.Sleep(50);
            }
            else
            {   
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"{letras}");
            }
        }
        Console.ForegroundColor = ConsoleColor.Gray;
    }

    public static void CodBin()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("Digite um texto: ");
        Console.ForegroundColor = ConsoleColor.Gray;
        string texto = Console.ReadLine();
        Console.Write($"Texto Criptografado: ");
        Console.Write("\u001b[38;2;0;204;0m");
        foreach (char c in texto)
        {
            string binario = Convert.ToString((int)c, 2).PadLeft(8, '0');
            Thread.Sleep(50);
            Console.Write($"{binario}");
            Console.Write(" ");
        }
        Console.ForegroundColor = ConsoleColor.White;
    }

    public static void CodMorse()
    {
        Dictionary<char, string> morseCode = new Dictionary<char, string>()
        {
            {'A', ".-"},    {'B', "-..."},  {'C', "-.-."},  {'D', "-.."},   {'E', "."},
            {'F', "..-."},  {'G', "--."},   {'H', "...."},  {'I', ".."},    {'J', ".---"},
            {'K', "-.-"},   {'L', ".-.."},  {'M', "--"},    {'N', "-."},    {'O', "---"},
            {'P', ".--."},  {'Q', "--.-"},  {'R', ".-."},   {'S', "..."},   {'T', "-"},
            {'U', "..-"},   {'V', "...-"},  {'W', ".--"},   {'X', "-..-"},  {'Y', "-.--"},
            {'Z', "--.."},  
            {'0', "-----"}, {'1', ".----"}, {'2', "..---"}, {'3', "...--"}, {'4', "....-"},
            {'5', "....."}, {'6', "-...."}, {'7', "--..."}, {'8', "---.."}, {'9', "----."},
            {' ', "/"}
        };
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Esse Tipo De Criptografia Só Aceita Letras Numeros e Espaços.");
        Thread.Sleep(450);
        Console.WriteLine(" ");
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.Write("Digite um texto: ");
        Console.ForegroundColor = ConsoleColor.White;
        string texto = Console.ReadLine().ToUpper();
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine("Texto Criptografado:");
        Console.Write("\u001b[38;2;0;204;0m");

        foreach (char c in texto)
        {
            if (morseCode.ContainsKey(c))
            {
                Console.Write(morseCode[c]);
                Console.Write(" ");
                Thread.Sleep(50);
            }
        }
    }
    public static void DsCriCss()
    {
        Dictionary<int, char> CssDs = new Dictionary<int, char>()
        {
            { 1, 'A' }, { 2, 'B' }, { 3, 'C' }, { 4, 'D' }, { 5, 'E' }, { 6, 'F' },
            { 7, 'G' }, { 8, 'H' }, { 9, 'I' }, { 10, 'J' }, { 11, 'K' }, { 12, 'L' },
            { 13, 'M' }, { 14, 'N' }, { 15, 'O' }, { 16, 'P' }, { 17, 'Q' }, { 18, 'R' },
            { 19, 'S' }, { 20, 'T' }, { 21, 'U' }, { 22, 'V' }, { 23, 'W' }, { 24, 'X' },
            { 25, 'Y' }, { 26, 'Z' }, { 27, ' ' }, { 0, ' ' }
        };

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Digite os números separados por espaço para traduzir:");
        Thread.Sleep(200);
        Console.WriteLine("Exemplo EX: 1 2 3 4");
        Console.WriteLine("Troque Os Espaços Por '0' Para Não Causar Conflitos");
        Console.ForegroundColor = ConsoleColor.DarkGray;
        string CssEntrada = Console.ReadLine();
        string[] numeros = CssEntrada.Split(' ');
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("Tradução: ");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        foreach (var num in numeros)
        {
            if (int.TryParse(num, out int chave) && CssDs.ContainsKey(chave))
            {
                Console.Write(CssDs[chave]);
                Thread.Sleep(100);
            }
            else
            {
                Console.Write("?");
            }
        }
        Console.WriteLine(" ");
    }

    public static void DsCriBinario()
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Digite o código binário para converter em texto (separado por espaço): ");
        Console.ForegroundColor = ConsoleColor.DarkGray;
        string entradaBinaria = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(entradaBinaria))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Erro: Entrada vazia. Digite um código binário válido.");
            Console.ResetColor();
        }
        else
        {
            string[] binarios = entradaBinaria.Split(' ');

            if (binarios.All(b => b.Length == 8 && b.All(c => c == '0' || c == '1')))
            {
                try
                {
                    string textoConvertido = string.Concat(binarios.Select(b => (char)Convert.ToInt32(b, 2)));
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Texto convertido: {textoConvertido}");
                    Console.ResetColor();
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Erro ao converter o código binário: {ex.Message}");
                    Console.ResetColor();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Erro: Entrada inválida. Certifique-se de inserir apenas números binários de 8 bits separados por espaço.");
                Console.ResetColor();
            }
        }
    }

    public static void DsCriMorse()
    {
        Dictionary<string, char> morseParaTexto = new Dictionary<string, char>()
        {
            { ".-", 'A' }, { "-...", 'B' }, { "-.-.", 'C' }, { "-..", 'D' }, { ".", 'E' }, { "..-.", 'F' },
            { "--.", 'G' }, { "....", 'H' }, { "..", 'I' }, { ".---", 'J' }, { "-.-", 'K' }, { ".-..", 'L' },
            { "--", 'M' }, { "-.", 'N' }, { "---", 'O' }, { ".--.", 'P' }, { "--.-", 'Q' }, { ".-.", 'R' },
            { "...", 'S' }, { "-", 'T' }, { "..-", 'U' }, { "...-", 'V' }, { ".--", 'W' }, { "-..-", 'X' },
            { "-.--", 'Y' }, { "--..", 'Z' }, { "-----", '0' }, { ".----", '1' }, { "..---", '2' },
            { "...--", '3' }, { "....-", '4' }, { ".....", '5' }, { "-....", '6' }, { "--...", '7' },
            { "---..", '8' }, { "----.", '9' }, { "/", ' ' }
        };

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Digite o código Morse (use espaço entre letras e '/' entre palavras):");
        Console.ForegroundColor = ConsoleColor.DarkGray;
        string entradaMorse = Console.ReadLine();
        string[] morseLetras = entradaMorse.Split(' ');
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("Texto traduzido: ");

        foreach (var morse in morseLetras)
        {
            if (morseParaTexto.ContainsKey(morse)) Console.Write(morseParaTexto[morse]);
            else Console.Write("?");
        }
        Console.WriteLine();
    }

}