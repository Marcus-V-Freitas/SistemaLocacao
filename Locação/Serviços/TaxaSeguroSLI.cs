using System;
using System.Collections.Generic;
using System.Text;

namespace Locação.Serviços
{
    class TaxaSeguroSLI : TaxaSeguro
    {
        public double taxa(double valorBasico)
        {
            return valorBasico *= 1.08;
        }
    }
}
