using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_1
{
    class Program
    {
        static void Main(string[] args)
        {
                Lenguaje t = new Lenguaje();
                //IMPLEMENTAR DESTRUCTOR EN LA CLASE LENGUAJE
                /*   while (!t.Archivo.EndOfStream)
                   {
                       t.nextToken();
                       Console.WriteLine("  " + t.GETContenido() + "     " + t.STRClasificacion());
                   }
                   Console.ReadKey();
               }*/
                t.Programa();
            Console.ReadKey();
        }
    }
}
