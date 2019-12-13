using System;
using System.Collections.Generic;
using System.Text;
using Locação.Entidades;

namespace Locação.Serviços
{
    class TaxaServiçoKm : TaxaServiço
    {
        public double taxa(AluguelVeículo aluguelVeiculo, double precoKm)
        {
            double valorBasico = 0.0;
            double previstaKm = aluguelVeiculo.KmPrevista;
            double retornoKm = aluguelVeiculo.KmRetorno;
            if (previstaKm == retornoKm)
            {
                valorBasico = retornoKm * precoKm;
            }
            else
            {
                double diferenca = retornoKm - previstaKm;
                valorBasico = (retornoKm * precoKm) + (diferenca * 2);
            }
            return valorBasico;
        }
    }
}
