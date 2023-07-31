using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejemploFuncAction
{
    internal class Ejemplo
    {
        internal void EjemploDelegados1()
        {
            // Expresión Lambda mediante Func<>
            Func<string> holaMundoExpresion =

                // 1-. Parametros
                ()
                // 2-. Operador Lambda
                =>
                // 3-. Delegado / Método anónimo / Expresión
                "Hola Mundo !!";

            Console.WriteLine(holaMundoExpresion);
            Console.WriteLine(holaMundoExpresion());

            // Expresion Lambda mediante Bloque Func<>
            Func<string> holaMundoBloque =

                // Parametros
                ()
                // Operador Lambda
                =>
                // Delegado / Método anónimo 
                {
                    var cadena = "Hola Mundo !!!";
                    return cadena;
                };

            Console.WriteLine(holaMundoBloque());

            // Crear una expresión lambda que sume 2 numeros
            // Expresión Lambda mediante Func<>
            Func<int, int, int> sumar = (a, b) => { var suma = a + b; return suma; };
            // 1 int: Primer param
            // 2 int: Segundo param
            // 3 int: return de la expresión lambda
            // Recibe 2 parametros de tipo entero (a,b)
            // Devuelve la suma de los dos parámetros
            Console.WriteLine(sumar(10,20));
        }



    }
}
