using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quine
{
    class Program
    {
        static int numVariaveis;
        static List<Coluna> ExpressoesResultado;

        static void Main(string[] args)
        {
            List<Mintermo> ListaMintermos = CarregarMintermosDoTXT();

            QuineMcCluskey(ListaMintermos);

            Console.ReadLine();
        }

        public static List<Mintermo> CarregarMintermosDoTXT()
        {
            ArquivoTXT arquivo = new ArquivoTXT(@"\MapaKarnaugh.txt");

            List<Mintermo> ListaMintermos = arquivo.CarregarMintermos();

            numVariaveis = arquivo.PegarNumeroVariaveis();

            return ListaMintermos;
        }

        private static List<List<List<Coluna>>> CriarMatrizColunas(List<List<Mintermo>> MatrizColunasUns)
        {
            List<List<List<Coluna>>> MatrizColunasComparacao = new List<List<List<Coluna>>>();

            for (int i = 0; i < MatrizColunasUns.Count - 1; i++)
            {
                List<List<Coluna>> listaColunas = new List<List<Coluna>>();

                MatrizColunasComparacao.Add(listaColunas);
            }

            return MatrizColunasComparacao;
        }

        private static List<List<Mintermo>> SepararColunasUns(List<Mintermo> Mintermos)
        {
            List<List<Mintermo>> MatrizColunasUns = new List<List<Mintermo>>();

            for (int i = 0; i <= numVariaveis; i++)
            {
                List<Mintermo> listaColunas = new List<Mintermo>();

                MatrizColunasUns.Add(listaColunas);
            }

            foreach (var mintermo in Mintermos)
            {
                if (mintermo.Valor == 1 || mintermo.Valor == 2)
                {
                    short contadorUnsMintermo = 0;

                    foreach (char caracter in mintermo.Variaveis)
                    {
                        if (caracter == '1')
                        {
                            contadorUnsMintermo += 1;
                        }
                    }

                    if (contadorUnsMintermo == 0)
                    {
                        MatrizColunasUns[0].Add(mintermo);
                    }
                    else if (contadorUnsMintermo == 1)
                    {
                        MatrizColunasUns[1].Add(mintermo);
                    }
                    else if (contadorUnsMintermo == 2)
                    {
                        MatrizColunasUns[2].Add(mintermo);
                    }
                    else if (contadorUnsMintermo == 3)
                    {
                        MatrizColunasUns[3].Add(mintermo);
                    }
                    else if (contadorUnsMintermo == 4)
                    {
                        MatrizColunasUns[4].Add(mintermo);
                    }
                    else if (contadorUnsMintermo == 5)
                    {
                        MatrizColunasUns[5].Add(mintermo);
                    }
                }
            }

            Boolean temZerado = true;

            while (temZerado)
            {
                temZerado = false;

                foreach (var Coluna in MatrizColunasUns)
                {
                    if (Coluna.Count == 0)
                    {
                        MatrizColunasUns.Remove(Coluna);
                        temZerado = true;

                        break;
                    }
                }
            }

            ImprimirUnsAgrupados(MatrizColunasUns); /* Imprime as Colunas de Uns */

            return MatrizColunasUns;
        }

        private static void ImprimirUnsAgrupados(List<List<Mintermo>> MatrizMintermos)
        {
            var contadorLista = 0;

            Console.WriteLine();
            Console.WriteLine("*******************************************************************");
            Console.WriteLine("Conjuntos de uns agrupados");
            Console.WriteLine("-------------------------------------------------------------------");

            foreach (var listaMintermos in MatrizMintermos)
            {
                Console.WriteLine();

                foreach (var mintermo in listaMintermos)
                {
                    Console.WriteLine("'" + contadorLista + "' - " + mintermo.Variaveis + "(" + mintermo.Posicao + ")");
                }
                
                contadorLista += 1;
            }

            Console.WriteLine("-------------------------------------------------------------------");
        }

        private static void RodaAlgoritmo(List<List<Mintermo>> MatrizColunasUns, List<List<List<Coluna>>> MatrizColunasComparacao)
        {
            var numeroConjuntos = MatrizColunasUns.Count - 1;

            for (int i = 0; i < MatrizColunasUns.Count - 1; i++)
            {
                for (int j = 0; j < numeroConjuntos; j++)
                {
                    List<Coluna> ListaConjuntos = new List<Coluna>();
                    MatrizColunasComparacao[i].Add(ListaConjuntos);
                }

                numeroConjuntos -= 1;
            }
            
            // For que preenche a primeira Coluna da Matriz, a partir das Colunas de 1's
            for (int i = 0; i < MatrizColunasUns.Count; i++)
            {
                if (i + 1 < MatrizColunasUns.Count)
                {
                    foreach (Mintermo mintermo in MatrizColunasUns[i])
                    {
                        foreach (Mintermo mintermoAux in MatrizColunasUns[i + 1])
                        {
                            string variaveisAux = "";
                            short contador = 0;

                            for (int j = 0; j < numVariaveis; j++)
                            {
                                var caracter = mintermo.Variaveis.Substring(j, 1);
                                var caracterAux = mintermoAux.Variaveis.Substring(j, 1);

                                if (caracter == caracterAux)
                                {
                                    variaveisAux += caracter;
                                }
                                else
                                {
                                    variaveisAux += "_";
                                    contador += 1;
                                }
                            }

                            if (contador == 1)
                            {
                                Coluna coluna = new Coluna();
                                coluna.Variaveis = variaveisAux;

                                coluna.Mintermos.Add(mintermo.Posicao);
                                coluna.Mintermos.Add(mintermoAux.Posicao);

                                MatrizColunasComparacao[0][i].Add(coluna);
                            }
                        }
                    }

                }
            }

            var numeroDiferencas = 1;

            for (int i = 0; i < MatrizColunasComparacao.Count - 1; i++) // For mais externo, de acordo com o número de colunas..
            {
                for (int j = 0; j < MatrizColunasComparacao[i].Count; j++)
                {
                    if (j + 1 < MatrizColunasComparacao[i].Count)
                    {
                        for (int k = 0; k < MatrizColunasComparacao[i][j].Count; k++)
                        {
                            var ColunaMintermos = MatrizColunasComparacao[i][j][k];

                            for (int h = 0; h < MatrizColunasComparacao[i][j + 1].Count; h++)
                            {
                                var ColunaMintermosAux = MatrizColunasComparacao[i][j + 1][h];

                                string variaveisAux = "";
                                short contador = 0;

                                for (int quantCaracteres = 0; quantCaracteres < numVariaveis; quantCaracteres++)
                                {
                                    var caracter = ColunaMintermos.Variaveis.Substring(quantCaracteres, 1);
                                    var caracterAux = ColunaMintermosAux.Variaveis.Substring(quantCaracteres, 1);

                                    if (caracter == caracterAux)
                                    {
                                        variaveisAux += caracter;
                                    }
                                    else
                                    {
                                        variaveisAux += "_";
                                        contador += 1;
                                    }
                                }

                                if (contador == numeroDiferencas)
                                {
                                    Coluna coluna = new Coluna();
                                    coluna.Variaveis = variaveisAux;

                                    var naoTem = false;

                                    foreach (var item in MatrizColunasComparacao[i + 1][j])
                                    {
                                        if (variaveisAux == item.Variaveis)
                                        {
                                            naoTem = true;
                                        }
                                    }

                                    if (!naoTem)
                                    {
                                        foreach (var mintermo in ColunaMintermos.Mintermos)
                                        {
                                            coluna.Mintermos.Add(mintermo);
                                        }

                                        foreach (var mintermoAux in ColunaMintermosAux.Mintermos)
                                        {
                                            coluna.Mintermos.Add(mintermoAux);
                                        }

                                        MatrizColunasComparacao[i + 1][j].Add(coluna);
                                    }
                                }
                            }
                        }
                    }
                }
            }

            ImprimirColunas(MatrizColunasComparacao);

            ExpressoesResultado = new List<Coluna>();

            //foreach (var listas in MatrizColunas)
            //{
            //    foreach (var mintermos in listas)
            //    {
            //        foreach (var item in mintermos)
            //        {
            //            if (!item.Marcado)
            //            {
            //                Console.WriteLine("Transportando para a tabela de cobertura: " + item.Variaveis);
            //                ExpressoesResultado.Add(item);
            //            }
            //        }
            //    }
            //}
            
        }
        
        private static void ImprimirColunas(List<List<List<Coluna>>> MatrizColunasComparacao)
        {
            string alfabeto = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            Console.WriteLine();
            Console.WriteLine("*******************************************************************");
            Console.WriteLine("Colunas de Comparações");
            
            for (int i = 0; i < MatrizColunasComparacao.Count; i++)
            {
                Console.WriteLine("-------------------------------------------------------------------");

                for (int j = 0; j < MatrizColunasComparacao[i].Count; j++)
                {

                    for (int k = 0; k < MatrizColunasComparacao[i][j].Count; k++)
                    {
                        Console.WriteLine();
                        Console.Write(alfabeto[i].ToString() + j + " - " + MatrizColunasComparacao[i][j][k].Variaveis);
                       
                        foreach (var mintermo in MatrizColunasComparacao[i][j][k].Mintermos)
                        {
                            Console.Write(" (" + mintermo + ")");
                        }
                    }

                    Console.WriteLine();
                }
            }
        }

        private static List<int> FazerTabelaCobertura(List<Mintermo> Mintermos, ref List<Coluna> ExpressoesResultado)
        {
            List<int> TabelaCobertura = new List<int>();
            Boolean estaCoberto = false;

            foreach (var expressao in ExpressoesResultado)
            {
                foreach (var mintermo in expressao.Mintermos)
                {
                    foreach (var mintermoCoberto in TabelaCobertura)
                    {
                        if (mintermo == mintermoCoberto)
                            estaCoberto = true;
                    }

                    if (estaCoberto == false)
                    {
                        if (Mintermos[mintermo].Valor == 1)
                            TabelaCobertura.Add(mintermo);
                    }

                }
            }

            List<int> DontCares = new List<int>();

            Boolean ehDontCare = true;
            foreach (var expressao in ExpressoesResultado)
            {
                foreach (var mintermo in expressao.Mintermos)
                {
                    ehDontCare = true;
                    foreach (var mintermoCobertura in TabelaCobertura)
                    {
                        if (mintermo == mintermoCobertura)
                            ehDontCare = false;
                    }

                    if (ehDontCare == true)
                    {
                        if (!DontCares.Contains(mintermo))
                            DontCares.Add(mintermo);
                    }
                }

            }

            Boolean terminouDontCares = false;
            Boolean terminouFor = false;

            var contador = 0;

            while (terminouDontCares == false)
            {
                contador = 0;

                foreach (var expressao in ExpressoesResultado)
                {
                    foreach (var mintermo in expressao.Mintermos)
                    {
                        terminouFor = false;
                        foreach (var dontCare in DontCares)
                        {
                            if (mintermo == dontCare)
                            {
                                expressao.Mintermos.Remove(mintermo);
                                terminouFor = true;
                                contador += 1;
                                break;
                            }
                        }

                        if (terminouFor)
                            break;
                    }
                }

                if (contador == 0)
                    terminouDontCares = true;

            }

            List<Coluna> Conjuntos = new List<Coluna>();
            Boolean ehMaior = true;

            while (ExpressoesResultado.Count > 0)
            {
                foreach (var expressao in ExpressoesResultado)
                {
                    ehMaior = true;

                    foreach (var expressaoAux in ExpressoesResultado)
                    {
                        if (expressao.Mintermos.Count < expressaoAux.Mintermos.Count)
                            ehMaior = false;

                    }

                    if (ehMaior == true)
                    {
                        Conjuntos.Add(expressao);
                        ExpressoesResultado.Remove(expressao);
                        break;
                    }
                }
            }

            ExpressoesResultado = Conjuntos;
            TabelaCobertura.Sort();

            return TabelaCobertura;
        }

        private static void FinalizarAlgoritmo(List<int> TabelaCobertura, List<Coluna> ExpressoesResultado)
        {
            foreach (var expressao in ExpressoesResultado)
            {
                foreach (var mintermo in expressao.Mintermos)
                {
                    if (TabelaCobertura.Contains(mintermo))
                    {
                        expressao.Marcado = true;
                        TabelaCobertura.Remove(mintermo);
                    }
                }
            }

            //Console.WriteLine("Resultado final:");

            foreach (var expressao in ExpressoesResultado)
            {
                if (expressao.Marcado)
                {
                    Console.WriteLine(expressao.Variaveis);
                }
            }
        }

        private static void QuineMcCluskey(List<Mintermo> Mintermos)
        {
            Console.WriteLine("Algoritmo de Quine McCluskey");

            List<List<Mintermo>> MatrizColunasUns = SepararColunasUns(Mintermos); /* Aloca memória */

            List<List<List<Coluna>>> MatrizColunasComparacao = CriarMatrizColunas(MatrizColunasUns); /* Aloca memória */

            RodaAlgoritmo(MatrizColunasUns, MatrizColunasComparacao);

            List<int> TabelaCobertura = FazerTabelaCobertura(Mintermos, ref ExpressoesResultado);

            Console.WriteLine();

            FinalizarAlgoritmo(TabelaCobertura, ExpressoesResultado);
        }
    }
}