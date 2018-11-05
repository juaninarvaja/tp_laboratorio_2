using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Narvaja.JuanIgnacio._2D.TP3
{
    class Texto : IArchivo<string>
    {
        public bool Guardar(string path, string datos)
        {
            StreamWriter file = null;
            bool retorno = true;
            try
            {
                file = new StreamWriter(path, false);
                file.Write(datos);
            }
            catch (Exception)
            {
                retorno = false; 
            }
            finally
            {
                file.Close();
            }
            return retorno;
        }

        /// <summary>
        /// Permite leer lo datos en formato texto. 
        /// </summary>
        /// <param name="archivo">PATH donde se guarda el archivo a leer.</param>
        /// <param name="datos">Parametro de salida donde se guardarán los datos leídos.</param>
        /// <returns>Devuelve true si no se produjeron excepciones al leer, false si
        /// se produjeron excepciones.</returns>
        public bool Leer(string path, out string datos)
        {
            StreamReader file = null;
            bool retorno = true; //Devuelve true si no se produjeron excepciones.
            try
            {
                file = new StreamReader(path);
                datos = file.ReadToEnd();
            }
            catch (Exception)
            {
                datos = null;
                retorno = false;
            }
            finally
            {
                file.Close();
            }
            return retorno;
        }
    }
}
