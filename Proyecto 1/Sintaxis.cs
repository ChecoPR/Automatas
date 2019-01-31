using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_1 
{
    class Sintaxis : Lexico
    {
        public Sintaxis()
        {
            nextToken();
        }

        public void MATCH(string esperado)
        {
            if(esperado == GETContenido())
            {
                nextToken();
            }
            else
            {
                Console.WriteLine("Error de sintáxis, se espera un " + esperado);
                Console.WriteLine("El contenido del token = " + GETContenido());
                Log.WriteLine("Error de sintáxis, se espera un " + esperado);
                Log.WriteLine("El contenido del token = " + GETContenido());
            }
        }

        public void MATCH(c esperado)
        {
            if (esperado == GETClasificacion())
            {
                nextToken();
            }
            else
            {
                Console.WriteLine("Error de sintáxis, se espera un " + STRClasificacion(esperado));
                Console.WriteLine("El contenido del token = " + GETContenido());
                Log.WriteLine("Error de sintáxis, se espera un " + STRClasificacion(esperado));
                Log.WriteLine("El contenido del token = " + GETContenido());
            }
        }
    }
}
