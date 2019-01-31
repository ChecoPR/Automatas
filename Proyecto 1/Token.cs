using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_1
{
    class Token
    {
        public enum c
        {
            Identificador,
            Numero,
            Caracter,
            OperadorTermino,
            OperadorLogico,
            OperadorRelacional,
            OperadorFactor,
            Cadena,
        }

        //int const identificador = 0, numero = 1, caracter = 2;

        private string contenido;
        private c clasificacion;

        public void SETContenido(string c)
        {
            contenido = c;
        }

        public void SETClasificacion(c clasificacion)
        {
            this.clasificacion = clasificacion;
        }

        public string GETContenido()
        {
            return contenido;
        }

        public c GETClasificacion()
        {
            return clasificacion;
        }

        public string STRClasificacion()
        {
            switch (clasificacion)
            {

                case c.Identificador:
                    return "Identificador";

                case c.Numero:
                    return "Numero";

                case c.Caracter:
                    return "Caracter";

                case c.OperadorTermino:
                    return "Operador de término";

                case c.OperadorLogico:
                    return "Operador Lógico";

                case c.OperadorRelacional:
                    return "Operador Relacional";
                
                case c.OperadorFactor:
                    return "Operador de Factor";

                case c.Cadena:
                    return "Cadena de texto";

                default:
                    return "Sin clasificacion";
            }
        }

        public string STRClasificacion(c clasificacion)
        {
            switch (clasificacion)
            {

                case c.Identificador:
                    return "Identificador";

                case c.Numero:
                    return "Numero";

                case c.Caracter:
                    return "Caracter";

                case c.OperadorTermino:
                    return "Operador de término";

                case c.OperadorLogico:
                    return "Operador Lógico";

                case c.OperadorRelacional:
                    return "Operador Relacional";

                case c.OperadorFactor:
                    return "Operador de Factor";

                case c.Cadena:
                    return "Cadena de texto";

                default:
                    return "Sin clasificacion";
            }
        }
    }
}
