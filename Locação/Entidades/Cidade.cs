using System;
using System.Collections.Generic;
using System.Text;

namespace Locação.Entidades
{
    class Cidade
    {
        private String nomeCidade;
        private Estado estado;

        public Cidade(string nomeCidade, Estado estado)
        {
            this.nomeCidade = nomeCidade;
            this.estado = estado;
        }

        public string NomeCidade { get => nomeCidade; set => nomeCidade = value; }
        public Estado Estado { get => estado; set => estado = value; }
    }
}
