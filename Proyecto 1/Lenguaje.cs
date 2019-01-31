using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_1
{
    class Lenguaje : Sintaxis
    {
        public Lenguaje()
        {
            Console.WriteLine("Compilando...");
        } 

         ~Lenguaje()
        {
            Console.WriteLine("Archivo fuente compilado");
        }

        public void Programa()
        {
            Librerias();
            Main();
        }
        private void Librerias()
        {
            MATCH("#");
            MATCH("include");
            MATCH("<");
            MATCH(c.Identificador);
            MATCH(".");
            MATCH("h");
            MATCH(">");
            if(GETContenido() == "#")
            {
                Librerias();
            }
        }
        private void Main()
        {
            MATCH("int");
            MATCH("main");
            MATCH("(");
            MATCH(")");
            MATCH("{");
            ListaDeInstrucciones();
            MATCH("}");
        }
        private void ListaDeInstrucciones()
        {
            Instruccion();
            MATCH(";");
            if (GETContenido() != "}")
            {
                ListaDeInstrucciones();
            }
        }

        private void Instruccion()
        {
            if (GETContenido() == "printf")
            {
                MATCH("printf");
                MATCH("(");
                if(GETClasificacion() == c.Cadena)
                {
                    MATCH(c.Cadena);
                }
                else
                {
                    MATCH(c.Identificador);
                }
                MATCH(")");
            }
            else if(GETContenido() == "scanf")
            {
                MATCH("scanf");
                MATCH("(");
                MATCH(c.Cadena);
                MATCH(",");
                MATCH("&");
                MATCH(c.Identificador);
                MATCH(")");
            }
            else
            {
                Asignacion();
            }
        }

        private void Asignacion()
        {
            MATCH(c.Identificador);
            MATCH("=");
            Expresion();
        }

        private void Expresion()
        {
            Termino();
            MasTermino();
        }

        private void Termino()
        {
            Factor();
            PorFactor();
        }

        private void MasTermino()
        {
            if(GETClasificacion() == c.OperadorTermino)
            {
                MATCH(c.OperadorTermino);
                Termino();
            }
        }

        private void PorFactor()
        {
            if(GETClasificacion() == c.OperadorFactor)
            {
                MATCH(c.OperadorFactor);
                Factor();
            }
        }

        private void Factor()
        {
            if (GETClasificacion() == c.Numero)
            {
                MATCH(c.Numero);
            }
            else if (GETClasificacion() == c.Identificador)
            {
                MATCH(c.Identificador);
            }
            else
            {
                MATCH("(");
                Expresion();
                MATCH(")");
            }
        }
    }
}
