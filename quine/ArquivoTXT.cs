using System;
using System.Collections.Generic;
using System.IO;

namespace quine
{
    class ArquivoTXT
    {
        private string caminhoArquivo;
        private int numeroVariaveis;

        public ArquivoTXT(string caminhoArquivo)
        {
            this.numeroVariaveis = 0;
            this.caminhoArquivo = App_Path() + caminhoArquivo;
        }

        private string App_Path()
        {
            var location = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var appPath = Path.GetDirectoryName(location);
            var appName = Path.GetFileName(location);

            return appPath;
        }

        public int PegarNumeroVariaveis()
        {
            var numeroMintermos = PegarNumeroMintermos();

            numeroVariaveis = Convert.ToInt32(Math.Log(numeroMintermos, 2));

            return numeroVariaveis;
        }

        private int PegarNumeroMintermos()
        {
            StreamReader arquivoTXT = new StreamReader(caminhoArquivo);

            Boolean ehDontCare = false;

            string conteudo = arquivoTXT.ReadLine();
            string ultimoMintermoAux = "";
            string numeroMintermo = "";
            int ultimoMintermo = 0;

            foreach (char caracter in conteudo)
            {
                if (caracter == ';')
                {
                    ultimoMintermoAux = numeroMintermo;
                    numeroMintermo = "";
                }
                else if (caracter != ';' && caracter != '-')
                    numeroMintermo += caracter.ToString();
            }

            var numeroMintermos = 0;
            ultimoMintermo = Convert.ToInt32(ultimoMintermoAux);

            for (int i = 1; i < 1000000000; i++)
            {
                if (ultimoMintermo >= Math.Pow(2, i) && ultimoMintermo < Math.Pow(2, i + 1))
                {
                    numeroMintermos = Convert.ToInt32(Math.Pow(2, i + 1));
                    break;
                }
            }
            
            return numeroMintermos;
        }

        public List<Mintermo> CarregarMintermos()
        {
            List<Mintermo> Mintermos = new List<Mintermo>();
            List<int> DontCares = new List<int>();
            List<int> Posicoes = new List<int>();

            StreamReader arquivoTXT = new StreamReader(caminhoArquivo);

            Boolean ehDontCare = false;

            string conteudo = arquivoTXT.ReadLine();
            string posicaoMintermo = "";

            foreach (char caracter in conteudo)
            {
                if (caracter == ';')
                {
                    if (ehDontCare)
                        DontCares.Add(Convert.ToInt32(posicaoMintermo));
                    else
                        Posicoes.Add(Convert.ToInt32(posicaoMintermo));
                    
                    posicaoMintermo = "";
                    ehDontCare = false;
                }
                else if (caracter == '-')
                    ehDontCare = true;
                else
                    posicaoMintermo += caracter.ToString();
            }

            Mintermos = PopularMintermos(Posicoes, DontCares);

            return Mintermos;
        }

        private List<Mintermo> PopularMintermos(List<int> Mintermos, List<int> DontCares)
        {
            List<Mintermo> ResultadoMintermos = new List<Mintermo>();

            var numeroMintermos = PegarNumeroMintermos();

            for (int i = 0; i < numeroMintermos; i++)
            {
                Mintermo newMintermo = new Mintermo();

                newMintermo.Valor = 0;
                newMintermo.Posicao = i;

                foreach (var mintermo in Mintermos)
                {
                    if (i == mintermo)
                    {
                        newMintermo.Valor = 1;
                    }
                }

                foreach (var dontCare in DontCares)
                {
                    if (i == dontCare)
                    {
                        newMintermo.Valor = 2;
                    }
                }

                ResultadoMintermos.Add(newMintermo);
            }

            ColocarExpressoes(ResultadoMintermos, numeroMintermos);

            return ResultadoMintermos;
        }

        private List<Mintermo> ColocarExpressoes(List<Mintermo> Mintermos, Int32 numeroMintermos)
        {
            List<Mintermo> ResultadoMintermos = Mintermos;

            var contador = 0;
            var contadorAux = 0;
            var quantPulos = 0;

            for (int i = 0; i < Math.Log(numeroMintermos, 2); i++)
            {
                for (int j = 0; j < numeroMintermos; j++)
                {
                    if (contador == 0)
                    {
                        quantPulos = 1;
                        contadorAux += 1;

                        if (contadorAux == quantPulos)
                            Mintermos[j].Variaveis = "0";
                        else
                        {
                            Mintermos[j].Variaveis = "1";
                            contadorAux = 0;
                        }

                    }
                    else if (contador == 1)
                    {
                        quantPulos = 2;
                        contadorAux += 1;

                        if (contadorAux <= quantPulos)
                            Mintermos[j].Variaveis = Mintermos[j].Variaveis.PadLeft(contador+1, '0');
                        else
                        {
                            Mintermos[j].Variaveis = Mintermos[j].Variaveis.PadLeft(contador+1, '1');

                            if (contadorAux == quantPulos * 2)
                                contadorAux = 0;
                        }

                    }
                    else
                    {
                        quantPulos = Convert.ToInt32(Math.Pow(2, contador));
                        contadorAux += 1;

                        if (Math.Log(numeroMintermos, 2) == contador)
                        {
                            if (contadorAux <= quantPulos / 2)
                                Mintermos[j].Variaveis = Mintermos[j].Variaveis.PadLeft(contador + 1, '0');
                            else
                                Mintermos[j].Variaveis = Mintermos[j].Variaveis.PadLeft(contador + 1, '1');
                        }
                        else
                        {
                            if (contadorAux <= quantPulos)
                                Mintermos[j].Variaveis = Mintermos[j].Variaveis.PadLeft(contador + 1, '0');
                            else
                            {
                                Mintermos[j].Variaveis = Mintermos[j].Variaveis.PadLeft(contador + 1, '1');

                                if (contadorAux == quantPulos * 2)
                                    contadorAux = 0;
                            }
                        }
                    }
                }

                contador += 1;
            }
            
            return ResultadoMintermos;
        }
    }
}