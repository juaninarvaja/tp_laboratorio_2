using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {
    /// <summary>
    /// Valida que el operador sea valido
    /// </summary>
    /// <param name="operador">operador en forma de char</param>
    private static  string ValidarOperador(string operador)
        {
            if (operador == "+" || operador == "-" || operador == "/" || operador == "*")
            {
                return operador;
            }
            else return "+";
        }
    /// Recibe dos numeros y un operador y devuelve el resultado de la operacion 
    /// </summary>
    /// <param name="numeroUno">primer valor</param>
    /// <param name="numeroDos">segundo valor</param>
    /// <param name="operador">operador </param>
    /// <returns>resutlado en dorma de double</returns>
    public static double Operar(Numero numeroUno, Numero numeroDos, string operador)
        {
            operador = ValidarOperador(operador);
            double resultado = 0;
            switch (operador)
            {
                case "+": resultado = numeroUno + numeroDos;
                    break;  
                case "-": resultado = numeroUno - numeroDos;
                    break;
                case "/": resultado = numeroUno / numeroDos;
                    break;
                case "*": resultado = numeroUno * numeroDos;
                    break;

            }
            return resultado;

        }



    }
}
