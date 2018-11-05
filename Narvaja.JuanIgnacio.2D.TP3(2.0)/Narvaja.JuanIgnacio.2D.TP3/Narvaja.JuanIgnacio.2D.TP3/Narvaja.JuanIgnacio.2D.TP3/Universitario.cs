using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace Narvaja.JuanIgnacio._2D.TP3
{
    public abstract class Universitario : Persona
    {
        int legajo;
        public Universitario() { }


        public Universitario(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(nombre,apellido,dni,nacionalidad)
        {
            this.legajo = id; 
        }

        #region Metodos
        protected virtual string MostrarDatos()
        {
            if (this != null)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(this.ToString() + "Con el legajo: " + this.legajo);
                return sb.ToString();
            }
            return "";
            
        }
        protected abstract string ParticiparEnClase();

        #endregion
        //Verificar que no sean iguals y eso cuando ya tenga profesor y alumno creados
        public static bool operator ==(Universitario u1, Universitario u2)  
        {
            return true;

        }
        public static bool operator !=(Universitario u1, Universitario u2)
        {
            return !(u1 == u2);

        }

    }
}
