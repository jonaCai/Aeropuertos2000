using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aeropuertos2000
{
    public class Validadores
    {
        public static int validarintpositivo(string texto, string msj)
        {
            int numero;
            string entrada;
            bool flag = true;

            do
            {
                Console.Write(texto);
                entrada = Console.ReadLine();
                if (!int.TryParse(entrada, out numero) || numero <= 0)
                {
                    Console.WriteLine(msj);
                    flag = false;
                }
                else { flag = true; }

            } while (flag == false);

            return numero;
        }
        public static int validarint(string texto)
        {
            int numero;
            string entrada;
            bool flag = true;

            do
            {
                Console.Write(texto);
                entrada = Console.ReadLine();
                if (!int.TryParse(entrada, out numero))
                {
                    Console.WriteLine("Debe ingresar un valor numérico.");
                    flag = false;
                }
                else { flag = true; }

            } while (flag == false);

            return numero;
        }

        public static decimal validardecimal(string entrada)
        {
            decimal numero;
            do
            {
                if (!decimal.TryParse(entrada, out numero))
                {
                    Console.WriteLine("Debe ingresar un valor decimal.");

                }

            } while (numero == 0);

            return numero;
        }

        public static bool TextoEsp(string texto, string ele1, string ele2)
        {
            string ingreso;
            bool flag=false;
            bool eleccion = true;
            do
            {
                Console.Write(texto);
                ingreso = Console.ReadLine().ToUpper();

                if (ingreso != ele1.ToUpper() && ingreso != ele2.ToUpper())
                {
                    Console.WriteLine($"Debe ingresar {ele1} o {ele2}.");
                    flag = true;
                }
                else if(ingreso==ele1.ToUpper())
                {
                    eleccion = true;
                    flag = false;
                }
                else
                {   eleccion = false;
                    flag = false;
                }


            } while (flag == true);

            return eleccion;
        }

        //Incertar lista, array o diccionario donde comparar y metodo de busqueda.
         
        public static bool ValidarCodigo(string codigo)
        {
            bool flag = false;
            foreach (var a in Aeropuertos.Lista_aeropuertos)
            {
                if (codigo== a)
                {
                    flag = true;
                }
            }
            return flag;
        }
        public static int ValidarCodigo(string text1, string text2)
        {
            string ingreso;
            int num = 0;
            bool flag = false;
            do
            {
                Console.Write(text1);
                ingreso = Console.ReadLine();
                if (Reservas.exist_num_reserva(ingreso))
                {
                    Console.WriteLine(text2);
                    continue;
                }
                else if (int.TryParse(ingreso, out num))
                {
                    flag = true;
                }



            } while (flag == false);


            return num;
        }

        /*
        public static bool ValidarCodigo(string code)
        {
            bool flag = false;
            foreach (var a in NominaCursos.nomina)
            {
                if (code == a.Key)
                {
                    flag = true;
                }
            }
            return flag;
        }
        */
        public static string Valtexto(string texto)
        {
            bool flag;
            string ingreso = "";
            do
            {
                flag = false;
                Console.Write(texto);
                ingreso = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(ingreso))
                {
                    flag = true;
                    Console.WriteLine("Debe ingresar un codigo.");
                }



            } while (flag == true);

            return ingreso;


        }
        public static string ValtextoTresLetras(string texto)
        {
            bool flag=false;
            string ingreso = "";
            do
            {
                Console.Write(texto);
                ingreso = Console.ReadLine();
                if (ingreso.Length > 3 || ingreso.Length <= 2)
                {
                    flag = true;
                    Console.WriteLine("Debe ingresar un codigo de tres letras.");
                }
                else { flag = false; }



            } while (flag == true);

            return ingreso;


        }
        //nuevo validador aqui
    }
}
