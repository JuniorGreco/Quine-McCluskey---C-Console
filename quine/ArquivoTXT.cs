using System;
using System.Collections.Generic;
using System.IO;

namespace quine
{
    class ArquivoTXT
    {
        public string caminhoArquivo;

        public ArquivoTXT(string caminhoArquivo)
        {
            this.caminhoArquivo = App_Path() + caminhoArquivo;
        }

        public List<Mintermo> CarregarMintermos()
        {
            List<Mintermo> Mintermos = new List<Mintermo>();
            List<int> Posicoes = new List<int>();

            StreamReader arquivoTXT = new StreamReader(caminhoArquivo);

            var conteudo = arquivoTXT.ReadLine();
            string posicaoMintermo = "";
            string ultimoMintermo = "";

            foreach (char caracter in conteudo)
            {
                if (caracter == ';')
                {
                    Posicoes.Add(Convert.ToInt32(posicaoMintermo));

                    ultimoMintermo = posicaoMintermo;
                    posicaoMintermo = "";
                }
                else
                    posicaoMintermo = caracter.ToString();
            }

            Mintermos = PopularMintermos(Posicoes, Convert.ToInt32(ultimoMintermo));

            return Mintermos;
        }

        private List<Mintermo> PopularMintermos(List<int> Mintermos, Int32 ultimoMintermo)
        {
            List<Mintermo> ResultadoMintermos = new List<Mintermo>();

            var numeroMintermos = 0;

            /* Quando tem 3 variaveis */
            if (ultimoMintermo >= 3 && ultimoMintermo < 8)
            {
                numeroMintermos = 8;
            }
            else if (ultimoMintermo >= 8 && ultimoMintermo < 16)
            {
                numeroMintermos = 16;
            }
            else if (ultimoMintermo >= 16 && ultimoMintermo < 32)
            {
                numeroMintermos = 32;
            }
            else if (ultimoMintermo >= 32 && ultimoMintermo < 64)
            {
                numeroMintermos = 64;
            }
            else if (ultimoMintermo >= 64 && ultimoMintermo < 128)
            {
                numeroMintermos = 128;
            }
            else if (ultimoMintermo >= 128 && ultimoMintermo < 256)
            {
                numeroMintermos = 256;
            }
            else if (ultimoMintermo >= 256 && ultimoMintermo < 512)
            {
                numeroMintermos = 512;
            }
            else if (ultimoMintermo >= 512 && ultimoMintermo < 1024)
            {
                numeroMintermos = 1024;
            }

            for (int i = 0; i < numeroMintermos; i++)
            {
                Mintermo mintermo = new Mintermo();

                mintermo.Valor = 0;
                mintermo.Posicao = i;

                foreach (var posicao in Mintermos)
                {
                    if (i == posicao)
                    {
                        mintermo.Valor = 1;
                    }
                }

                ResultadoMintermos.Add(mintermo);
            }

            return ResultadoMintermos;
        }

        private string App_Path()
        {
            var location = System.Reflection.Assembly.GetExecutingAssembly().Location;
            var appPath = Path.GetDirectoryName(location);
            var appName = Path.GetFileName(location);

            return appPath;
        }
    }
}
