using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseSQL;


namespace Business
{
    public class Endereco : Base
    {
        [OpcoesBase(UsarNoBancoDeDados = true, UsarParaBuscar = true, ChavePrimaria = true)]
        public string CPF { get; set; }

        [OpcoesBase(UsarNoBancoDeDados = true)]
        public string Rua { get; set; }

        [OpcoesBase(UsarNoBancoDeDados = true)]
        public string Numero { get; set; }

        [OpcoesBase(UsarNoBancoDeDados = true)]
        public string Cidade { get; set; }

        [OpcoesBase(UsarNoBancoDeDados = true)]
        public string Estado { get; set; }
    }
}
