using System;
using System.Collections.Generic;
using System.Text;

namespace Locação.Entidades
{
    class Modelo
    {
        private string nomeModelo;
        private Marca marca;

        public Modelo(string nomeModelo, Marca marca)
        {
            this.nomeModelo = nomeModelo;
            this.marca = marca;
        }

        public string NomeModelo { get => nomeModelo; set => nomeModelo = value; }
        internal Marca Marca { get => marca; set => marca = value; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Modelo: {NomeModelo}  Marca: {Marca}");
            return sb.ToString();
        }
    }
}
