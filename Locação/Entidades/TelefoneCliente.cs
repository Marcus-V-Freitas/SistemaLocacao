using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Locação.Exceptions;

namespace Locação.Entidades
{
    class TelefoneCliente
    {
        private int ddd;
        private double telefone;

        public TelefoneCliente(String numero)
        {
            var apenasDigitos = new Regex(@"[^\d]");
            numero = apenasDigitos.Replace(numero, "");
            if (numero.Length != 11)
            {
                throw new DominioException("Telefone Inválido: Formato (00)00000-0000");
            }
            int ddd = int.Parse(numero.Substring(0, 2));
            double telefone = double.Parse(numero.Substring(2));
            this.ddd = ddd;
            this.telefone = telefone;
        }

        public int Ddd { get => ddd; set => ddd = value; }
        public double Telefone { get => telefone; set => telefone = value; }

        public override string ToString()
        {
            return string.Format("Telefone: (" + Ddd +")"+ Telefone);
        }
    }

}
