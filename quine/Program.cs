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

        private static List<List<Mintermo>> CriarMatrizMintermos()
        {
            List<List<Mintermo>> MatrizMintermos = new List<List<Mintermo>>();

            for (int i = 0; i <= numVariaveis; i++)
            {
                List<Mintermo> listaColunas = new List<Mintermo>();

                MatrizMintermos.Add(listaColunas);
            }

            return MatrizMintermos;
        }

        private static List<List<List<Coluna>>> CriarMatrizColunas()
        {
            List<List<List<Coluna>>> MatrizColunasComparacao = new List<List<List<Coluna>>>();

            for (int i = 0; i < numVariaveis; i++)
            {
                List<List<Coluna>> listaColunas = new List<List<Coluna>>();

                MatrizColunasComparacao.Add(listaColunas);
            }

            return MatrizColunasComparacao;
        }

        private static List<List<Mintermo>> SepararColunasUns(List<Mintermo> Mintermos, List<List<Mintermo>> MatrizColunasUns)
        {
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
            
            ImprimirColunasOnSet(MatrizColunasUns); /* Imprime as Colunas de Uns */

            return MatrizColunasUns;
        }

        private static void ImprimirColunasOnSet(List<List<Mintermo>> MatrizMintermos)
        {
            foreach (var mintermo in MatrizMintermos[0])
            {
                Console.WriteLine("Conjunto 0: " + mintermo.Variaveis);
            }

            Console.WriteLine();

            foreach (var mintermo in MatrizMintermos[1])
            {
                Console.WriteLine("Conjunto 1: " + mintermo.Variaveis);
            }

            Console.WriteLine();

            foreach (var mintermo in MatrizMintermos[2])
            {
                Console.WriteLine("Conjunto 2: " + mintermo.Variaveis);
            }

            Console.WriteLine();

            foreach (var mintermo in MatrizMintermos[3])
            {
                Console.WriteLine("Conjunto 3: " + mintermo.Variaveis);
            }

            Console.WriteLine();

            foreach (var mintermo in MatrizMintermos[4])
            {
                Console.WriteLine("Conjunto 4: " + mintermo.Variaveis);
            }

            Console.WriteLine();

            foreach (var mintermo in MatrizMintermos[5])
            {
                Console.WriteLine("Conjunto 5: " + mintermo.Variaveis);
            }

        }

        private static void RodaAlgoritmo(List<List<Mintermo>> MatrizMintermos, List<List<List<Coluna>>> MatrizColunas)
        {
            List<Coluna> ColunaA1 = new List<Coluna>();
            List<Coluna> ColunaA2 = new List<Coluna>();
            List<Coluna> ColunaA3 = new List<Coluna>();
            List<Coluna> ColunaA4 = new List<Coluna>();

            foreach (var mintermo in MatrizMintermos[0])
            {
                foreach (var mintermoAux in MatrizMintermos[1])
                {
                    string variaveisAux = "";
                    Int16 contador = 0;

                    for (int i = 0; i < numVariaveis; i++)
                    {
                        var caracter = mintermo.Variaveis.Substring(i, 1);
                        var caracterAux = mintermoAux.Variaveis.Substring(i, 1);

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

                        ColunaA1.Add(coluna);
                    }
                }
            }

            foreach (var mintermo in MatrizMintermos[1])
            {
                foreach (var mintermoAux in MatrizMintermos[2])
                {
                    string variaveisAux = "";
                    Int16 contador = 0;

                    for (int i = 0; i < numVariaveis; i++)
                    {
                        var caracter = mintermo.Variaveis.Substring(i, 1);
                        var caracterAux = mintermoAux.Variaveis.Substring(i, 1);

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

                        ColunaA2.Add(coluna);
                    }
                }
            }

            foreach (var mintermo in MatrizMintermos[2])
            {
                foreach (var mintermoAux in MatrizMintermos[3])
                {
                    string variaveisAux = "";
                    Int16 contador = 0;

                    for (int i = 0; i < numVariaveis; i++)
                    {
                        var caracter = mintermo.Variaveis.Substring(i, 1);
                        var caracterAux = mintermoAux.Variaveis.Substring(i, 1);

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

                        ColunaA3.Add(coluna);
                    }
                }
            }

            foreach (var mintermo in MatrizMintermos[3])
            {
                foreach (var mintermoAux in MatrizMintermos[4])
                {
                    string variaveisAux = "";
                    Int16 contador = 0;

                    for (int i = 0; i < numVariaveis; i++)
                    {
                        var caracter = mintermo.Variaveis.Substring(i, 1);
                        var caracterAux = mintermoAux.Variaveis.Substring(i, 1);

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

                        ColunaA4.Add(coluna);
                    }
                }
            }

            // ---------------------------------------------

            Console.WriteLine();
            Console.Write("Coluna A1 ");
            Console.WriteLine();

            foreach (var elemento in ColunaA1)
            {
                Console.Write("Mintermos:");

                foreach (var mintermo in elemento.Mintermos)
                {
                    Console.Write(" " + mintermo);
                }

                Console.Write(" Elemento: " + elemento.Variaveis);

                Console.WriteLine();
            }

            Console.WriteLine();
            Console.Write("Coluna A2 ");
            Console.WriteLine();

            foreach (var elemento in ColunaA2)
            {
                Console.Write("Mintermos:");

                foreach (var mintermo in elemento.Mintermos)
                {
                    Console.Write(" " + mintermo);
                }

                Console.Write(" Elemento: " + elemento.Variaveis);

                Console.WriteLine();
            }

            Console.WriteLine();
            Console.Write("Coluna A3 ");
            Console.WriteLine();

            foreach (var elemento in ColunaA3)
            {
                Console.Write("Mintermos:");

                foreach (var mintermo in elemento.Mintermos)
                {
                    Console.Write(" " + mintermo);
                }

                Console.Write(" Elemento: " + elemento.Variaveis);

                Console.WriteLine();
            }

            Console.WriteLine();
            Console.Write("Coluna A4 ");
            Console.WriteLine();

            foreach (var elemento in ColunaA4)
            {
                Console.Write("Mintermos:");

                foreach (var mintermo in elemento.Mintermos)
                {
                    Console.Write(" " + mintermo);
                }

                Console.Write(" Elemento: " + elemento.Variaveis);

                Console.WriteLine();
            }

            MatrizColunas[0].Add(ColunaA1);
            MatrizColunas[0].Add(ColunaA2);
            MatrizColunas[0].Add(ColunaA3);
            MatrizColunas[0].Add(ColunaA4);

            FazerColunas2(MatrizColunas);
        }

        private static void FazerColunas2(List<List<List<Coluna>>> MatrizColunas)
        {
            List<Coluna> ColunaB1 = new List<Coluna>();
            List<Coluna> ColunaB2 = new List<Coluna>();
            List<Coluna> ColunaB3 = new List<Coluna>();

            foreach (var mintermo in MatrizColunas[0][0])
            {
                foreach (var mintermoAux in MatrizColunas[0][1])
                {
                    string variaveisAux = "";
                    Int16 contador = 0;

                    for (int i = 0; i < numVariaveis; i++)
                    {
                        var caracter = mintermo.Variaveis.Substring(i, 1);
                        var caracterAux = mintermoAux.Variaveis.Substring(i, 1);

                        if (caracter == caracterAux)
                        {
                            variaveisAux += caracter;
                        }
                        else if (caracter != "_" || caracterAux != "_")
                        {
                            variaveisAux += "_";
                            contador += 1;
                        }
                        else
                        {
                            contador += 1;
                        }
                    }

                    if (contador == 1)
                    {
                        Coluna coluna = new Coluna();

                        Boolean teste = true;


                        foreach (var elemento in ColunaB1)
                        {
                            if (variaveisAux == elemento.Variaveis)
                            {
                                teste = false;
                            }
                        }

                        if (teste)
                        {
                            coluna.Variaveis = variaveisAux;

                            foreach (var variavel in mintermo.Mintermos)
                            {
                                coluna.Mintermos.Add(variavel);
                            }
                            foreach (var variavel in mintermoAux.Mintermos)
                            {
                                coluna.Mintermos.Add(variavel);
                            }

                            ColunaB1.Add(coluna);
                        }

                        mintermo.Marcado = true;
                        mintermoAux.Marcado = true;
                    }
                }
            }

            foreach (var mintermo in MatrizColunas[0][1])
            {
                foreach (var mintermoAux in MatrizColunas[0][2])
                {
                    string variaveisAux = "";
                    Int16 contador = 0;

                    for (int i = 0; i < numVariaveis; i++)
                    {
                        var caracter = mintermo.Variaveis.Substring(i, 1);
                        var caracterAux = mintermoAux.Variaveis.Substring(i, 1);

                        if (caracter == caracterAux)
                        {
                            variaveisAux += caracter;
                        }
                        else if (caracter != "_" || caracterAux != "_")
                        {
                            variaveisAux += "_";
                            contador += 1;
                        }
                        else
                        {
                            contador += 1;
                        }
                    }

                    if (contador == 1)
                    {
                        Coluna coluna = new Coluna();

                        Boolean teste = true;


                        foreach (var elemento in ColunaB2)
                        {
                            if (variaveisAux == elemento.Variaveis)
                            {
                                teste = false;
                            }
                        }

                        if (teste)
                        {
                            coluna.Variaveis = variaveisAux;

                            foreach (var variavel in mintermo.Mintermos)
                            {
                                coluna.Mintermos.Add(variavel);
                            }
                            foreach (var variavel in mintermoAux.Mintermos)
                            {
                                coluna.Mintermos.Add(variavel);
                            }

                            ColunaB2.Add(coluna);
                        }

                        mintermo.Marcado = true;
                        mintermoAux.Marcado = true;
                    }
                }
            }

            foreach (var mintermo in MatrizColunas[0][2])
            {
                foreach (var mintermoAux in MatrizColunas[0][3])
                {
                    string variaveisAux = "";
                    Int16 contador = 0;

                    for (int i = 0; i < numVariaveis; i++)
                    {
                        var caracter = mintermo.Variaveis.Substring(i, 1);
                        var caracterAux = mintermoAux.Variaveis.Substring(i, 1);

                        if (caracter == caracterAux)
                        {
                            variaveisAux += caracter;
                        }
                        else if (caracter != "_" || caracterAux != "_")
                        {
                            variaveisAux += "_";
                            contador += 1;
                        }
                        else
                        {
                            contador += 1;
                        }
                    }

                    if (contador == 1)
                    {
                        Coluna coluna = new Coluna();

                        Boolean teste = true;

                        foreach (var elemento in ColunaB3)
                        {
                            if (variaveisAux == elemento.Variaveis)
                            {
                                teste = false;
                            }
                        }

                        if (teste)
                        {
                            coluna.Variaveis = variaveisAux;

                            foreach (var variavel in mintermo.Mintermos)
                            {
                                coluna.Mintermos.Add(variavel);
                            }
                            foreach (var variavel in mintermoAux.Mintermos)
                            {
                                coluna.Mintermos.Add(variavel);
                            }

                            ColunaB3.Add(coluna);
                        }

                        mintermo.Marcado = true;
                        mintermoAux.Marcado = true;
                    }
                }
            }

            MatrizColunas[1].Add(ColunaB1);
            MatrizColunas[1].Add(ColunaB2);
            MatrizColunas[1].Add(ColunaB3);

            // ----------------------------------------
            
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("Coluna B1 ");
            Console.WriteLine();

            foreach (var elemento in MatrizColunas[1][0])
            {
                Console.Write("Mintermos:");

                foreach (var mintermo in elemento.Mintermos)
                {
                    Console.Write(" " + mintermo);
                }

                Console.Write(" Elemento: " + elemento.Variaveis);

                Console.WriteLine();
            }

            Console.WriteLine();
            Console.Write("Coluna B2 ");
            Console.WriteLine();

            foreach (var elemento in MatrizColunas[1][1])
            {
                Console.Write("Mintermos:");

                foreach (var mintermo in elemento.Mintermos)
                {
                    Console.Write(" " + mintermo);
                }

                Console.Write(" Elemento: " + elemento.Variaveis);

                Console.WriteLine();
            }

            Console.WriteLine();
            Console.Write("Coluna B3 ");
            Console.WriteLine();

            foreach (var elemento in MatrizColunas[1][2])
            {
                Console.Write("Mintermos:");

                foreach (var mintermo in elemento.Mintermos)
                {
                    Console.Write(" " + mintermo);
                }

                Console.Write(" Elemento: " + elemento.Variaveis);

                Console.WriteLine();
            }

            FazerColunas3(MatrizColunas);
        }

        private static void FazerColunas3(List<List<List<Coluna>>> MatrizColunas)
        {
            List<Coluna> ColunaC1 = new List<Coluna>();
            List<Coluna> ColunaC2 = new List<Coluna>();

            foreach (var mintermo in MatrizColunas[1][0])
            {
                foreach (var mintermoAux in MatrizColunas[1][1])
                {
                    string variaveisAux = "";
                    Int16 contador = 0;

                    for (int i = 0; i < numVariaveis; i++)
                    {
                        var caracter = mintermo.Variaveis.Substring(i, 1);
                        var caracterAux = mintermoAux.Variaveis.Substring(i, 1);

                        if (caracter == caracterAux)
                        {
                            variaveisAux += caracter;
                        }
                        else if (caracter != "_" || caracterAux != "_")
                        {
                            variaveisAux += "_";
                            contador += 1;
                        }
                        else
                        {
                            contador += 1;
                        }
                    }

                    if (contador == 1)
                    {
                        Coluna coluna = new Coluna();

                        Boolean teste = true;

                        foreach (var elemento in ColunaC1)
                        {
                            if (variaveisAux == elemento.Variaveis)
                            {
                                teste = false;
                            }
                        }

                        if (teste)
                        {
                            coluna.Variaveis = variaveisAux;

                            foreach (var variavel in mintermo.Mintermos)
                            {
                                coluna.Mintermos.Add(variavel);
                            }
                            foreach (var variavel in mintermoAux.Mintermos)
                            {
                                coluna.Mintermos.Add(variavel);
                            }

                            ColunaC1.Add(coluna);
                        }

                        mintermo.Marcado = true;
                        mintermoAux.Marcado = true;
                    }
                }
            }

            foreach (var mintermo in MatrizColunas[1][1])
            {
                foreach (var mintermoAux in MatrizColunas[1][2])
                {
                    string variaveisAux = "";
                    Int16 contador = 0;

                    for (int i = 0; i < numVariaveis; i++)
                    {
                        var caracter = mintermo.Variaveis.Substring(i, 1);
                        var caracterAux = mintermoAux.Variaveis.Substring(i, 1);

                        if (caracter == caracterAux)
                        {
                            variaveisAux += caracter;
                        }
                        else if (caracter != "_" || caracterAux != "_")
                        {
                            variaveisAux += "_";
                            contador += 1;
                        }
                        else
                        {
                            contador += 1;
                        }
                    }

                    if (contador == 1)
                    {
                        Coluna coluna = new Coluna();

                        Boolean teste = true;

                        foreach (var elemento in ColunaC2)
                        {
                            if (variaveisAux == elemento.Variaveis)
                            {
                                teste = false;
                            }
                        }

                        if (teste)
                        {
                            coluna.Variaveis = variaveisAux;

                            foreach (var variavel in mintermo.Mintermos)
                            {
                                coluna.Mintermos.Add(variavel);
                            }
                            foreach (var variavel in mintermoAux.Mintermos)
                            {
                                coluna.Mintermos.Add(variavel);
                            }

                            ColunaC2.Add(coluna);
                        }

                        mintermo.Marcado = true;
                        mintermoAux.Marcado = true;
                    }
                }
            }

            MatrizColunas[2].Add(ColunaC1);
            MatrizColunas[2].Add(ColunaC2);

            // ----------------------------------------------------

            Console.WriteLine();
            Console.WriteLine();
            Console.Write("Coluna C1 ");
            Console.WriteLine();

            foreach (var elemento in MatrizColunas[2][0])
            {
                Console.Write("Mintermos:");

                foreach (var mintermo in elemento.Mintermos)
                {
                    Console.Write(" " + mintermo);
                }

                Console.Write(" Elemento: " + elemento.Variaveis);

                Console.WriteLine();
            }

            Console.WriteLine();
            Console.Write("Coluna C2 ");
            Console.WriteLine();

            foreach (var elemento in MatrizColunas[2][1])
            {
                Console.Write("Mintermos:");

                foreach (var mintermo in elemento.Mintermos)
                {
                    Console.Write(" " + mintermo);
                }

                Console.Write(" Elemento: " + elemento.Variaveis);

                Console.WriteLine();
            }

            // ----------------------------------------------------

            Console.WriteLine();
            Console.WriteLine();

            ExpressoesResultado = new List<Coluna>();

            foreach (var listas in MatrizColunas)
            {
                foreach (var mintermos in listas)
                {
                    foreach (var item in mintermos)
                    {
                        if (!item.Marcado)
                        {
                            Console.WriteLine("Transportando para a tabela de cobertura: " + item.Variaveis);
                            ExpressoesResultado.Add(item);
                        }
                    }
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

        private static void FinalizarAlgoritmo(List<int> TabelaCobertura, List<Coluna>ExpressoesResultado)
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

            Console.WriteLine("Resultado final:");
            
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
            List<List<Mintermo>> MatrizColunasUns = CriarMatrizMintermos(); /* Aloca memória */

            List<List<List<Coluna>>> MatrizColunasComparacao = CriarMatrizColunas(); /* Aloca memória */

            MatrizColunasUns = SepararColunasUns(Mintermos, MatrizColunasUns); /* Aloca memória */

            RodaAlgoritmo(MatrizColunasUns, MatrizColunasComparacao);

            List <int> TabelaCobertura = FazerTabelaCobertura(Mintermos,ref ExpressoesResultado);

            Console.WriteLine();
            Console.WriteLine();

            FinalizarAlgoritmo(TabelaCobertura, ExpressoesResultado);
        }
    }
}