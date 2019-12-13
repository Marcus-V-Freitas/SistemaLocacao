using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Locação.Entidades.Enum;
using Locação.Exceptions;

namespace Locação.Entidades
{
    class Veículo
    {
        private string placa;
        private String renavam;
        private Modelo modelo;
        private Cor cor;
        private Seguro seguro;
        private Combustível combustivel;

        public Veículo(String placa, string renavam, Modelo modelo, Cor cor, Seguro seguro, Combustível combustível)
        {
            verificarPlaca(placa);
           verificarRenavam(renavam);
            this.placa = placa;
            this.renavam = renavam;
            this.modelo = modelo;
            this.cor = cor;
            this.seguro = seguro;
            this.combustivel = combustível;
        }

        public string Placa { get => placa; set => placa = value; }
        public string Renavam { get => renavam; set => renavam = value; }
        internal Modelo Modelo { get => modelo; set => modelo = value; }
        public Cor Cor { get => cor; set => cor = value; }
        public Seguro Seguro { get => seguro; set => seguro = value; }
        public Combustível Combustivel { get => combustivel; set => combustivel = value; }

        private static void verificarPlaca(String placa) 
        {
            string[] placas = placa.Split("-");
            placa = null;
            foreach(string digito in placas)
            {
                placa += digito;
            }
        if (placa.Length != 7) {
			throw new DominioException("Placa inválida: formato xxx-0000");
    }
		if (Regex.IsMatch(placa.Substring(0, 3), "[0-9]+")) {
			throw new DominioException("Placa inválida: formato xxx-0000");
}
		if (Regex.IsMatch(placa.Substring(3), @"^[ a-zA-z á]*$")) {
			throw new DominioException("Placa inválida: formato xxx-0000");
		}
	}

        private static void verificarRenavam(String renavam)
        {
            string[] renavams = renavam.Split(".");
            renavam = null;
            foreach(string digito in renavams)
            {
                renavam += digito;
            }
            if (renavam.Length != 11)
            {
                throw new DominioException("Renavam inválido: formato 000.000.000.00");
            }
            if(Regex.IsMatch(renavam, @"^[ a-zA-z á]*$"))
            {
                throw new DominioException("Renavam inválido: formato 000.000.000.00");
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("\nDados do veículo alugado: \n");
            sb.Append($"Placa: {Placa}  Renavam: {Renavam} \n");
            sb.Append($"{Modelo} \n");
            sb.Append($"Cor: {Cor} Combustível:  {Combustivel} \n");
            sb.Append($"Seguro: {Seguro} \n");
            return sb.ToString();
        }
    }
}
