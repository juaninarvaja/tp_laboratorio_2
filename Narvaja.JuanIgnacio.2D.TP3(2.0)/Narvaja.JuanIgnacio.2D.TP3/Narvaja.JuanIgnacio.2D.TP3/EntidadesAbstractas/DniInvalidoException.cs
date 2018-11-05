using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Narvaja.JuanIgnacio._2D.TP3.Excepeciones
{
    public class DniInvalidoException : Exception
    {
        private static string mensajeBase = "DNI invalido";
        public DniInvalidoException() : base(mensajeBase) { }
        public DniInvalidoException(Exception e) : base(mensajeBase, e) { }
        public DniInvalidoException(string mensaje) : base(mensaje) { }
        public DniInvalidoException(string mensaje, Exception e) : base(mensaje,e){}

    }
}
