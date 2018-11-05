using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Narvaja.JuanIgnacio._2D.TP3
{
    public class Jornada
    {
        public List<Alumno> alumnos;
        Universidad.EClases clase;
        Profesor instructor;


        public Jornada()
        {
            this.alumnos = new List<Alumno>();
        }
        public Jornada(Universidad.EClases claseRec, Profesor profesor) : this()
        {
            this.clase = claseRec;
            this.instructor = profesor;
        }


        #region operadores
        public static bool operator ==(Jornada jorn, Alumno alum)
        {
            bool esIgual = false;
            foreach (Alumno a in jorn.alumnos)
            {
                if (a == alum)
                {
                    esIgual = true;
                    break;
                }
            }
            return esIgual;
        }
        public static bool operator !=(Jornada jorn, Alumno alum)
        {
            return !(jorn == alum);
        }
        public static Jornada operator +(Jornada jorn, Alumno alum)
        {
            if (jorn != alum)
            {
                jorn.alumnos.Add(alum);
                return jorn;

            }
            return jorn;

        }
        #endregion

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Clase de: " + this.clase + "Del Profesor: " + this.instructor);
            sb.AppendLine("Alumnos:");
            foreach (Alumno alumno in this.alumnos)
            {
                sb.AppendLine(alumno.ToString());
            }

            return sb.ToString();
        }
        public static string Leer() //mirar esto que onda
        {
            Texto text = new Texto();
            string datosArchivo;
            bool leyo = text.Leer("Jornada.txt", out datosArchivo);
            if (!leyo)
            {
                throw new Exception();// crear exception
            }
            return datosArchivo;
        }

        public static bool Guardar(Jornada jornada)
        {
            Texto aux = new Texto();
            bool guardo = aux.Guardar("Jornada.txt", jornada.ToString());
            if (!guardo)
            { //Si no se pudo guardar, lanza una excepción. 
              // throw new ArchivosException("No se pudo guardar la jornada.");
                throw new Exception(); // crear excepcition (arriba)
            }
            return guardo;
        }

    }
}
