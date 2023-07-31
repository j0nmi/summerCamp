using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejemploFuncAction
{
    internal class Ejemplo
    {
        internal void EjemploAction()
        {
            // Llamamos a TestAction pasándole el método Acción
            TestAction(AccionMetodo, 1);

            // Llamar a TestAction escribiendo la expresión lambda como parámetro
            TestAction((x) => 
            { 
                // Hace referencia a: Action<int> accion
                Console.WriteLine($"En el parámetro Acción {x}");
            }, 2);

            // 1-. Crear una variable que almacene la accion
            // 2-. Llamar a testaction pasándole la variable y el valor 3
            Action<int> accion = (y) => { Console.WriteLine($"En el parámetro Acción {y}"); };
            TestAction(accion, 3);

            // Lista de acciones
            List<Action<int>> listaAcciones = new List<Action<int>>();
            listaAcciones.Add( accion );
            listaAcciones.Add(AccionMetodo);

            foreach (var elementoAccion in listaAcciones)
            {
                elementoAccion(1);
            }
        }

        // Metodo que recibe un Action de tipo int y un int
        // Dentro ha de llamar al Action pasado como parámetro
        public void TestAction(Action<int> accion, int numero)
        {
            accion.Invoke(numero);
        }

        public void AccionMetodo(int numero)
        {
            Console.WriteLine($"El método de Acción {numero}");
        }

        internal void EjemploFunc()
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
            Console.WriteLine($"La suma de los dos números es: " + sumar(10,20));

            // Expresión lambda para calcular el área de un rectángulo.
            // BASE X ALTURA.
            // La expresión lambda que crearemos tomará dos parámetros (base y altura) y devolverá el área del rectángulo.
            Func<double, double, double> areaRectangulo = (a, b) => { var area = a * b; return area; };
            Console.WriteLine($"El área del rectángulo es: " + areaRectangulo(10,20));
        }



    }
}
