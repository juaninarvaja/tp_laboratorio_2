using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;

        public Numero() : this(0)
        {

        }

        public Numero(double numero)
        {
            this.numero = numero;
        }
        public Numero(string strNumero)
        {
            //Numero unNumero = new Numero();
           this.SetNumero= strNumero;
            
        }
        /// <summary>
        /// Valida si la cadena recibida es un numero
        /// </summary>
        /// <param name="strNumero"> Numero en forma de string </param>
        /// 
        /// <returns> retorna 0 si no es un numero, si lo es retorna un double cargado con ese valor </returns>
        private double ValidarNumero(string strNumero)
        {
            double dblNumero;
            bool esNumerico;
            esNumerico = double.TryParse(strNumero, out dblNumero);
            if (esNumerico)
            {
                return dblNumero;
            }
            else return 000;
        }
        /// <summary>
        /// Asigna un valor al atributo numero.
        /// </summary>
        /// <param name="strNumero">numero en forma de cadena</param>
        private string SetNumero
        {
            set{
               
                this.numero = ValidarNumero(value.ToString());

            }
             
        }
        /// <summary>
        /// Sobrecarga operador - para Numeros
        /// </summary>
        /// <param name="numeroUno"></param>
        /// <param name="numeroDos"></param>
        /// <returns></returns>
        public static double operator -(Numero numeroUno, Numero numeroDos)
        {
             double resultado = numeroUno.numero - numeroDos.numero;
            return resultado;
        }
        /// <summary>
        /// Sobrecarga operador + para Numeros
        /// </summary>
        /// <param name="numeroUno"></param>
        /// <param name="numeroDOs"></param>
        /// <returns></returns>
        public static double operator +(Numero numeroUno, Numero numeroDos)
        {
            double resultado = numeroUno.numero + numeroDos.numero;
            return resultado;
        }
    /// <summary>
    /// Sobrecarga operador * paraNumeros
    /// </summary>
    /// <param name="numeroUno"></param>
    /// <param name="numeroDos"></param>
    /// <returns></returns>
        public static double operator *(Numero numeroUno, Numero numeroDos)
        {
            return numeroUno.numero * numeroDos.numero;
        }

        /// <summary>
        /// Sobrecarga operador / para numeros
        /// </summary>
        /// <param name="numeroUno"> Primer numero</param>
        /// <param name="numeroDos"> Segundo numero</param>
        /// <returns></returns>
        public static double operator /(Numero numeroUno, Numero numeroDos)
        {
            double resultado = 0;
            if (numeroDos.numero != 0)
            {
                resultado = numeroUno.numero / numeroDos.numero;
            }
            else return 0;
            return resultado;
        }

        /// <summary>
        /// Convierte un string binario a decimal.
        /// </summary>
        /// <param name="binario">sBinario en froma de string</param>
        /// <returns>Si es posible retorna el valor en decimal con formato string, por lo contrario retornara "Valor inválido". </returns>
        public string BinarioDecimal(string binario)
        {
            char[] array = binario.ToCharArray();
           
            Array.Reverse(array);
            int acumulador = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == '1')
                {
                  
                    acumulador += (int)Math.Pow(2, i);
                }
            }
         
            return acumulador.ToString();
        }

        /// <summary>
        ///  Convierte un número de decimal a binario.
        /// </summary>
        /// <param name="numero">recibe un numero decimal en forma de string </param>
        /// <returns>Valor en formato string, de no ser posible retorna "Valor inválido".</returns>
        public string DecimalBinario(string numero)
        {
            int numeroInt;
            bool esNumero = int.TryParse(numero, out numeroInt);
            if (esNumero)
            {
                
                numero = Convert.ToString(numeroInt,2);
                return numero;

            }
            else return "Numero invalido";
            
        }

        /// <summary>
        ///  Convierte un número de decimal a binario.
        /// </summary>
        /// <param name="numero">recibe un numero Double</param>
        /// <returns>Valor del binario en formato string. De no es posible  retorna "Valor inválido".</returns>
        public string DecimalBinario(double numero)
        {
            string strNumero = numero.ToString();
            return DecimalBinario(strNumero);

        }


    }

   


}
