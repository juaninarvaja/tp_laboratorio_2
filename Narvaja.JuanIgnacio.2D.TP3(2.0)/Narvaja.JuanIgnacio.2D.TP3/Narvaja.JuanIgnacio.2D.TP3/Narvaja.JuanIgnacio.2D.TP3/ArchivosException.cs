using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Narvaja.JuanIgnacio._2D.TP3.Excepeciones
{
    public class ArchivosException : Exception
    {
        public ArchivosException(Exception inner) : base("Excepcion, Error de Archivo", inner) { }
    }
}
