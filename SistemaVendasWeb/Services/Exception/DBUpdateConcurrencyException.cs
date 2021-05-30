using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaVendasWeb.Services.Exception
{
    public class DBUpdateConcurrencyException : ApplicationException
    {
        public DBUpdateConcurrencyException(string message) : base(message)
        {

        }
    }
}
