using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Narvaja.JuanIgnacio._2D.TP3
{

    public sealed class Alumno : Universitario
    {

        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        }

        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;


        #region Constructores
        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public Alumno()
        {
        }

        /// <summary>
        /// Constructor de instancia. 
        /// </summary>
        /// <param name="id">Legajo del alumno.</param>
        /// <param name="nombre">Nombre del alumno.</param>
        /// <param name="apellido">Apellido del alumno.</param>
        /// <param name="dni">DNI del alumno.</param>
        /// <param name="nacionalidad">Nacionalidad del alumno</param>
        /// <param name="claseQueToma">La clase que toma el alumno.</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }

        /// <summary>
        /// Constructor público de instancia.
        /// </summary>
        /// <param name="id">Legajo del alumno.</param>
        /// <param name="nombre">Nombre del alumno.</param>
        /// <param name="apellido">Apellido del alumno.</param>
        /// <param name="dni">DNI del alumno.</param>
        /// <param name="nacionalidad">Nacionalidad del alumno.</param>
        /// <param name="claseQueToma">La clase que toma el alumno</param>
        /// <param name="estadoCuenta">El estado de cuenta del alumno.</param>
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }
        #endregion


      
        public Universidad.EClases ClaseQueToma()
        {
            return this.claseQueToma;
        }

        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine("Clases que toma " + this.claseQueToma + " Estado De Cuenta " + this.estadoCuenta);
            return sb.ToString();
        }

        protected override string ParticiparEnClase()
        {
            if (claseQueToma == Universidad.EClases.Laboratorio ||
                claseQueToma == Universidad.EClases.Legislacion ||
                claseQueToma == Universidad.EClases.Programacion ||
                claseQueToma == Universidad.EClases.SPD)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Toma Clases de" + this.claseQueToma);
                return sb.ToString();
            }
            else return "No toma ninguna Clase";
        }
        public override string ToString()
        {
            return this.MostrarDatos();
        }


        public static bool operator ==(Alumno alumno, Universidad.EClases clase)
        {
            return (alumno.claseQueToma == clase && alumno.estadoCuenta != EEstadoCuenta.Deudor);
        }

        /// <summary>
        /// Un Alumno será distinto a un EClase sólo si no toma esa clase
        /// </summary>
        /// <param name="a">Alumno a comparar.</param>
        /// <param name="clase">Clase a comparar.</param>
        /// <returns>Devuelve true si el alumno no toma la clase, sino false.</returns>
        public static bool operator !=(Alumno alumno, Universidad.EClases clase)
        {
            return (alumno.claseQueToma != clase);
        }


    }
}
