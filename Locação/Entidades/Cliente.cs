using System;
using System.Collections.Generic;
using System.Text;
using Locação.Entidades.Enum;

namespace Locação.Entidades
{
    abstract class Cliente
    {
        private String nomeCondutor;
        private String email;
        private String cnh;
        private DateTime nascimentoCondutor;
        private Sexo sexoCondutor;
        private Endereco endereco;

        private List<TelefoneCliente> telefonesCliente = new List<TelefoneCliente>();


        public Cliente() { }

        protected Cliente(string nomeCondutor, string email, string cnh, DateTime nascimentoCondutor, Sexo sexoCondutor)
        {
            this.nomeCondutor = nomeCondutor;
            this.email = email;
            this.cnh = cnh;
            this.nascimentoCondutor = nascimentoCondutor;
            this.sexoCondutor = sexoCondutor;

        }

        public string NomeCondutor { get => nomeCondutor; set => nomeCondutor = value; }
        public string Email { get => email; set => email = value; }
        public string Cnh { get => cnh; set => cnh = value; }
        public DateTime NascimentoCondutor { get => nascimentoCondutor; set => nascimentoCondutor = value; }
        public Sexo SexoCondutor { get => sexoCondutor; set => sexoCondutor = value; }
        internal Endereco Endereco { get => endereco; set => endereco = value; }

        public void addTelefoneCliente(TelefoneCliente telefone)
        {
            if(telefone!=null)
            telefonesCliente.Add(telefone);
        }

        public List<TelefoneCliente> GetTelefoneClientes()
        {
            return telefonesCliente;
        }

        public virtual String ConsultarCliente() { return null; }

        public abstract bool verficarIdentidade(String cpfCnpj);

        protected static int calcularDigitos(string strings, int[] tamanho)
        {
            int soma = 0;
            for (int indice = strings.Length - 1, digito; indice >= 0; indice--)
            {
                digito = int.Parse(strings.Substring(indice, 1));
                soma += digito * tamanho[tamanho.Length - strings.Length + indice];
            }
            soma = 11 - soma % 11;
            return soma > 9 ? 0 : soma;
        }


    }
}
