using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Locação.Entidades
{
    class FaturaLocação
    {
        private double valorBasico;
        private double taxa;


        public FaturaLocação(double valorBasico, double taxa)
        {
            this.valorBasico = valorBasico;
            this.taxa = taxa;
        }

        public double ValorBasico { get => valorBasico; set => valorBasico = value; }
        public double Taxa { get => taxa; set => taxa = value; }

        public double valorCaucao()
        {
            return valorTotal() * 3;
        }

        public double valorTotal()
        {
            return valorBasico+ taxa;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("\nFatura do aluguel: \n");
            sb.Append("Valor do aluguel do carro: R$");
            sb.Append(valorBasico.ToString("F2", CultureInfo.InvariantCulture));
            sb.Append("\nTaxa de Seguro Adicional: R$");
            sb.Append(taxa.ToString("F2", CultureInfo.InvariantCulture));
            sb.Append("\nValor retido do Caução: R$" + valorCaucao().ToString("F2", CultureInfo.InvariantCulture));
            sb.Append("\nTotal da fatura: R$");
            sb.Append(valorTotal().ToString("F2", CultureInfo.InvariantCulture));
            return sb.ToString();
        }
      



    }
}
