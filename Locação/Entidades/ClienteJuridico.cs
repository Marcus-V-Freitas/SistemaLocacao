using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Locação.Entidades.Enum;
using Locação.Exceptions;

namespace Locação.Entidades
{
    class ClienteJuridico : Cliente
    {
        private string nomeFantasia;
        private String cnpj;
        private static readonly int[] multiplosCNPJ = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

        public ClienteJuridico() { }

        public ClienteJuridico(string nomeCondutor, string email, string cnh, DateTime nascimentoCondutor, Sexo sexoCondutor, string nomeFantasia, string cnpj) :
                    base(nomeCondutor, email, cnh, nascimentoCondutor, sexoCondutor)
        {
            verficarIdentidade(cnpj);
            this.nomeFantasia = nomeFantasia;
            this.cnpj = cnpj;
        }

        public string Cnpj { get => cnpj; set => cnpj = value; }
        public string NomeFantasia { get => nomeFantasia; set => nomeFantasia = value; }

        public override bool verficarIdentidade(string cnpj)
        {
            var apenasDigitos = new Regex(@"[^\d]");
            cnpj = apenasDigitos.Replace(cnpj, "");
            if ((cnpj == null) || (cnpj.Length != 14))
                throw new DominioException("CNPJ inválido");

            int digito1 = calcularDigitos(cnpj.Substring(0, 12), multiplosCNPJ);
            int digito2 = calcularDigitos(cnpj.Substring(0, 12) + digito1, multiplosCNPJ);
            return cnpj.Equals(cnpj.Substring(0, 12) + digito1.ToString() + digito2.ToString());
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
