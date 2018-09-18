using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {
        private static  string ValidarOperador(string operador)
        {
            if (operador == "+" || operador == "-" || operador == "/" || operador == "*")
            {
                return operador;
            }
            else return "+";
        }
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
