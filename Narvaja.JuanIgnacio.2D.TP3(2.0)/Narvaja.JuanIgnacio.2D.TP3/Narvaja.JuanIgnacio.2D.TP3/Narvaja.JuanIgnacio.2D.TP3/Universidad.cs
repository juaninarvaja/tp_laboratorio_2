using Narvaja.JuanIgnacio._2D.TP3.Excepeciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Narvaja.JuanIgnacio._2D.TP3
{




    public class Universidad
    {
        private List<Alumno> alumnos;
        private List<Jornada> jornadas;
        private List<Profesor> profesores;

        public enum EClases
        {
            Programacion,
            Laboratorio,
            Legislacion,
            SPD
        }

        public Universidad()
        {
          
            this.alumnos = new List<Alumno>(); // lista inscriptos
            this.jornadas = new List<Jornada>();
            this.profesores = new List<Profesor>(); // lista quienes pueden dar clases
        }
       
        #region Propiedades
        /// <summary>
        /// Hace pública la lista de Alumnos.
        /// </summary>
        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            {
                this.alumnos = value;
            }
        }

        /// <summary>
        /// Hace pública la lista de Jornadas.
        /// </summary>
        public List<Jornada> Jornadas
        {
            get
            {
                return this.jornadas;
            }
            set
            {
                this.jornadas = value;
            }
        }

        /// <summary>
        /// Hace pública la lista de Profesores.
        /// </summary>
        public List<Profesor> Profesores
        {
            get
            {
                return this.profesores;
            }
            set
            {
                this.profesores = value;
            }
        }

        public Jornada this[int i]
        {
            get
            {
                if (i > -1 && i <= this.jornadas.Count)
                    return this.jornadas[i];
                else
                    return null;
            }
            set
            {
                if (i > -1 && i <= this.jornadas.Count)
                    this.jornadas[i] = value;
            }
        }

        #endregion

        #region Operadores Sobrecargas
        /// <summary>
        /// Una universidad es igual a un alumno si ese alumno está inscripto en la universidad. 
        /// </summary>
        /// <param name="uni">Universidad a comparar.</param>
        /// <param name="alum">Alumno a comparar.</param>
        /// <returns>Devuelve true si el alumno está inscripto en la universidad, sino false.</returns>
        public static bool operator ==(Universidad uni, Alumno alum)
        {
            bool retorno = uni.Alumnos.Contains(alum);
            return retorno;
        }

        /// <summary>
        /// Una universidad es distinta a un alumno si ese alumno NO está inscripto en la universidad. 
        /// </summary>
        /// <param name="uni">Universidad</param>
        /// <param name="alum">Alumno</param>
        /// <returns>true si el alumno no esta inscripto en la universidad, sino false.</returns>
        public static bool operator !=(Universidad uni, Alumno alum)
        {
            return !(uni == alum);
        }

        /// <summary>
        /// Una universidad es igual a un profesor si ese profesor es parte de la universidad. 
        /// </summary>
        /// <param name="g">Universidad a comparar.</param>
        /// <param name="a">Profesor a comparar.</param>
        /// <returns>Devuelve true si el profesor es parte de la universidad, sino false.</returns>
        public static bool operator ==(Universidad u, Profesor p)
        {
            return u.Profesores.Contains(p);
        }

        /// <summary>
        /// Una universidad es distinta a un profesor si ese profesor NO es parte de la universidad. 
        /// </summary>
        /// <param name="u">Universidad a comparar.</param>
        /// <param name="p">Profesor a comparar.</param>
        /// <returns>Devuelve true si el profesor NO es parte de la universidad, sino false.</returns>
        public static bool operator !=(Universidad u, Profesor p)
        {
            return !(u == p);
        }

        /// <summary>
        /// Devuelve el primer profesor  que de esa clase.
        /// </summary>
        /// <param name="g">Universidad a evaluar.</param>
        /// <param name="clase">Clase que debe dar el profesor.</param>
        /// <returns>Devuelve el primer profesor que de esa clase. Si no hay ninguno lanza 
        /// SinProfesorException.</returns>
        public static Profesor operator ==(Universidad u, EClases clase)
        {
            foreach (Profesor p in u.Profesores)
            {
                if (p == clase) //Será igual si el profesor da la clase
                {
                    return p;
                }
            }
            // Si no encontró profesor que de la clase lanza SinProfesorException...
            
            throw new SinProfesorException();
           
        }

        /// Devuelve el primer profesor de esa universidad que NO de esa clase.
        /// </summary>
        /// <param name="g">Universidad a evaluar.</param>
        /// <param name="clase">Clase que NO debe dar el profesor.</param>
        /// <returns>Devuelve el primer profesor que NO de esa clase. Si no hay ninguno lanza 
        /// SinProfesorException.</returns>
        public static Profesor operator !=(Universidad g, EClases clase)
        {
            foreach (Profesor p in g.Profesores)
            {
                if (p != clase) //Será distinto si el profesor no da la clase.
                {
                    return p;
                }
            }
            // Si no encontró profesor que NO de la clase lanza SinProfesorException...
            throw new SinProfesorException();
        }

        /// <summary>
        /// Inscribe a un alumno a la universidad (Siempre que no esté ya inscripto).
        /// </summary>
        /// <param name="g">Universidad en cuestión.</param>
        /// <param name="a">Alumno a inscribir.</param>
        /// <returns>Devuelve la universidad con el nuevo alumno cargado. 
        /// En el caso que el alumno ya estuviera inscripto, devuelve AlumnoRepetidoException</returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if (u != a) //Si el alumno no está inscripto en la universidad...
            {
                u.Alumnos.Add(a);
                return u;
            }
            else
            {
                
                
                throw new AlumnoRepetidoException();
            }
        }

        /// <summary>
        /// Agrega a un profesor a la universidad (Siempre que éste no sea ya parte de la misma).
        /// </summary>
        /// <param name="g">Universidad en cuestión.</param>
        /// <param name="a">Profesor a agregar.</param>
        /// <returns>Devuelve la universidad con el nuevo profesor cargado. 
        /// </returns>
        public static Universidad operator +(Universidad u, Profesor p)
        {
            if (u != p) //Si el profesor no es parte de la universidad...
            {
                u.Profesores.Add(p);
                return u;
            }
            else
            {
                throw new AlumnoRepetidoException();
            }
        }

        /// <summary>
        /// Agrega una nueva jornada de clase. Asigna un profesor a la misma 
        /// y a los alumnos que tomen esa clase.
        /// </summary>
        /// <param name="g">Universidad en cuestión.</param>
        /// <param name="clase">Clase a agregar.</param>
        /// <returns>La universidad con la nueva jornada de clase cargada.</returns>
        public static Universidad operator +(Universidad uni, Universidad.EClases clase)
        {
            
            Profesor profe = uni == clase;
            Jornada jornada = new Jornada(clase,profe);

            foreach (Alumno alumno in uni.Alumnos) //Por cada alumno inscripto en la universidad...
            {
                if (alumno == clase) //Será igual si toma esa clase y no es deudor...
                {
                    jornada.alumnos.Add(alumno); //Lo agrega a lista de alumnos de la clase...
                }
            }
            uni.Jornadas.Add(jornada);

            return uni;
        }
        #endregion

                
        #region Metodos
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();
            foreach (Jornada jornada in uni.Jornadas)
            {
                sb.AppendLine("Jornda:");
                sb.AppendLine(jornada.ToString());
                sb.AppendLine("------------------------------------------------------------------- ");
            }
            return sb.ToString();
        }

        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }
        #region XML
        public static void Guardar(Universidad uni)
        {
            Xml<Universidad> aux = new Xml<Universidad>();
            if (!aux.Guardar("Universidad.xml", uni))
            { //Si no se pudo guardar lanza la excepción.
                Exception e = new Exception();
                throw new ArchivosException(e);
            }
        }

        /// <summary>
        /// Deserializa una universidad guardada en formato XML.
        /// </summary>
        /// <returns>Objeto tipo Universidad con todos los datos guardados en el XML.</returns>
        public static Universidad Leer()
        {
            Universidad retorno;
            Xml<Universidad> aux = new Xml<Universidad>();
            if (!aux.Leer("Universidad.xml", out retorno))
            { //Si no se pudo guardar lanza la excepción.
                Exception e = new Exception();
                throw new ArchivosException(e);
            }
            return retorno;
        }
        #endregion
        #endregion


    }




}

