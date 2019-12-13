using System;
using System.Collections.Generic;
using System.Text;
using Locação.Entidades;

namespace Locação.Serviços
{
    class TaxaServicoDia : TaxaServiço
    {
        double TaxaServiço.taxa(AluguelVeículo aluguelVeículo, double precoDia)
        {
            double valorBasico = 0.0;
            TimeSpan prevista = aluguelVeículo.Prevista.Subtract(aluguelVeículo.Inicio);
            TimeSpan retorno = aluguelVeículo.Retorno.Subtract(aluguelVeículo.Inicio);
            TimeSpan diferenca=retorno - prevista;

            if (retorno == prevista)
            {
                if (retorno.TotalHours <= 12 && retorno.TotalHours <= 24)
                {
                    valorBasico += Math.Ceiling(1.0) * precoDia;
                }
                else
                {
                    valorBasico += Math.Ceiling(retorno.TotalDays) * precoDia;
                }
            }
            else
            {
                valorBasico += Math.Ceiling(retorno.TotalDays) * precoDia;
                valorBasico += valorBasico * Math.Ceiling(diferenca.TotalDays) * 0.02;
            }
            return valorBasico;
        }
    }
}
