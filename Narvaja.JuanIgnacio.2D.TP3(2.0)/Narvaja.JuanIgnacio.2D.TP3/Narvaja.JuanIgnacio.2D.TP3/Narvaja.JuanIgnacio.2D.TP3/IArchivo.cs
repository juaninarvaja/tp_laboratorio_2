using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Narvaja.JuanIgnacio._2D.TP3
{
         interface IArchivo<T>
        {
         bool Guardar(string archivo, T datos);
         bool Leer(string archivo, out T datos);
        }
}

