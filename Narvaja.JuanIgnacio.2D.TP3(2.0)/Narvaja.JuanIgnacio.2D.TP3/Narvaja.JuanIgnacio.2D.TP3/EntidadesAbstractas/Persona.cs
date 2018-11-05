using Narvaja.JuanIgnacio._2D.TP3.Excepeciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
   

    public abstract class Persona
    {
        public enum ENacionalidad
        {
            Argentino,
            Extranjero,
        }


        private string nombre;
        private string apellido;
        private ENacionalidad nacionalidad;
        private string dni;

        #region Propiedades
        public string DNI
        {
            get
            {
                return this.dni;
            }
            set
            {
                int dni = int.Parse(value);
                dni = ValidarDNI(this.Nacionalidad, dni);
                this.dni = dni.ToString();
            }
        }
    
        public string Nombre
        {
            get { return this.nombre; }
            set
            {
                string strRecibido = value;
                this.nombre = ValidarNombreApellido(strRecibido);


            }

        }

        public string Apellido
        {
            get { return this.apellido; }
            set
            {
                string strRecibido = value;
                this.apellido = ValidarNombreApellido(strRecibido);


            }

        }
        public ENacionalidad Nacionalidad
        {
            get { return this.nacionalidad; }
            set
            {
                if (value == ENacionalidad.Argentino || value == ENacionalidad.Extranjero)
                {
                    this.nacionalidad = value;
                }
            }
        }

        #endregion

        public Persona() { }
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        /// <summary>
        /// Constructor de instancia público.
        /// </summary>
        /// <param name="nombre">Nombre/s de la persona. </param>
        /// <param name="apellido">Apellido/s de la persona.</param>
        /// <param name="dni">DNI de la persona en formato INT.</param>
        /// <param name="nacionalidad">Nacionalidad de la persona, Argentino o Extranjero.</param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
        : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }


              private static int ValidarDNI(ENacionalidad nacionalidad, int dni)
        {
            if(dni< 1 || dni > 99999999) 
            {
                throw new DniInvalidoException("DNI inválido.");
            }
            
                    if (nacionalidad==ENacionalidad.Argentino && dni > 89999999)
                    {
                        throw new NacionalidadInvalidaException("La nacionalidad no se condice con el número de DNI."); 
                    }             
                    if(ENacionalidad.Extranjero == nacionalidad && dni <= 89999999)
                    {
                        throw new NacionalidadInvalidaException("La nacionalidad no se condice con el número de DNI.");
                    }
            return dni;
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("NOMBRE COMPLETO: " + this.Apellido + this.Nombre);
            sb.AppendFormat("\nNACIONALIDAD: " + this.nacionalidad);

            return sb.ToString();

        }








        private static string ValidarNombreApellido(string dato)
        {
            if (Regex.IsMatch(dato, @"^([a-zA-Záéíóú]+)(\s[a-zA-Záéíóú]+)*$"))
            {
                return dato;
            }
            return "";
        }

    }
}
