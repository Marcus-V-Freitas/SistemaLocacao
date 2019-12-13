using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Locação.Exceptions;


namespace Locação.Entidades
{
    class Endereco
    {
        private string cep;
        private String rua;
        private int numero;
        private Cidade cidade;

        public Endereco(string cep, string rua, int numero, Cidade cidade)
        {
            if (Regex.IsMatch(cep, @"^[ a-zA-z á]*$"))
            {
                throw new DominioException("Cep inválido: formato 000.000.00");
            }
            if (cep.Length != 8)
            {
                throw new DominioException("Cep inválido: formato 000.000.00");
            }
            this.cep = cep;
            this.rua = rua;
            this.numero = numero;
            this.cidade = cidade;
        }

        public string Cep { get => cep; set => cep = value; }
        public string Rua { get => rua; set => rua = value; }
        public int Numero { get => numero; set => numero = value; }
        public Cidade Cidade { get => cidade; set => cidade = value; }
    }
}
