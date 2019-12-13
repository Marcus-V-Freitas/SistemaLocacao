using Locação.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Locação.Serviços
{
    class ServiçoLocação
    {
        private double preco;
        private TaxaServiço taxaServico;
        private TaxaSeguro taxaSeguro;

        public ServiçoLocação() { }

        public ServiçoLocação(double preco, TaxaServiço taxaServiço, TaxaSeguro taxaSeguro)
        {
            this.preco = preco;
            this.taxaServico = taxaServiço;
            this.taxaSeguro = taxaSeguro;
        }

        public void EmitirFatura(AluguelVeículo aluguelVeículo)
        {
            double valorBasico = taxaServico.taxa(aluguelVeículo, preco);

            double taxa = 0.0;

            taxa = taxaSeguro.taxa(valorBasico);

            aluguelVeículo.FaturaLocaçao=new FaturaLocação(valorBasico, taxa);
        }
    }
}
