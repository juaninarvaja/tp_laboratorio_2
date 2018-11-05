using Narvaja.JuanIgnacio._2D.TP3.Excepeciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Narvaja.JuanIgnacio._2D.TP3
{
    public class Profesor : Universitario
    {
        #region Atributos
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;

        #endregion

        #region Constructores
        static Profesor()
        {
            random = new Random();
        }

        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public Profesor()
        {

        }
        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
         : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this.RandomClases();
        }



        #endregion

        #region Metodos

        private void RandomClases()
        {
            this.clasesDelDia.Enqueue((Universidad.EClases)Profesor.random.Next(0, 4));
            this.clasesDelDia.Enqueue((Universidad.EClases)Profesor.random.Next(0, 4)); //devuelve el valor del enumerado
        
        }

        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Clases del Dia: ");
            if (!object.ReferenceEquals(this.clasesDelDia, null))
            {
                foreach (Universidad.EClases clases in this.clasesDelDia)
                {
                    sb.AppendLine(clases.ToString());
                }
            }
            return sb.ToString();
        }

       
        protected override string MostrarDatos()
        {
            if (this != null)
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine(base.MostrarDatos());
                sb.AppendLine(this.ParticiparEnClase());
                return sb.ToString();
            }
            else return ""; 
        }

        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion

        #region Operadores
        public static bool operator ==(Profesor prof, Universidad.EClases clas)
        {
            bool esIgual= false;
            foreach (Universidad.EClases c in prof.clasesDelDia)
            {
                if (clas == c)
                {
                    esIgual = true;
                    break;
                }
            }
            return esIgual;

        }
        public static bool operator !=(Profesor prof, Universidad.EClases clas)
        {
            return !(prof == clas);
        }



        #endregion
    }
}
