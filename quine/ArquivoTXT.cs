using System;
using System.Collections.Generic;
using System.IO;

namespace quine
{
    class ArquivoTXT
    {
        public List<Mintermo> LerTXT(string caminhoArquivo)
        {
            StreamReader arquivoTXT = new StreamReader(caminhoArquivo);

            List<Mintermo> Mintermos = new List<Mintermo>();

            return Mintermos;
        }
    }
}
