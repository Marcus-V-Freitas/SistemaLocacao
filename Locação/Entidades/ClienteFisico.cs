using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Locação.Entidades.Enum;
using Locação.Exceptions;

namespace Locação.Entidades
{
    class ClienteFisico : Cliente
    {
        private string cpf;
        private static readonly int[] multiplosCPF = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

        public ClienteFisico() { }

        public ClienteFisico(string nomeCondutor, string email, string cnh, DateTime nascimentoCondutor, Sexo sexoCondutor, string cpf)
        {
            verficarIdentidade(cpf);
            this.cpf = cpf;
        }

        public string Cpf { get => cpf; set => cpf = value; }


        public override bool verficarIdentidade(string cpf)
        {
            var apenasDigitos = new Regex(@"[^\d]");
            cpf = apenasDigitos.Replace(cpf, "");
            if ((cpf == null) || (cpf.Length != 11))
                throw new DominioException("CPF inválido.");

            int digito1 = calcularDigitos(cpf.Substring(0, 9), multiplosCPF);
            int digito2 = calcularDigitos(cpf.Substring(0, 9) + digito1, multiplosCPF);
            return cpf.Equals(cpf.Substring(0, 9) + digito1.ToString() + digito2.ToString());
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (TelefoneCliente telefone in GetTelefoneClientes())
            {
                Console.WriteLine(telefone + "\n");
            }
            return sb.ToString();
        }
    }
}
