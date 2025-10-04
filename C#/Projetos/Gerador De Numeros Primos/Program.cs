using System;
using System.Diagnostics;
using System.Numerics;

class MersenneHunter
{
    static void Main()
    {
        Console.WriteLine("== CAÇADOR INFINITO DE PRIMOS DE MERSENNE ==\n");

        int p = 2;

        while (true)
        {
            if (!EhPrimo(p))
            {
                p++;
                continue;
            }

            Stopwatch cronometro = Stopwatch.StartNew();

            Console.WriteLine($"Testando M{p} = 2^{p} - 1 ...");
            BigInteger mersenne = BigInteger.Pow(2, p) - 1;

            bool ehPrimo = EhPrimoBig(mersenne);

            cronometro.Stop();
            TimeSpan tempo = cronometro.Elapsed;

            if (ehPrimo)
            {
                Console.WriteLine($"✅ M{p} É PRIMO! ({mersenne})");
            }
            else
            {
                Console.WriteLine($"❌ M{p} não é primo.");
            }

            Console.WriteLine($"⏱ Tempo: {tempo.TotalSeconds:F2} segundos\n");

            p++;
        }
    }

    static bool EhPrimo(int numero)
    {
        if (numero < 2) return false;
        for (int i = 2; i * i <= numero; i++)
            if (numero % i == 0)
                return false;
        return true;
    }

    static bool EhPrimoBig(BigInteger numero)
    {
        if (numero < 2) return false;

        BigInteger limite = RaizQuadrada(numero);
        for (BigInteger i = 2; i <= limite; i++)
            if (numero % i == 0)
                return false;

        return true;
    }

    // Função para calcular a raiz quadrada de um BigInteger
    static BigInteger RaizQuadrada(BigInteger numero)
    {
        BigInteger low = 1, high = numero;
        while (low <= high)
        {
            BigInteger mid = (low + high) / 2;
            BigInteger quadrado = mid * mid;

            if (quadrado == numero)
                return mid;
            else if (quadrado < numero)
                low = mid + 1;
            else
                high = mid - 1;
        }

        return high;
    }
}
