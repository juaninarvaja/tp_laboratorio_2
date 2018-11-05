using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Narvaja.JuanIgnacio._2D.TP3.Excepeciones
{
    public class SinProfesorException :  Exception
    {
        public SinProfesorException() : base("Excepcion, no hay profesor para este curso") { }

    }
}
