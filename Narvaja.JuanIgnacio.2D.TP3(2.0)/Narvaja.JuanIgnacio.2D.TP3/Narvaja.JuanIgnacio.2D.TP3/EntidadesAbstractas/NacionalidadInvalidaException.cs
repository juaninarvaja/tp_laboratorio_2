using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Narvaja.JuanIgnacio._2D.TP3.Excepeciones
{
    public class NacionalidadInvalidaException : Exception
    {
        public NacionalidadInvalidaException() : this("Excepcion de Nacionalidad") { }
        public NacionalidadInvalidaException(string mensaje) : base(mensaje) { }


    }
}
