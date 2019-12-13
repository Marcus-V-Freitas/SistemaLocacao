using System;
using System.Collections.Generic;
using System.Text;
using Locação.Entidades;

namespace Locação.Serviços
{
    interface TaxaServiço
    {
        double taxa(AluguelVeículo aluguelVeiculo, double preco);
    }
}
