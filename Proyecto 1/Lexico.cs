using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Proyecto_1
{
    class Lexico : Token
    {
        public StreamReader Archivo;
        protected StreamWriter Log;
        private bool disposed = false;

        public Lexico()
        {
            try
            {
                Archivo = new StreamReader("C:\\archivos\\prueba.txt");
                Log = new StreamWriter("C:\\archivos\\prueba.log");
                Log.WriteLine("Bitácora de compilación");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("No se encontró el archivo prueba.txt");
                Console.ReadKey();
                System.Environment.Exit(-1);
                return;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                handle.Dispose();
                // Free any other managed objects here.
            }
            // Free any unmanaged objects here.
            //Que el log se cierre en el destructor con DISPOSE
            Log.Close();
            disposed = true;
        }

        ~Lexico()
        {
            Archivo.Close();
            Log.Close();
        }

        public int automata(int renglon, int columna)
        {
            const int F = -1, E = -2;
            int[,] TRAND =
            {
            //  0   1  2  3  4  5  6  7  8  9  10  11 12 13 14 15 16 17
      //Estado  sp  L  D  .  E  +  - lam &  |  !   <  >  =   *  /  % ""
          /*0*/ {0, 1, 2, 8, 1, 9, 9, 8,10, 11,12,14,14, 8, 16,16,16,17},
          /*1*/ {F, 1, 1, F, 1, F, F, F, F,  F, F, F, F, F, F, F, F, F},
          /*2*/ {F, F, 2, 3, 5, F, F, F, F , F, F, F, F, F, F, F, F, F},
          /*3*/ {E, E, 4, E, E, E, E, E, E , E, E, E, E, E, E, E, E, E},
          /*4*/ {F, F, 4, F, 5, F, F, F, F , F, F, F, F, F, F, F, F, F},
          /*5*/ {E, E, 7, E, E, 6, 6, E, F , F, F, F, F, F, F, F, F, F},
          /*6*/ {E, E, 7, E, E, E, E, E, E , E, E, E, E, E, E, E, E, E},
          /*7*/ {F, F, 7, F, F, F, F, F, F , F, F, F, F, F, F, F, F, F},
          /*8*/ {F, F, F, F, F, F, F, F, F , F, F, F, F,15, F, F, F, F},
          /*9*/ {F, F, F, F, F, F, F, F, F , F, F, F, F, F, F, F, F, F},
         /*10*/ {F, F, F, F, F, F, F, F,13 , F, F, F, F, F, F, F, F, F},
         /*11*/ {F, F, F, F, F, F, F, F, F ,13, F, F, F, F, F, F, F, F},
         /*12*/ {F, F, F, F, F, F, F, F, F , F, F, F, F,15, F, F, F, F},
         /*13*/ {F, F, F, F, F, F, F, F, F , F, F, F, F, F, F, F, F, F},
         /*14*/ {F, F, F, F, F, F, F, F, F , F, F, F, F,15, F, F, F, F},
         /*15*/ {F, F, F, F, F, F, F, F, F , F, F, F, F, F, F, F, F, F},
         /*16*/ {F, F, F, F, F, F, F, F, F , F, F, F, F, F, F, F, F, F},
         /*17*/ {17,17,17,17,17,17,17,17,17,17,17,17,17,17,17,17,17,18},
         /*18*/ {F, F, F, F, F, F, F, F, F , F, F, F, F, F, F, F, F, F},

            };
            switch (TRAND[renglon, columna])
            {
                case 1:
                    SETClasificacion(c.Identificador);
                    break;
                case 2:
                    SETClasificacion(c.Numero);
                    break;
                case 8:
                    SETClasificacion(c.Caracter);
                    break;
                case 9:
                    SETClasificacion(c.OperadorTermino);
                    break;
                case 10:
                    SETClasificacion(c.Caracter);
                    break;
                case 11:
                    SETClasificacion(c.Caracter);
                    break;
                case 12:
                    SETClasificacion(c.OperadorLogico);
                    break;
                case 13:
                    SETClasificacion(c.OperadorLogico);
                    break;
                case 14:
                    SETClasificacion(c.OperadorRelacional);
                    break;
                case 15:
                    SETClasificacion(c.OperadorRelacional);
                    break;
                case 16:
                    SETClasificacion(c.OperadorFactor);
                    break;
                case 18:
                    SETClasificacion(c.Cadena);
                    break;
            }
            return TRAND[renglon, columna];
        }

        private int columna(char signo)
        {
            if (char.IsWhiteSpace(signo))
            {
                return 0;
            }
            else if (char.ToUpper(signo) == 'E')
            {
                return 4;
            }
            else if (char.IsLetter(signo))
            {
                return 1;
            }
            else if (char.IsDigit(signo))
            {
                return 2;
            }
            else if (signo == '.')
            {
                return 3;
            }
            else if (signo == '+')
            {
                return 5;
            }
            else if (signo == '-')
            {
                return 6;
            }
            else if (signo == '&')
            {
                return 8;
            }
            else if (signo == '|')
            {
                return 9;
            }
            else if (signo == '!')
            {
                return 10;
            }
            else if (signo == '<')
            {
                return 11;
            }
            else if (signo == '>')
            {
                return 12;
            }
            else if (signo == '=')
            {
                return 13;
            }
            else if (signo == '*')
            {
                return 14;
            }
            else if (signo == '/')
            {
                return 15;
            }
            else if (signo == '%')
            {
                return 16;
            }
            else if (signo == '"')
            {
                return 17;
            }
            else
            {
                return 7;
            }
        }

        public void nextToken()
        {
            char c;
            const int e = -2;
            int estado = 0;
            string buffer = "";

            while (estado >= 0)
            {
                c = (char)Archivo.Peek();
                estado = automata(estado, columna(c));

                if (estado >= 0) //Si no es estado de aceptación o error
                {
                    Archivo.Read();
                    if (estado > 0) //Concatenar valores válidos (sin espacios)
                        buffer += c;
                }
            }
            if (estado == e) // else if (estado == e) ... levantar Excepción ERROR Léxico: Espera un dígito
            {
                Console.WriteLine("Error léxico: se espera un dígito.");
                Log.WriteLine("Error léxico: se espera un dígito.");
                throw new LexicoException(buffer);
            }   //levantar exceptions en errores lexicos y sintaticos
                //levantar una exception en caso de que el archivo no exista
                //agregar la instrucción if
                // instruccion -> 
            //if (condicion)
            //{
            //    instruccion();
            //}
            //(else (optativo){
            //    instruccion();
            //})?
            //condicion-> expresion operadorRelacional expresion
                SETContenido(buffer);
        }
    }


    public class NumberException : Exception
    {
        public NumberException(string error) : base(String.Format("Se espera un número o signo: {0}", error))
        {
        }
    }

    public class LexicoException : Exception
    {
        public LexicoException(string error) : base(String.Format("Se espera un dígito: {0}", error))
        {
        }
    }

}
