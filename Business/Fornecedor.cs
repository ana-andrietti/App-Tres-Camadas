﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseSQL;


namespace Business
{
    public class Fornecedor : Base
    {
        [OpcoesBase(UsarNoBancoDeDados = true, UsarParaBuscar = true, ChavePrimaria = true, AutoIncrementar = true)]
        public int? Id { get; set; }

        [OpcoesBase(UsarNoBancoDeDados = true)]
        public string Nome { get; set; }

        [OpcoesBase(UsarNoBancoDeDados = true)]
        public string Telefone { get; set; }

        [OpcoesBase(UsarNoBancoDeDados = true)]
        public string Especialidades { get; set; }
    }
}
