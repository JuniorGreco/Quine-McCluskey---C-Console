using System.Collections.Generic;

namespace quine
{
    public class Coluna
    {
        public bool Marcado;

        public string Variaveis;

        public List<int> Mintermos;

        public List<int> MintermosPrimosEssenciais;

        public List<int> MintermosPrimosSemDontCare;

        public int QuantidadePrimos;

        public int QuantidadePrimosEssenciais;

        public Coluna()
        {
            Mintermos = new List<int>();

            MintermosPrimosEssenciais = new List<int>();

            MintermosPrimosSemDontCare = new List<int>();

            Marcado = false;
        }
    }
}
