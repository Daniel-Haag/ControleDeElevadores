using System;
using ControleDeElevadores.Services;

namespace ControleDeElevadores
{
    class Program
    {
        static void Main(string[] args)
        {
            ElevadorService es = new ElevadorService();

            es.andarMenosUtilizado();
            es.elevadorMaisFrequentado();
            es.elevadorMenosFrequentado();

            Console.Read();

        }
    }
}

