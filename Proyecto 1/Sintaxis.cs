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
                try
                {
                    throw new ErrorLexico("Error de sintaxis: se espera un " + esperado);
                }
                catch (ErrorLexico)
                {
                    Console.WriteLine("Contenido: " + GETContenido());
                    Console.WriteLine("Clasificacion: " + STRClasificacion(GETClasificacion()));
                    Log.WriteLine("Error de sintaxis: Se espera un " + esperado);
                    Log.WriteLine("Contenido: " + GETContenido());
                    Log.WriteLine("Clasificacion: " + STRClasificacion(GETClasificacion()));
                }
                Log.Close();
                Console.ReadKey();
                Environment.Exit(0);
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
                try
                {
                    throw new ErrorLexico("Error de sintaxis: se espera un " + esperado);
                }
                catch (ErrorLexico)
                {
                    Console.WriteLine("Contenido: " + GETContenido());
                    Console.WriteLine("Clasificacion: " + STRClasificacion(GETClasificacion()));
                    Log.WriteLine("Error de sintaxis: Se espera un " + esperado);
                    Log.WriteLine("Contenido: " + GETContenido());
                    Log.WriteLine("Clasificacion: " + STRClasificacion(GETClasificacion()));
                }
                Log.Close();
                Console.ReadKey();
                Environment.Exit(0);
            }
        }
    }
}
