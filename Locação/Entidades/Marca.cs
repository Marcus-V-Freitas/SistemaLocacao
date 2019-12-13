using System;
using System.Collections.Generic;
using System.Text;

namespace Locação
{
    class Marca
    {
        private String nomeMarca;

        public Marca(string nomeMarca)
        {
            this.nomeMarca = nomeMarca;
        }

        public string NomeMarca { get => nomeMarca; set => nomeMarca = value; }

        public override string ToString()
        {
            return NomeMarca;
        }
    }

}
