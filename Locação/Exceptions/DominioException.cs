using System;
using System.Collections.Generic;
using System.Text;

namespace Locação.Exceptions
{
    class DominioException:Exception
    {
        public DominioException(String msg) : base(msg) { }
    }
}
