using System;
using System.Collections.Generic;
using System.Text;

namespace Locação.Serviços
{
    class TaxaSeguroCDW:TaxaSeguro
    {
        public double taxa(double valorBasico)
        {
            return valorBasico *= 0.62;
        }
    }
}
