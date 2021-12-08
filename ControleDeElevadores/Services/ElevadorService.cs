using ControleDeElevadores.Models;
using Nancy.Json;
using ProvaAdmissionalCSharpApisul;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ControleDeElevadores.Services
{
    class ElevadorService : IElevadorService
    {
        public List<int> andarMenosUtilizado()
        {
            List<int> lista = new List<int>();

            lista = ReceberInputs().GroupBy(x => x.Andar).Where(g => g.Count() == 1).Select(g => g.Key).ToList();

            Console.WriteLine("Os andares menos utilizados são:");
            foreach (var item in lista)
            {
                Console.WriteLine(item.ToString());
            }

            return lista;
        }

        public List<char> elevadorMaisFrequentado()
        {
            List<char> lista = new List<char>();
            Dictionary<string, string> elevadoresUso = new Dictionary<string, string>();

            string elevadorMaisFrequentado = string.Empty;
            string elevadorMenosFrequentado = string.Empty;

            foreach (var linha in ReceberInputs().GroupBy(x => x.Elevador).Select(b => new { Elevador = b.Key, Count = b.Count() }).OrderBy(y => y.Count))
            {
                if (linha.Count >= 4)
                {
                    lista.Add(Convert.ToChar(linha.Elevador));
                }

                elevadoresUso.Add(linha.Elevador, linha.Count.ToString());
                elevadoresUso.OrderByDescending(x => x.Value);
            }

            elevadorMaisFrequentado = elevadoresUso.Last().Key;
            elevadorMenosFrequentado = elevadoresUso.First().Key;

            Console.WriteLine("O elevador mais frequentado é:");

            Console.WriteLine(elevadorMaisFrequentado);

            return lista;
        }

        public List<char> elevadorMenosFrequentado()
        {
            List<char> lista = new List<char>();
            Dictionary<string, string> elevadoresUso = new Dictionary<string, string>();

            string elevadorMaisFrequentado = string.Empty;
            string elevadorMenosFrequentado = string.Empty;

            foreach (var linha in ReceberInputs().GroupBy(x => x.Elevador).Select(b => new { Elevador = b.Key, Count = b.Count() }).OrderBy(y => y.Count))
            {
                if (linha.Count == 1)
                {
                    lista.Add(Convert.ToChar(linha.Elevador));
                }

                elevadoresUso.Add(linha.Elevador, linha.Count.ToString());
                elevadoresUso.OrderByDescending(x => x.Value);
            }

            elevadorMaisFrequentado = elevadoresUso.Last().Key;
            elevadorMenosFrequentado = elevadoresUso.First().Key;

            Console.WriteLine("O elevador menos frequentado é:");
            Console.WriteLine(elevadorMenosFrequentado);

            return lista;
        }

        public float percentualDeUsoElevadorA()
        {
            throw new NotImplementedException();
        }

        public float percentualDeUsoElevadorB()
        {
            throw new NotImplementedException();
        }

        public float percentualDeUsoElevadorC()
        {
            throw new NotImplementedException();
        }

        public float percentualDeUsoElevadorD()
        {
            throw new NotImplementedException();
        }

        public float percentualDeUsoElevadorE()
        {
            throw new NotImplementedException();
        }

        public List<char> periodoMaiorFluxoElevadorMaisFrequentado()
        {
            throw new NotImplementedException();
        }

        public List<char> periodoMaiorUtilizacaoConjuntoElevadores()
        {
            throw new NotImplementedException();
        }

        public List<char> periodoMenorFluxoElevadorMenosFrequentado()
        {
            throw new NotImplementedException();
        }

        private static List<ElevadorModel> ReceberInputs()
        {
            using (StreamReader leitor = new StreamReader("../../../input.json"))
            {
                var json = leitor.ReadToEnd();
                JavaScriptSerializer serializador = new JavaScriptSerializer();
                List<ElevadorModel> Lista = serializador.Deserialize<List<ElevadorModel>>(json);
                return Lista;
            }
        }
    }
}
