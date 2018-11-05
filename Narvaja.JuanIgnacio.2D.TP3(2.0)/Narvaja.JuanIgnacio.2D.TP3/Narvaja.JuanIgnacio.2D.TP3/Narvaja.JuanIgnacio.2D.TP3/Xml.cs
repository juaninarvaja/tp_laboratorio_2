using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Narvaja.JuanIgnacio._2D.TP3
{
     public class Xml<T> : IArchivo<T>
    {
        /// <summary>
        /// Permite serializar datos en formato XML. 
        /// </summary>
        /// <param name="path">PATH donde se guardará el archivo.</param>
        /// <param name="dato">Datos a guardar.</param>
        /// <returns>Devuelve true si no se produjeron excepciones al guardar, false si
        /// se produjeron excepciones.</returns>
        public bool Guardar(string path, T dato)
        {
            XmlSerializer ser = new XmlSerializer(typeof(T));
            XmlTextWriter writer = null;
            bool retorno = true;
            try
            {
                writer = new XmlTextWriter(path, null);
                ser.Serialize(writer, dato);
            }
            catch (Exception)
            {
                retorno = false;
            }
            finally
            {
                writer.Close();
                
            }
            return retorno;
        }

        /// <summary>
        /// Permite deserializar en XML.
        /// </summary>
        /// <param name="path">PATH del archivo a deserializar.</param>
        /// <param name="datos">Parámetro de salida donde se almacenarán los datos leídos.</param>
        /// <returns>Devuelve true si no se produjeron excepciones al leer, false si
        /// se produjeron excepciones.</returns>
        public bool Leer(string path, out T dato)
        {
            XmlSerializer ser = new XmlSerializer(typeof(T));
            XmlTextReader reader = null;
            bool retorno = true;            

            try
            {
                reader = new XmlTextReader(path);
                dato = (T)ser.Deserialize(reader);
            }
            catch (Exception)
            {
                dato = default(T);
                retorno = false; //Devuelve false si se produjeron excepciones. 
            }
            finally
            {
                reader.Close();
            }
            return retorno;
        }
    }
}
