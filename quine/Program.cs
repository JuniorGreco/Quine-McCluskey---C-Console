using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace quine
{
    class Program
    {
        static Int16 numVariaveis = 5;
        static List<Coluna> ExpressoesResultado;

        static void Main(string[] args)
        {
            ArquivoTXT arquivo = new ArquivoTXT(@"\MapaKarnaugh.txt");

            var ListaMintermos = arquivo.CarregarMintermos();

            List<Mintermo> Mintermos = new List<Mintermo>();

            Mintermos = PopularMintermos(Mintermos);

            List<List<Mintermo>> MatrizMintermos = new List<List<Mintermo>>();

            CriarMatrizMintermos(MatrizMintermos);

            QuineMcCluskey(Mintermos, MatrizMintermos);

            Console.ReadLine();
        }

        private static List<Mintermo> PopularMintermos(List<Mintermo> mintermos)
        {
            for (int i = 0; i < 32; i++)
            {
                Mintermo mintermo = new Mintermo();

                mintermo.Valor = 0;
                mintermo.Posicao = i;

                mintermos.Add(mintermo);
            }

            mintermos[0].Valor = 1;
            mintermos[4].Valor = 1;
            mintermos[8].Valor = 1;
            mintermos[12].Valor = 1;
            mintermos[16].Valor = 1;
            mintermos[17].Valor = 2;
            mintermos[19].Valor = 1;
            mintermos[20].Valor = 1;
            mintermos[21].Valor = 2;
            mintermos[24].Valor = 1;
            mintermos[25].Valor = 2;
            mintermos[27].Valor = 1;
            mintermos[28].Valor = 1;
            mintermos[29].Valor = 2;

            mintermos[0].Variaveis = "00000";
            mintermos[1].Variaveis = "00001";
            mintermos[2].Variaveis = "00010";
            mintermos[3].Variaveis = "00011";
            mintermos[4].Variaveis = "00100";
            mintermos[5].Variaveis = "00101";
            mintermos[6].Variaveis = "00110";
            mintermos[7].Variaveis = "00111";
            mintermos[8].Variaveis = "01000";
            mintermos[9].Variaveis = "01001";
            mintermos[10].Variaveis = "01010";
            mintermos[11].Variaveis = "01011";
            mintermos[12].Variaveis = "01100";
            mintermos[13].Variaveis = "01101";
            mintermos[14].Variaveis = "01110";
            mintermos[15].Variaveis = "01111";
            mintermos[16].Variaveis = "10000";
            mintermos[17].Variaveis = "10001";
            mintermos[18].Variaveis = "10010";
            mintermos[19].Variaveis = "10011";
            mintermos[20].Variaveis = "10100";
            mintermos[21].Variaveis = "10101";
            mintermos[22].Variaveis = "10110";
            mintermos[23].Variaveis = "10111";
            mintermos[24].Variaveis = "11000";
            mintermos[25].Variaveis = "11001";
            mintermos[26].Variaveis = "11010";
            mintermos[27].Variaveis = "11011";
            mintermos[28].Variaveis = "11100";
            mintermos[29].Variaveis = "11101";
            mintermos[30].Variaveis = "11110";
            mintermos[31].Variaveis = "11111";

            return mintermos;
        }

        private static void CriarMatrizMintermos(List<List<Mintermo>> MatrizMintermos)
        {
            for (int i = 0; i <= numVariaveis; i++)
            {
                List<Mintermo> listaColunas = new List<Mintermo>();

                MatrizMintermos.Add(listaColunas);
            }
        }

        private static void CriarMatrizColunas(List<List<List<Coluna>>> MatrizColunas)
        {
            for (int i = 0; i < numVariaveis; i++)
            {
                List<List<Coluna>> listaColunas = new List<List<Coluna>>();

                MatrizColunas.Add(listaColunas);
            }
        }

        private static void SepararOnSet(List<Mintermo> mintermos, List<List<Mintermo>> MatrizMintermos)
        {
            foreach (var mintermo in mintermos)
            {
                if (mintermo.Valor == 1 || mintermo.Valor == 2)
                {
                    Int16 contador = 0;

                    foreach (char caracter in mintermo.Variaveis)
                    {
                        if (caracter == '1')
                        {
                            contador += 1;
                        }
                    }

                    if (contador == 0)
                    {
                        MatrizMintermos[0].Add(mintermo);
                    }
                    else if (contador == 1)
                    {
                        MatrizMintermos[1].Add(mintermo);
                    }
                    else if (contador == 2)
                    {
                        MatrizMintermos[2].Add(mintermo);
                    }
                    else if (contador == 3)
                    {
                        MatrizMintermos[3].Add(mintermo);
                    }
                    else if (contador == 4)
                    {
                        MatrizMintermos[4].Add(mintermo);
                    }
                    else if (contador == 5)
                    {
                        MatrizMintermos[5].Add(mintermo);
                    }
                }
            }
        }

        private static void ImprimirConjuntoUns(List<List<Mintermo>> MatrizMintermos)
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

        private static void FazerColunas(List<List<Mintermo>> MatrizMintermos, List<List<List<Coluna>>> MatrizColunas)
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

        private static void QuineMcCluskey(List<Mintermo> Mintermos, List<List<Mintermo>> MatrizMintermos)
        {
            List<List<List<Coluna>>> MatrizColunas = new List<List<List<Coluna>>>();

            CriarMatrizColunas(MatrizColunas);

            SepararOnSet(Mintermos, MatrizMintermos);

            ImprimirConjuntoUns(MatrizMintermos);

            FazerColunas(MatrizMintermos, MatrizColunas);

            List <int> TabelaCobertura = FazerTabelaCobertura(Mintermos,ref ExpressoesResultado);

            Console.WriteLine();
            Console.WriteLine();

            FinalizarAlgoritmo(TabelaCobertura, ExpressoesResultado);
        }
    }
}