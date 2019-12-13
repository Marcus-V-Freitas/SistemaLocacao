using System;
using System.Collections.Generic;
using System.Text;

namespace Locação.Entidades
{
    class Estado
    {
        private String nomeEstado;

        public Estado(string nomeEstado)
        {
            this.nomeEstado = nomeEstado;
        }

        public string NomeEstado { get => nomeEstado; set => nomeEstado = value; }
    }
}
