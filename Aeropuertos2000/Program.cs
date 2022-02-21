using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aeropuertos2000
{
    class Program
    {
        static void Main(string[] args)
        {
            bool flag_salida=false;
            string eleccion;
            string menu = @"Bienvenidos a Aeropuertos 2000.
En que podemos ayudarle?
A)Ingresar Aeropuertos
B)Ingresar vuelos disponibles
C)Ingresar reservas
D)Ver reporte de reservas asignadas
E)Salir 
"
;
            
            do
            {
                Console.WriteLine();
                dibujarCajaMenu(menu);
                Console.Write("   Elección?: ");
                eleccion = Console.ReadLine().ToUpper();

                switch (eleccion)
                {
                    case "A":
                        do
                        {
                            Aeropuertos.agregar_nuevo();
                            flag_salida = Validadores.TextoEsp("Desea continuar ingresando aeropuertos?", "si", "no");

                        } while (flag_salida == true);


                        break;
                    case "B":

                        do
                        {
                            Vuelos.ingresar_disponibles();
                            flag_salida = Validadores.TextoEsp("Desea continuar ingresando vuelos?", "SI", "NO");

                        } while (flag_salida == true);

                        break;
                    case "C":
                        do
                        {
                            Reservas.ingresar_reserva();
                            flag_salida = Validadores.TextoEsp("Desea continuar ingresando reservas?", "SI", "NO");

                        } while (flag_salida == true);

                        break;
                    case "D":

                        Reservas.Mostrar();
                        break;
                    case "E":

                        Console.WriteLine("Saliendo del programa, presione cualquier tecla...");
                        flag_salida = true;
                        break;
                    default:
                        Console.WriteLine("Debe ingresar A-B-C-D o E.");
                        break;

                }

            } while (eleccion != "E");
            
            Console.ReadKey();

        }

        static void dibujarCajaMenu(string menu)
        {
            string [] linea = menu.Split('\n');
            int lineamayor=0;
            foreach (var ite in linea)
            {
                if (ite.Length> lineamayor) { lineamayor = ite.Length; }
                
            }
            
            for(int a=0; a< lineamayor+2; a++)
            {
                Console.Write("*");              
            }

            Console.WriteLine();
            
            for(int a=0; a< linea.Length-1;++a)
            {
                //
                Console.Write("*");
                
                Console.WriteLine($"{ linea[a].TrimEnd().PadRight(lineamayor)}*");
                //

            }
            for (int a = 0; a < lineamayor+2; a++)
            {
                Console.Write("*");
            }
            Console.WriteLine();

        }

    }
}
